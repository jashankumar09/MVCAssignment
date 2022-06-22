using Microsoft.AspNetCore.Mvc;
using SMSystem.Data;
using SMSystem.Models;

namespace SMSystem.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CourseController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Course>objCourseList=_db.Courses;
            return View(objCourseList);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course obj)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Added Successfully"; 
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get
        public IActionResult Edit(int?id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var courseFromDb = _db.Courses.Find(id);
           // var courseFromDbFirst = _db.Courses.FirstOrDefault(u=>u.Id == id);
           // var courseFromDbSingle = _db.Courses.SingleOrDefault(u => u.Id == id);

            if(courseFromDb == null)
            {
                return NotFound();
            }
            return View(courseFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course obj)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Update(obj);
                TempData["success"] = " Update Successfully";

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var courseFromDb = _db.Courses.Find(id);
            

            if (courseFromDb == null)
            {
                return NotFound();
            }
            return View(courseFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int?id)
        {
            var obj=_db.Courses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Courses.Remove(obj);
            TempData["success"] = "Delete Successfully";

            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

