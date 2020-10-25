using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Photo.Api.Models;

namespace Photo.Api.Services
{
    public class PrintCostCalculator: CostCalculator<PhotoPrint>
    {
        public PrintCostCalculator(IBasePhoto photo) : base(photo)
        {
        }

        public override async Task<int> GetCost()
        {
            var cost = await PhotoRepository.GetPrintPriceAsync((this.Photo.PhotoId));
            return cost;
            //return 50;
        }

    }
}
