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
        //private readonly Guid _userId;

        //public AwardService(Guid userId)
        //{
        //    _userId = userId;
        //}

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
                                    AwardId = e.AwardId, //Added by Jesse
                                    AwardName = e.AwardName,
                                    AwardTier = e.AwardTier,
                                    AwardDescription = e.AwardDescription
                                }
                               );
                return query.ToArray();
            }

        }
        public AwardDetail GetAwardById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Awards
                    .Single(e => e.AwardId == id);
                return
                    new AwardDetail
                    {
                        AwardId = entity.AwardId,
                        AwardName = entity.AwardName,
                        AwardTier = entity.AwardTier,
                        AwardDescription = entity.AwardDescription
                    };
            }
        }

        public bool UpdateAward(AwardEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Awards
                        .Single(e => e.AwardId == model.AwardId);

                entity.AwardName = model.AwardName;
                entity.AwardTier = model.AwardTier;
                entity.AwardDescription = model.AwardDescription;

                return ctx.SaveChanges() == 1;
            }

        }

        public bool DeleteAward(int awardId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Awards
                        .Single(e => e.AwardId == awardId);

                ctx.Awards.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
