using Pomodoro.Models.Reward;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Contracts
{
    public interface IRewardService
    {
        bool CreateReward(RewardCreate model);
        IEnumerable<RewardListItem> GetReward();
        RewardDetail GetRewardById(int id);
        bool UpdateReward(RewardEdit model);
        bool DeleteReward(int assignmentId);
    }
}
