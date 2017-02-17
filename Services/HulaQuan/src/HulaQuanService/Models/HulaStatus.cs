using HulaQuanService.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HulaQuanService.Models
{
    public class HulaStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime PublishDate { get; set; }

        public string Content { get; set; }

        public string Publisher { get; set; }       

        public string Images { get; set; }
    }

    public class HulaStatusDetail
    {
        public string Content { get; set; }
        public string Publisher { get; set; }
        public List<Image> Images { get; set; }
        public DateTime PublishDate { get; private set; }

        public HulaStatusDetail()
        {
            this.PublishDate = DateTime.UtcNow;
        }
    }

    public class Image
    {
        public string FileName { get; set; }

        // Base64 string
        public string Base64Data { get; set; }
    }
}
