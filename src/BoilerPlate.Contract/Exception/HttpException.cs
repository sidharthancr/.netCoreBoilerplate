using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Exception
{
    public class HttpException : System.Exception
    {
        public int StatusCode { get; set; } = 500;

        public HttpException() : this("Internal Server Error")
        {

        }
        public HttpException(string message) : base(message)
        {

        }

        public HttpException(int statusCode) : base(Constants.NOT_FOUND_MESSAGE)
        {
            StatusCode = statusCode;
        }

        public HttpException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
