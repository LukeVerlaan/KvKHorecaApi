using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace KVKApp.Services.Web
{
    public class WebResponse
    {
        public string Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
