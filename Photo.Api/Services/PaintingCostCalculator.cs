using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Photo.Api.Models;

namespace Photo.Api.Services
{
    public class PaintingCostCalculator: CostCalculator<PhotoPainting>
    {
        public PaintingCostCalculator(IBasePhoto photo) : base(photo)
        {
        }

        public override async Task<int> GetCost()
        {
            return await PhotoRepository.GetPaintingPriceAsync(Photo.PhotoId);
        }

    }
}
