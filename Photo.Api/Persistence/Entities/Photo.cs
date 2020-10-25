using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Photo.Api.Persistence.Entities
{
    public class Photo
    {
        public string Country { get; set; }
        
        public int Id { get; set; }

        public string Location { get; set; }
    }
}
