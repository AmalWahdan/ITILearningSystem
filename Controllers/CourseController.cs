using LearningSystem.Models;
using LearningSystem.Repository;
using LearningSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Controllers
{
    public class CourseController : Controller
    {

        ICourseRepository courseRepository;
        IDepartmentRepository departmentRepository;
        public CourseController(ICourseRepository courseRepository,IDepartmentRepository departmentRepository)
        {
            this.courseRepository = courseRepository;
            this.departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            List<Course> instructorsModel = courseRepository.GetAll();
            return View(instructorsModel);
        }
        public IActionResult New()
        {
            CourseDeptVM vm = new CourseDeptVM();
            List<Department> deptList =departmentRepository.GetAll();
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
                    courseRepository.Insert(Crs);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Dept_ID", "Select Department");
                }

            }

            CourseDeptVM vm = new CourseDeptVM();
            List<Department> deptList = departmentRepository.GetAll();
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
            Course Crs = courseRepository.GetById(id);
            CourseDeptVM vm = new CourseDeptVM();
            List<Department> deptList = departmentRepository.GetAll();
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
                    courseRepository.Update(Crs);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Dept_ID", "Select Department");
                }
            }
            CourseDeptVM vm = new CourseDeptVM();
            List<Department> deptList = departmentRepository.GetAll();
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
            courseRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult CheckminDegree(int minDegree, int Degree)
        {
            if (minDegree < Degree)
                return Json(true);
            else
                return Json(false);
        }

        public IActionResult CheckName(string Name, int Id)
        {
            Course course = courseRepository.GetByName(Name);
            //Course courseReq = courseRepository.GetById(Id);

           if (course == null /*|| (course != null && course.Id == courseReq.Id)*/)
            {
                return Json(true);
            }
            return Json(false);

        }

    }
}
