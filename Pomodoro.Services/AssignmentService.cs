using Pomodoro.Data;
using Pomodoro.Models;
using Pomodoro.Models.Assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Services
{
    public class AssignmentService
    {
        private readonly Guid _userId;

        public AssignmentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAssignment(AssignmentCreate model)
        {
            var entity =
                new Assignment()
                {
                    OwnerId = _userId,
                    AssignmentName = model.AssignmentName,
                    Description = model.Description,
                    Points = model.Points,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Assignments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AssignmentListItem> GetAssignment()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Assignments
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new AssignmentListItem
                                {
                                    AssignmentId = e.AssignmentId,
                                    AssignmentName = e.AssignmentName,
                                    Description = e.Description,
                                    Points = e.Points
                                }
                        );

                return query.ToArray();
            }
        }

        public AssignmentDetail GetAssignmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Assignments.Single(e => e.AssignmentId == id && e.OwnerId == _userId);
                return
                    new AssignmentDetail
                    {
                        AssignmentId = entity.AssignmentId,
                        AssignmentName = entity.AssignmentName,
                        Description = entity.Description,
                        Points = entity.Points
                    };
            }
        }

        public bool UpdateAssignment(AssignmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Assignments
                        .Single(e => e.AssignmentId == model.AssignmentId && e.OwnerId == _userId);

                entity.AssignmentName = model.AssignmentName;
                entity.Description = model.Description;
                entity.Points = model.Points;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAssignment(int assignmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Assignments
                        .Single(e => e.AssignmentId == assignmentId && e.OwnerId == _userId);

                ctx.Assignments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
