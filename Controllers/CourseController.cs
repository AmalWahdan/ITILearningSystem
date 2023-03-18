using LearningSystem.Models;
using LearningSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningSystem.Controllers
{
    public class CourseController : Controller
    {
        ITIEntity context = new ITIEntity();
        public IActionResult Index()
        {
            List<Course> instructorsModel = context.Courses.Include(s=>s.Department).ToList();
            return View(instructorsModel);
        }
        public IActionResult New()
        {
            CourseDeptVM vm = new CourseDeptVM();
            List<Department> deptList = context.Departments.ToList();
            vm.Departments = deptList;
            return View(vm);
        }

        [HttpPost]
        public IActionResult New(Course Crs)
        {


            if (ModelState.IsValid == true)
            {
                try
                {
                    context.Courses.Add(Crs);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Dept_ID", "Select Department");
                }

            }

            CourseDeptVM vm = new CourseDeptVM();
            List<Department> deptList = context.Departments.ToList();
            vm.Departments = deptList;
            vm.Id = Crs.Id;
            vm.Name = Crs.Name;
            vm.Degree = Crs.Degree;
            vm.minDegree = Crs.minDegree;
            vm.Dept_Id = Crs.Dept_Id;
            return View(vm);
        }

        public IActionResult Edit(int id)
        {
            Course Crs = context.Courses.FirstOrDefault(s => s.Id == id);
            CourseDeptVM vm = new CourseDeptVM();
            List<Department> deptList = context.Departments.ToList();
            vm.Departments = deptList;
            vm.Id = Crs.Id;
            vm.Name = Crs.Name;
            vm.Degree = Crs.Degree;
            vm.minDegree = Crs.minDegree;
            vm.Dept_Id = Crs.Dept_Id;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, Course Crs)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    context.Update(Crs);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Dept_ID", "Select Department");
                }
            }
            CourseDeptVM vm = new CourseDeptVM();
            List<Department> deptList = context.Departments.ToList();
            vm.Departments = deptList;
            vm.Id = Crs.Id;
            vm.Name = Crs.Name;
            vm.Degree = Crs.Degree;
            vm.minDegree = Crs.minDegree;
            vm.Dept_Id = Crs.Dept_Id;
            return View(vm);
        }


        public IActionResult DeleteCourse(int id)
        {
            Course course = context.Courses.FirstOrDefault(c=>c.Id==id);

            if (course != null)
            {
                context.Courses.Remove(course);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult CheckminDegree(int minDegree, int Degree)
        {
            if (minDegree<Degree)
                return Json(true);
            else
                return Json(false);
        }

    }
}
