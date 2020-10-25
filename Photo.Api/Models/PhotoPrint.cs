using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Photo.Api.Models
{
    public class PhotoPrint: IBasePhoto
    {
        public int PhotoId { get; set; }
    }
}
