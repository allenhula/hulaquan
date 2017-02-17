using HulaQuanService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HulaQuanService.Models
{
    public class HulaStatusRepository : IHulaStatusRepository
    {
        private readonly HulaStatusContext _context;

        public HulaStatusRepository(HulaStatusContext context)
        {
            _context = context;
        }

        public void Create(HulaStatus status)
        {
            _context.HulaStatusSet.Add(status);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var entity = _context.HulaStatusSet.First(s => s.Id.Equals(id));
            _context.HulaStatusSet.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<HulaStatus> Get()
        {
            return _context.HulaStatusSet.ToList();
        }

        public HulaStatus Get(string id)
        {
            return _context.HulaStatusSet.SingleOrDefault(s => s.Id.Equals(id));
        }

        public IEnumerable<HulaStatus> GetByPublisher(string publisher)
        {
            return _context.HulaStatusSet.Where(s => s.Publisher.Equals(publisher));
        }
    }
}
