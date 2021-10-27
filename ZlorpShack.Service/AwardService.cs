using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZlorpShack.Data;
using ZlorpShack.Model;

namespace ZlorpShack.Service
{
    public class AwardService
    {
        private readonly Guid _userId;

        public AwardService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAward(AwardCreate model)
        {
            var entity =
                new Award()
                {
                    AwardName = model.AwardName,
                    AwardTier = model.AwardTier,
                    AwardDescription = model.AwardDescription
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Awards.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<AwardListItems> GetAwards()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = 
                    ctx
                        .Awards
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new AwardListItems
                                {
                                    AwardName = e.AwardName,
                                    AwardTier = e.AwardTier,
                                    AwardDescription = e.AwardDescription
                                }
                               );
                return query.ToArray();
            }
        }
    }
}
