using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Photo.Api.Models
{
    public class HttpException: Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public HttpException(HttpStatusCode statusCode, string message): base(message)
        {
            StatusCode = statusCode;
        }
    }
}
