using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZlorpShack.Data;
using ZlorpShack.Model;

namespace ZlorpShack.Service
{
    public class AwardEarnedService
    {
        public bool CreateEarnedAward(AwardEarnedCreate ae)
        {
            var entity = new AwardEarned()
            {
                DateEarned = ae.DateEarned,
                DateClaimed = ae.DateClaimed,
                StudentId = ae.StudentId,
                AwardId = ae.AwardId
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.AwardsEarned.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AwardEarnedList> GetAllAwardsEarned()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.AwardsEarned.Select(e => new AwardEarnedList
                {
                    AwardEarnedId = e.AwardEarnedId,
                    DateEarned = e.DateEarned,
                    DateClaimed = e.DateClaimed,
                    StudentId = e.StudentId,
                    AwardId = e.AwardId
                }
                );
                return query.ToArray();
            }
        }

        public AwardEarnedDetail GetAwardByID(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.AwardsEarned.Single(e => e.AwardEarnedId == id);

                return new AwardEarnedDetail
                {
                    AwardEarnedId = entity.AwardEarnedId,
                    DateEarned = entity.DateEarned,
                    DateClaimed = entity.DateClaimed,
                    StudentId = entity.StudentId,
                    AwardId = entity.AwardId
                };
            }
        }

        public bool UpdateAwardEarned(AwardEarnedEdit ae)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.AwardsEarned.Single(e => e.AwardEarnedId == ae.AwardEarnedId);

                entity.AwardEarnedId = ae.AwardEarnedId;
                entity.DateEarned = ae.DateEarned;
                entity.DateClaimed = ae.DateClaimed;
                entity.StudentId = ae.StudentId;
                entity.AwardId = ae.AwardId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAwardEarned(int aeId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var ae = ctx.AwardsEarned.Single(e => e.AwardEarnedId == aeId);

                ctx.AwardsEarned.Remove(ae);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
