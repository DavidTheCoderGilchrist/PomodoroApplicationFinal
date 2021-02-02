using Microsoft.AspNet.Identity;
using Pomodoro.Contracts;
using Pomodoro.Models.Achievement;
using Pomodoro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PomodoroApplicationFinal.Controllers
{
    [Authorize]
    public class AchievementController : Controller
    {
        private readonly IAchievementService _achievementService;

        public AchievementController(IAchievementService achievementService)
        {
            _achievementService = achievementService;
        }

        // GET: Achievement
        public ActionResult Index()
        {
            //var model = new AchievementListItem[0];
            //return View(model);

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AchievementServices(userId);
            var model = service.GetAchievement();

            return View(model);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AchievementCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAchievementService();

            if (service.CreateAchievement(model))
            {
                TempData["SaveResult"] = "Your Achievement was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateAchievementService();
            var model = svc.GetAchievementById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAchievementService();
            var detail = service.GetAchievementById(id);
            var model =
                new AchievementEdit
                {
                    AchievementId = detail.AchievementId,
                    AchievementName = detail.AchievementName,
                    Description = detail.Description
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AchievementEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AchievementId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAchievementService();

            if (service.UpdateAchievement(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {

            var svc = CreateAchievementService();
            var model = svc.GetAchievementById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAchievementService();

            service.DeleteAchievement(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

        private AchievementServices CreateAchievementService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AchievementServices(userId);
            return service;
        }
    }
}
