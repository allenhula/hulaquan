using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HulaQuanService.Models
{
    public interface IHulaStatusRepository
    {
        void Create(HulaStatus status);

        HulaStatus Get(string id);

        IEnumerable<HulaStatus> Get();

        void Delete(string id);

        IEnumerable<HulaStatus> GetByPublisher(string publisher);
    }
}
