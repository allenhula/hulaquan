# scripts to
# 1. create key vault
# 2. store connection string into key vault
# 3. register app and authorize permission

# TODO: update below settings based on your environment
$subscriptionId = "6fe23adb-9c5f-478b-a01d-2d23187f9dd4"
$keyVaultName = "allenlhulakv"
$keyVaultResourceGroupName = "allenlhularg"
$location = "China East"
$appName = "hulaquan"
$appKey = "!!123abc"
$appUri = "http://localhost:5000"
$stSecretName = "stConnectionString"
$stConnStr = "DefaultEndpointsProtocol=https;AccountName=allenlhulast;AccountKey=5+kWqp1jIGQdGPVp6o7pgT/8DlRYnE55jJbxh51h7WHU4yGqAbMYdCYbSfR2CaFsi1/pfmL+d/QJbeAmDn6FQg==;EndpointSuffix=core.chinacloudapi.cn;"
$dbSecretName = "dbConnectionString"
$dbConnStr = "Server=tcp:allenlhuladbsrv.database.chinacloudapi.cn,1433;Initial Catalog=huladb;Persist Security Info=False;User ID=allenl;Password=!!123abc;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

Login-AzureRmAccount -EnvironmentName AzureChinaCloud

# In case the account has multiple subscription, make sure the expected subscription is selected
$selectedSub = Select-AzureRmSubscription -SubscriptionId $subscriptionId
$tenantId = $selectedSub.Tenant.TenantId

# New-AzureRmResourceGroup -Name $keyVaultResourceGroupName -Location $location

# If you see the error The subscription is not registered to use namespace 'Microsoft.KeyVault' when you try to create your new key vault
# Run Register-AzureRmResourceProvider -ProviderNamespace "Microsoft.KeyVault, and then rerun your New-AzureRmKeyVault command
New-AzureRmKeyVault -VaultName $keyVaultName -ResourceGroupName $keyVaultResourceGroupName -Location $location

$stSecretValue = ConvertTo-SecureString $stConnStr -AsPlainText -Force
$stConnStrSecret = Set-AzureKeyVaultSecret -VaultName $keyVaultName -Name $stSecretName -SecretValue $stSecretValue

$dbSecretValue = ConvertTo-SecureString $dbConnStr -AsPlainText -Force
$dbConnStrSecret = Set-AzureKeyVaultSecret -VaultName $keyVaultName -Name $dbSecretName -SecretValue $dbsecretValue

# Register your app to Azure AD now
# And get its client id and client key
$app = New-AzureRmADApplication -DisplayName $appName -HomePage $appUri -IdentifierUris $appUri -Password $appKey
$appSP = New-AzureRmADServicePrincipal -ApplicationId $app.ApplicationId

# Authorize the app to use the secret
Set-AzureRmKeyVaultAccessPolicy -VaultName $keyVaultName -ServicePrincipalName $appSP.ApplicationId -PermissionsToSecrets get,list

Write-Host ("Target tenant ID is: {0}" -f $tenantId)
Write-Host ("Storage connection string key vault URI: {0}" -f $stConnStrSecret.Id)
Write-Host ("App Client Id is: {0}" -f $appSP.ApplicationId)
Write-Host ("App Client Key is: {0}" -f $appKey)