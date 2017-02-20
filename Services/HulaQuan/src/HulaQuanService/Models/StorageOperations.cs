using HulaQuanService.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HulaQuanService.Models
{
    public class StorageOperations : IStorageOperations
    {
        private CloudStorageAccount storageAccount;
        private CloudBlobClient blobClient;

        public StorageOperations(IConfiguration configuration)
        {
            storageAccount = CloudStorageAccount.Parse(configuration[Consts.storageConnStrSecureNameInKv]);
            blobClient = storageAccount.CreateCloudBlobClient();
        }

        public async Task<string> UploadBlobAsync(string containerName, string blobName, byte[] data)
        {
            var container = blobClient.GetContainerReference(containerName);

            if (!await container.ExistsAsync())
            {
                await container.CreateAsync();
                await container.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }

            var blob = container.GetBlockBlobReference(blobName);
            await blob.UploadFromByteArrayAsync(data, 0, data.Length);

            return blob.Uri.AbsoluteUri;
        }
    }
}
