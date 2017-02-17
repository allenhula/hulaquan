using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HulaQuanService.Helpers
{
    public class StorageHelper
    {
        private static string connnectionString = "DefaultEndpointsProtocol=https;AccountName=allenlhulast;AccountKey=5+kWqp1jIGQdGPVp6o7pgT/8DlRYnE55jJbxh51h7WHU4yGqAbMYdCYbSfR2CaFsi1/pfmL+d/QJbeAmDn6FQg==;EndpointSuffix=core.chinacloudapi.cn;";

        public static async Task<string> SaveImageToBlobAsync(string containerName, string blobName, byte[] imageData)
        {
            var storageAccount = CloudStorageAccount.Parse(connnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);

            if (!await container.ExistsAsync())
            {
                await container.CreateAsync();
                await container.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }            

            var blob = container.GetBlockBlobReference(blobName);
            await blob.UploadFromByteArrayAsync(imageData, 0, imageData.Length);
            
            return blob.Uri.AbsoluteUri;
        }
        
    }
}
