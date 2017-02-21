using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HulaQuanService.Models;
using System.IO;
using HulaQuanService.Helpers;
using System.Text;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HulaQuanService.Controllers
{
    [Route("api/[controller]")]
    public class HulaStatusController : Controller
    {
        public IHulaStatusRepository HulaStatusRepository { get; private set; }
        public IStorageOperations StorageOperations { get; private set; }

        public HulaStatusController(IHulaStatusRepository hulaStatusRepository, IStorageOperations storageOperations)
        {
            HulaStatusRepository = hulaStatusRepository;
            StorageOperations = storageOperations;
        }

        [HttpGet]
        public IEnumerable<HulaStatus> Get()
        {
            return HulaStatusRepository.Get();
        }

        [HttpGet("{publisher}")]
        public IEnumerable<HulaStatus> Get(string publisher)
        {
            return HulaStatusRepository.GetByPublisher(publisher);
        }

        [HttpPost]
        public async Task<IActionResult> Publish([FromBody] HulaStatusDetail status)
        {
            if (status == null)
            {
                return BadRequest("Invalid request body");
            }

            HulaStatus hulaStatus;
            try
            {
                // save images to storage at first
                // and get back the urls
                var imagesString = new StringBuilder();
                int count = 0;
                foreach (var image in status.Images)
                {
                    if (count > 0)
                    {
                        imagesString.Append(Consts.ImageStringDelimiter);
                    }

                    var imageBinary = Convert.FromBase64String(image.Base64Data);
                    var imageContainerName = status.Publisher;
                    var imageBlobName = $"{status.PublishDate.Year}/{status.PublishDate.Month}/{status.PublishDate.Ticks}_{count}.{image.FileName.Split('.').Last()}";

                    var imageUrl = await StorageOperations.UploadBlobAsync(imageContainerName, imageBlobName, imageBinary);

                    imagesString.Append(imageUrl);
                    count++;
                }

                // then add status to database
                hulaStatus = new HulaStatus()
                {
                    Content = status.Content,
                    Publisher = status.Publisher,
                    PublishDate = status.PublishDate,
                    Images = imagesString.ToString()
                };

                HulaStatusRepository.Create(hulaStatus);
            }
            catch (Exception)
            {
                return BadRequest("Failed to create");
            }
            
            return Ok(hulaStatus);
        }
    }
}
