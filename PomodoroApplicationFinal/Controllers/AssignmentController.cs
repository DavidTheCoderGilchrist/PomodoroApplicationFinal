using Microsoft.AspNet.Identity;
using Pomodoro.Contracts;
using Pomodoro.Data;
using Pomodoro.Models;
using Pomodoro.Models.Assignment;
using Pomodoro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PomodoroApplicationFinal.Controllers
{
    [Authorize]
    public class AssignmentController : Controller
    {
        private readonly IAssignmentService _assignmentService;
       
                    
        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }
            // GET: Assignment
            public ActionResult Index()
            {
            //var model = new AssignmentListItem[0];
            //return View(model);

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AssignmentService(userId);
            var model = service.GetAssignment();

            return View(model);
        }


            public ActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(AssignmentCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAssignmentService();

            if (service.CreateAssignment(model))
            {
                TempData["SaveResult"] = "Your Assignment was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateAssignmentService();
            var model = svc.GetAssignmentById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAssignmentService();
            var detail = service.GetAssignmentById(id);
            var model =
                new AssignmentEdit
                {
                    AssignmentId = detail.AssignmentId,
                    AssignmentName = detail.AssignmentName,
                    Description = detail.Description
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AssignmentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AssignmentId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAssignmentService();

            if (service.UpdateAssignment(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {

            var svc = CreateAssignmentService();
            var model = svc.GetAssignmentById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAssignmentService();

            service.DeleteAssignment(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }
        private AssignmentService CreateAssignmentService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var service = new AssignmentService(userId);
                return service;
            }      
    }

}