using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using Microsoft.AspNetCore.Server.IIS;
using Photo.Api.Models;
using Photo.Api.Services;
using System.Web;
using Microsoft.AspNetCore.Cors;
using Photo.Api.Exceptions;
using Photo.Api.Persistence;

namespace Photo.Api.Controllers
{
    [Route("api/photos")]
    public class PhotosController : ControllerBase
    {
        public readonly PhotoRepository PhotoRepository = new PhotoRepository();

        [HttpGet]
        [Route("count")]
        public async Task<int> GetPhotoCount()
        {
            return await PhotoRepository.GetPhotoCount();
        }

        [HttpGet]
        [Route("getPrint")]
        public async Task<int> GetPrintCost(int photoId)
        {
            if (photoId == 0)
            {
                throw new HttpException(HttpStatusCode.BadRequest, "Please provide a valid photoId.");
            }
            var print = new PhotoPrint
            {
                PhotoId = photoId
            };
            var costCalculator = new PrintCostCalculator(print);
            try
            {
                return await costCalculator.GetCost();
            }
            catch (NotFoundException e)
            {
                throw new HttpException(HttpStatusCode.NotFound, e.Message);
            }
        }

        [HttpGet]
        [Route("getPainting")]
        public async Task<int> GetPaintingCost(int photoId)
        {
            if (photoId == 0)
            {
                throw new HttpException(HttpStatusCode.BadRequest, "Please provide a valid photoId.");
            }
            var print = new PhotoPainting
            {
                PhotoId = photoId
            };
            var costCalculator = new PaintingCostCalculator(print);
            try
            {
                return await costCalculator.GetCost();
            }
            catch (NotFoundException e)
            {
                throw new HttpException(HttpStatusCode.NotFound, e.Message);
            }
        }

        [HttpGet]
        [Route("costForAllPaintings")]
        public async Task<List<int>> GetAllPaintingCost()
        {
            return await PhotoRepository.GetPaintingPriceForAllPhotosAsync();
        }

        //[DisableCors]
        [HttpGet]
        [Route("costForAllPrints")]
        public async Task<List<int>> GetAllPrintCost()
        {
            return await PhotoRepository.GetPrintPriceForAllPhotosAsync();
        }
    }
}