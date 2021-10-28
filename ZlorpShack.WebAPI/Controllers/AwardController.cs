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
    [Authorize]
    public class AwardController : ApiController
    {

        private AwardService CreateAwardService()
        {
            AwardService awardService = new AwardService();
            return awardService;
        }

        public IHttpActionResult Get()
        {
            AwardService awardService = CreateAwardService();
            var awards = awardService.GetAwards();
            return Ok(awards);
        }

        public IHttpActionResult Post(AwardCreate award)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAwardService();

            if (!service.CreateAward(award))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            AwardService awardService = CreateAwardService();
            var award = awardService.GetAwardById(id);
            return Ok(award);
        }

        public IHttpActionResult Put(AwardEdit award)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAwardService();

            if (!service.UpdateAward(award))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateAwardService();

            if (!service.DeleteAward(id))
                return InternalServerError();

            return Ok();
        }
    }
}
