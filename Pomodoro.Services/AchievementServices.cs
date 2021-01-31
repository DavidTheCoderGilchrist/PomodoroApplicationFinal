using Pomodoro.Data;
using Pomodoro.Models.Achievement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Services
{
    public class AchievementServices
    {
        private readonly Guid _userId;

        public AchievementServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAchievement(AchievementCreate model)
        {
            var entity =
                new Achievement()
                {
                    OwnerId = _userId,
                    AchievementName = model.AchievementName,
                    Description = model.Description,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Achievements.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AchievementListItem> GetAchievement()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Achievements
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new AchievementListItem
                                {
                                    AchievementId = e.AchievementId,
                                    AchievementName = e.AchievementName,
                                    Description = e.Description,
                                    

                                }
                        );

                return query.ToArray();
            }
        }

        public AchievementDetail GetAchievementById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Achievements.Single(e => e.AchievementId == id && e.OwnerId == _userId);
                return
                    new AchievementDetail
                    {
                        AchievementId = entity.AchievementId,
                        AchievementName = entity.AchievementName,
                        Description = entity.Description,
                        


                    };
            }
        }

        public bool UpdateAchievement(AchievementEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Achievements
                        .Single(e => e.AchievementId == model.AchievementId && e.OwnerId == _userId);

                entity.AchievementName = model.AchievementName;
                entity.Description = model.Description;
                

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAchievement(int assignmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Achievements
                        .Single(e => e.AchievementId == assignmentId && e.OwnerId == _userId);

                ctx.Achievements.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
