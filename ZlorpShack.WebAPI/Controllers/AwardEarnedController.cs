using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZlorpShack.Model;
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

        public IHttpActionResult Post(AwardEarnedCreate ae)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAEService();

            if (!service.CreateEarnedAward(ae))
                return InternalServerError();

            return Ok();

        }

        public IHttpActionResult Get()
        {
            var service = CreateAEService();

            var ae = service.GetAllAwardsEarned();

            return Ok(ae);
        }

        public IHttpActionResult Get(int id)
        {
            var service = CreateAEService();

            var ae = service.GetAwardByID(id);

            return Ok(ae);
        }

        public IHttpActionResult Put(AwardEarnedEdit ae)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAEService();

            if (!service.UpdateAwardEarned(ae))
                return InternalServerError();

            return Ok();

        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateAEService();

            if (!service.DeleteAwardEarned(id))
                return InternalServerError();

            return Ok();
        }
    }
}
