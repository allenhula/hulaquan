using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HulaQuanService.Models
{
    public interface IStorageOperations
    {
        Task<string> UploadBlobAsync(string containerName, string blobName, byte[] data);
    }
}
