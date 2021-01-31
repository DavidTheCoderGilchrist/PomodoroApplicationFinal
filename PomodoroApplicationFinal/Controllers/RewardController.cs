using Microsoft.AspNet.Identity;
using Pomodoro.Models.Reward;
using Pomodoro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PomodoroApplicationFinal.Controllers
{
    [Authorize]
    public class RewardController : Controller
    {
        // GET: Reward
        public ActionResult Index()
        {
            //var model = new RewardListItem[0];
            //return View(model);

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RewardService(userId);
            var model = service.GetReward();

            return View(model);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RewardCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRewardService();

            if (service.CreateReward(model))
            {
                TempData["SaveResult"] = "Your Reward was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRewardService();
            var model = svc.GetRewardById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRewardService();
            var detail = service.GetRewardById(id);
            var model =
                new RewardEdit
                {
                    RewardId = detail.RewardId,
                    RewardName = detail.RewardName,
                    Description = detail.Description,
                    PointCost = detail.PointCost
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RewardEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RewardId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRewardService();

            if (service.UpdateReward(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var service = CreateRewardService();

            service.DeleteReward(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");

            //var svc = CreateRewardService();
            //var model = svc.GetRewardById(id);

            //return View(model);
        }

        private RewardService CreateRewardService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RewardService(userId);
            return service;
        }
    }
}