using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FeedbackManagement.Models;

namespace FeedbackManagement.Controllers
{
    public class FeedbackController : Controller
    {
        static List<Feedback> feedbacks = new List<Feedback>();

        public ActionResult Index()
        {
            return View(feedbacks);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.Id = feedbacks.Count + 1;
                feedbacks.Add(feedback);

                return RedirectToAction("Index");
            }

            return View(feedback);
        }
    }
}