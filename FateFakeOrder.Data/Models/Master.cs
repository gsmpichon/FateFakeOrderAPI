using System;
using System.Collections.Generic;
using System.Text;

namespace FateFakeOrder.Data
{
    public class Master
    {
        public Master()
        {
            Servants = new List<Servant>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Servant> Servants { get; set;
        }
    }
}
