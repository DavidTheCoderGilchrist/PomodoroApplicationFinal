using Pomodoro.Data;
using Pomodoro.Models.Reward;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Services
{
    
    public class RewardService
    {
        private readonly Guid _userId;

        public RewardService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReward(RewardCreate model)
        {
            var entity =
                new Reward()
                {
                    OwnerId = _userId,
                    RewardName = model.RewardName,
                    Description = model.Description,
                        
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Rewards.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RewardListItem> GetReward()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Rewards
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new RewardListItem
                                {
                                    RewardId = e.RewardId,
                                    RewardName = e.RewardName,
                                    Description = e.Description,
                                    PointCost = e.PointCost
                                        
                                }
                        );

                return query.ToArray();
            }
        }

        public RewardDetail GetRewardById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rewards.Single(e => e.RewardId == id && e.OwnerId == _userId);
                return
                    new RewardDetail
                    {
                        RewardId = entity.RewardId,
                        RewardName = entity.RewardName,
                        Description = entity.Description,
                        PointCost = entity.PointCost


                    };
            }
        }

        public bool UpdateReward(RewardEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rewards
                        .Single(e => e.RewardId == model.RewardId && e.OwnerId == _userId);

                entity.RewardName = model.RewardName;
                entity.Description = model.Description;
                entity.PointCost = model.PointCost;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReward(int assignmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rewards
                        .Single(e => e.RewardId == assignmentId && e.OwnerId == _userId);

                ctx.Rewards.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
    
}

