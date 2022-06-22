using Microsoft.AspNetCore.Mvc;
using SMSystem.Data;
using SMSystem.Models;

namespace SMSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Student> objStudentList = _db.Students;
            return View(objStudentList);
        }
        //Get
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Added Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var studentFromDb = _db.Students.Find(id);
            // var courseFromDbFirst = _db.Courses.FirstOrDefault(u=>u.Id == id);
            // var courseFromDbSingle = _db.Courses.SingleOrDefault(u => u.Id == id);

            if (studentFromDb == null)
            {
                return NotFound();
            }
            return View(studentFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Update(obj);
                TempData["success"] = " Update Successfully";

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var StudentFromDb = _db.Students.Find(id);


            if (StudentFromDb == null)
            {
                return NotFound();
            }
            return View(StudentFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Students.Remove(obj);
            TempData["success"] = "Delete Successfully";

            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

