using System;
using System.Collections.Generic;
using System.Text;

namespace FateFakeOrder.Data
{
    public class Servant
    {
        public int Id { get; set; }
        
        public int FamiliarId { get; set; }

        public int MasterId { get; set; }
        public Familiar Familiar { get; set; }

    }
}
