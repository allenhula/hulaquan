using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace HulaQuanService.Models
{
    public class FakeHulaStatusRepository : IHulaStatusRepository
    {
        private static IList<HulaStatus> _hulaStatusList = new List<HulaStatus>();

        public FakeHulaStatusRepository()
        {
            _hulaStatusList.Add(new HulaStatus() { Content = "first status", Publisher = "allan", Images = @"http:\\storage\1.jpg" });
            _hulaStatusList.Add(new HulaStatus() { Content = "second status", Publisher = "allan", Images =  @"http:\\storage\2.jpg" });
            _hulaStatusList.Add(new HulaStatus() { Content = "third status", Publisher = "candy", Images =  @"http:\\storage\3.jpg" });
        }

        public void Create(HulaStatus status)
        {
            _hulaStatusList.Add(status);
        }

        public void Delete(string id)
        {
            _hulaStatusList.Remove(Get(id));
        }

        public HulaStatus Get(string id)
        {
            return _hulaStatusList.SingleOrDefault(s => s.Id.Equals(id));
        }

        public IEnumerable<HulaStatus> Get()
        {
            return _hulaStatusList;
        }

        public IEnumerable<HulaStatus> GetByPublisher(string publisher)
        {
            var dic = _hulaStatusList.GroupBy(k => k.Publisher).ToDictionary(d => d.Key, v => v.ToList());
            List<HulaStatus> hulaStatusList;
            if (!dic.TryGetValue(publisher, out hulaStatusList))
            {
                hulaStatusList = new List<HulaStatus>();
            }
            return hulaStatusList;
        }
    }
}
