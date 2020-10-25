using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Photo.Api.Persistence.Entities
{
    public class PaintingPrice
    {
        public int BasePrice { get; set; }

        public int DurationInHour { get; set; }

        public int Id { get; set; }

        public int PhotoId { get; set; }

        public int PricePerHour { get; set; }

    }
}
