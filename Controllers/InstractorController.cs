using LearningSystem.Models;
using LearningSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace LearningSystem.Controllers
{
    public class InstractorController : Controller
    {
        ITIEntity context = new ITIEntity();
        public IActionResult Index()
        {
            List<Instructor> instructorsModel = context.Instructors.Include(i => i.Course).Include(i => i.Department).ToList();
            return View(instructorsModel);
        }
        public IActionResult New()
        {
            InstractorDeptCourseVM vm = new InstractorDeptCourseVM();
            List<Department> deptList = context.Departments.ToList();
            List<Course> courseList = context.Courses.ToList();
            vm.Courses = courseList;
            vm.Departments = deptList;
            return View(vm);
        }


        [HttpPost]
        public IActionResult New ( Instructor ins)
        {
            if (ins.Name!= null)
            {
                //if (ins.Image != null && ins.Image.Length > 0)
                //{

                //    var fileName = Path.GetFileName(ins.Image);
                //    var path = Path.Combine(Server.MapPath("~/uploads"), fileName);
                //    ins.Image.SaveAs(path);
                //}

                context.Instructors.Add(ins);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            InstractorDeptCourseVM vm = new InstractorDeptCourseVM();
            List<Department> deptList = context.Departments.ToList();
            List<Course> courseList = context.Courses.ToList();
            vm.id = ins.Id;
            vm.Name = ins.Name;
            vm.Address = ins.Address;
            vm.Image = ins.Image;
            vm.Salary = ins.Salary;
            vm.Dept_Id = ins.Dept_Id;
            vm.Crs_Id = ins.Crs_Id;
            vm.Courses = courseList;
            vm.Departments = deptList;
            return View(vm);
        }


        public IActionResult Edit(int id)
        {
            Instructor ins = context.Instructors.FirstOrDefault(ins=> ins.Id == id);
            InstractorDeptCourseVM vm = new InstractorDeptCourseVM();
            List<Department> deptList = context.Departments.ToList();
            List<Course> courseList = context.Courses.ToList();
            vm.id = ins.Id;
            vm.Name = ins.Name;
            vm.Address = ins.Address;
            vm.Image = ins.Image;
            vm.Salary = ins.Salary;
            vm.Dept_Id = ins.Dept_Id;
            vm.Crs_Id = ins.Crs_Id;
            vm.Courses = courseList;
            vm.Departments = deptList;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, Instructor ins)
        {
            if (ins.Name != null)
            {
               
                context.Update(ins);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            InstractorDeptCourseVM vm = new InstractorDeptCourseVM();
            List<Department> deptList = context.Departments.ToList();
            List<Course> courseList = context.Courses.ToList();
            vm.id = ins.Id;
            vm.Name = ins.Name;
            vm.Address = ins.Address;
            vm.Image = ins.Image;
            vm.Salary = ins.Salary;
            vm.Dept_Id = ins.Dept_Id;
            vm.Crs_Id = ins.Crs_Id;
            vm.Courses = courseList;
            vm.Departments = deptList;
            return View(vm);
        }
        public IActionResult Details(int id )
        {
            Instructor instructorModel = context.Instructors.FirstOrDefault(ins=>ins.Id==id);

            return View(instructorModel);
        }


        public IActionResult DetailsPartial(int id)
        {
            Instructor instructorModel = context.Instructors.FirstOrDefault(ins => ins.Id == id);

            return PartialView("_DetailsPartial", instructorModel);
        }

        public IActionResult GetCrsByDeptID(int deptID)
        {
            List<Course> courses = context.Courses.Where(c =>c.Dept_Id == deptID).ToList();
            return Json(courses);
        }

    }
}
