using HulaQuanService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HulaQuanService.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HulaStatusContext context)
        {
            context.Database.EnsureCreated();

            if (context.HulaStatusSet.Any())
            {
                return;
            }

            context.HulaStatusSet.Add(new HulaStatus() { Content = "first status", Publisher = "allan", Images = @"http://storage/1.jpg,http://storage/11.jpg" });
            context.HulaStatusSet.Add(new HulaStatus() { Content = "second status", Publisher = "allan", Images = @"http://storage/2.jpg" });
            context.HulaStatusSet.Add(new HulaStatus() { Content = "third status", Publisher = "candy", Images = @"http://storage/3.jpg,http://storage/31.jpg" });

            context.SaveChanges();
        }
    }
}
