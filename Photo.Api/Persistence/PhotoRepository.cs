using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.CodeAnalysis.CSharp;
using Photo.Api.Exceptions;
using Photo.Api.Persistence.Entities;

namespace Photo.Api.Persistence
{
    public class PhotoRepository
    {
        private readonly string _connectionString =
            "Data Source = localhost; Initial Catalog = photos; Integrated Security=True; Connection Timeout = 9";

        public async Task<int> GetPrintPriceAsync(int photoId)
        {
            var sqlConnection = new SqlConnection(_connectionString);

            await sqlConnection.OpenAsync();
            var priceModel = await sqlConnection.QueryFirstOrDefaultAsync<PrintPrice>(
                "SELECT * FROM PrintPrice WHERE PhotoId = @photoId", new
                {
                    photoId
                });
            if (priceModel != null)
            {
                return this.calculatePrintPrice(priceModel);
            }

            throw new NotFoundException();

        }

        public async Task<int> GetPaintingPriceAsync(int photoId)
        {
            var sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();
            var priceModel = await sqlConnection.QueryFirstOrDefaultAsync<PaintingPrice>(
                "SELECT * FROM PaintingPrice WHERE PhotoId = @photoId", new
                {
                    photoId
                });
            if (priceModel != null)
            {
                return this.calculatePaintingPrice(priceModel);
            }

            throw new NotFoundException();
        }

        public async Task<int> GetPhotoCount()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            return await sqlConnection.QueryFirstOrDefaultAsync<int>("SELECT count(Id) FROM Photo");
        }

        public async Task<List<int>> GetPaintingPriceForAllPhotosAsync()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            var priceList = await sqlConnection.QueryAsync<PaintingPrice>(
                "SELECT * FROM PaintingPrice");
            var priceDictionary = new List<int>();
            foreach (var priceModel in priceList)
            {
                priceDictionary.Add(this.calculatePaintingPrice(priceModel));
            }

            return priceDictionary;
        }

        public async Task<List<int>> GetPrintPriceForAllPhotosAsync()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            var priceList = await sqlConnection.QueryAsync<PrintPrice>(
                "SELECT * FROM PrintPrice");
            var priceDictionary = new List<int>();
            foreach (var priceModel in priceList)
            {
                priceDictionary.Add(this.calculatePrintPrice(priceModel));
            }

            return priceDictionary;
        }

        private int calculatePaintingPrice(PaintingPrice priceModel)
        {
            return priceModel.BasePrice + priceModel.DurationInHour * priceModel.PricePerHour;
        }

        private int calculatePrintPrice(PrintPrice priceModel)
        {
            return priceModel.Price;
        }
    }
}
