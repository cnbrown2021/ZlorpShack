using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZlorpShack.Service;

namespace ZlorpShack.WebAPI.Controllers
{
    public class AwardEarnedController : ApiController
    {
        private AwardEarnedService CreateAEService()
        {
            var aeService = new AwardEarnedService();
            return aeService;
        }
    }
}
