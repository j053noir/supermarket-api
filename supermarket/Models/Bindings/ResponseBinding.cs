using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace supermarket.Models.Bindings
{
    public class ResponseBinding
    {
        public bool Status { get; set; }
        public int HttpStatusCode { get; set; }

        public string Message { get; set; }
        public dynamic Content { get; set; }
    }
}