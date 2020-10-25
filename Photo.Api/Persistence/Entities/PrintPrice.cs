using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Photo.Api.Persistence.Entities
{
    public class PrintPrice
    {
        public int Id { get; set; }

        public int PhotoId { get; set; }

        public int Price { get; set; }
    }
}
