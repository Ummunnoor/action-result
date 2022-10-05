using ActionResult.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActionResult.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View(Student.List());
        }


        public IActionResult Add(Student student)
        {
            ViewBag.message = "Added successfully";
            ViewData["message"] = "Added successfully";
            if(HttpContext.Request.Method == "POST")
            {
                var result = Student.Add(student);
                if (result.Item1)
                {
                    return RedirectToAction("Index");
                }
                return Content(result.Item2);
            }
            return View();
        }

        public IActionResult Edit(int id, Student student)
        {
            
            if(HttpContext.Request.Method == "POST")
            {
                var result = Student.Edit(id, student);
                return Json(new {status = result.Item1, message = result.Item2});
            }
            student = Student.Find(id);
            if (student == null)
            {
                return StatusCode(404, "Student Not Found");
            }
            return View(student);
        }

        public IActionResult View(int id)
        {
            var result = Student.Find(id);
            if(result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        public IActionResult Delete(int id)
        {
            var result = Student.Delete(id);
            if (result.Item1)
            {
                return RedirectToRoute(new { controller = "Student", action = "Index" });
            }
            return NotFound(result.Item2);
        }

        public IActionResult RedirectToPage()
        {
            return Redirect("https://google.com");
        }

        public IActionResult GetFile()
        {
            return File(System.IO.File.ReadAllBytes("C:\\Users\\Abdulrazaq Olanite O\\Desktop\\Cost.pdf"), "application/pdf", "newdata.pdf");
        }

        public IActionResult Partial()
        {
            return PartialView("_PartialView");
        }
    }
}
