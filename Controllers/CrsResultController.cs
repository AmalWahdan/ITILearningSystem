using LearningSystem.Models;
using LearningSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningSystem.Controllers
{
    public class CrsResultController : Controller
    {
        ITIEntity context = new ITIEntity();
        public IActionResult GetResult(int id , int Crs_id)
        {
            TraineeCourseDegreeViewModel Vmodel = new TraineeCourseDegreeViewModel();
            crsResult crs = new crsResult();
            crs = context.crsResults.Include(CR => CR.Trainee).Include(CR => CR.Course).FirstOrDefault(CR => CR.Crs_Id == Crs_id && CR.Trainee_Id == id);
            Vmodel.TraineeName = crs.Trainee.Name; 
            Vmodel.CourseName = crs.Course.Name;
            Vmodel.TraineeDegree = crs.Degree;

            if ( crs.Degree >= crs.Course.minDegree)
            {
               Vmodel.Color = "green";

            }
            else
            {
                Vmodel.Color = "red";
            }
            return View(Vmodel);
        }


        public IActionResult GetTraineeResults(int id)
        {
            List<TraineeCourseDegreeViewModel> VmodelList = new List<TraineeCourseDegreeViewModel>();
            List<crsResult> crs = new List<crsResult>();

            crs = context.crsResults.Include(CR => CR.Trainee).Include(CR => CR.Course).Where(CR => CR.Trainee_Id == id).ToList();
           

            foreach(crsResult Result in crs )
            {
                TraineeCourseDegreeViewModel Vmodel = new TraineeCourseDegreeViewModel();
                Vmodel.TraineeName = Result.Trainee.Name;
                Vmodel.CourseName = Result.Course.Name;
                Vmodel.TraineeDegree = Result.Degree;
                if (Result.Degree >= Result.Course.minDegree)
                    Vmodel.Color = "green";
                else
                    Vmodel.Color = "red";

                VmodelList.Add(Vmodel);
            }

            return View("GetTraineeResults", VmodelList);


        }


        public IActionResult GetCourseResults(int id)
        {
            List<TraineeCourseDegreeViewModel> VmodelList = new List<TraineeCourseDegreeViewModel>();
            List<crsResult> crs = new List<crsResult>();

            crs = context.crsResults.Include(CR => CR.Trainee).Include(CR => CR.Course).Where(CR => CR.Crs_Id == id).ToList();


            foreach (crsResult Result in crs)
            {
                TraineeCourseDegreeViewModel Vmodel = new TraineeCourseDegreeViewModel();
                Vmodel.TraineeName = Result.Trainee.Name;
                Vmodel.CourseName = Result.Course.Name;
                Vmodel.TraineeDegree = Result.Degree;
                if (Result.Degree >= Result.Course.minDegree)
                    Vmodel.Color = "green";
                else
                    Vmodel.Color = "red";
                VmodelList.Add(Vmodel);
            }

            return View(VmodelList);


        }





    }
}
