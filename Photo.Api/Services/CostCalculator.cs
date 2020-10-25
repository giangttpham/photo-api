using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Photo.Api.Models;
using Photo.Api.Persistence;

namespace Photo.Api.Services
{
    public abstract class CostCalculator<T> where T:IBasePhoto
    {
        protected readonly IBasePhoto Photo;
        protected readonly PhotoRepository PhotoRepository = new PhotoRepository();

        protected CostCalculator(IBasePhoto photo)
        {
            this.Photo = photo;
        }

        public string GetName()
        {
            return this.Photo.PhotoId.ToString();
        }

        public abstract Task<int> GetCost();
    }
}
