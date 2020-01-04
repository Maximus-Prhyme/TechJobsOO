using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            // DONE #1 - get the Job with the given ID and pass it into the view
            Job job_id = JobData.Find(id);
            return View(job_id);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            // DONE #6 - Validate the ViewModel and if valid, create a 
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.
            if (ModelState.IsValid)
            {
               Job newJob = new Job{
                Name = newJobViewModel.Name,
                Location = newJobViewModel.Find(Locationid),
                CoreCompetency = newJobViewModel.Find(CoreCompetencyID),
                PositionType = newJobViewModel.Find(PositionTypeID),
                };
                jobData.Jobs.Add(newJob);
                return Redirect(string.Format("/Job?id={0}", newJob.ID));
            }
            else
            {
            return View(newJobViewModel);
            }
        }
    }
 }
    

