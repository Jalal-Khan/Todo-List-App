using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using Todo_List_App.Models;
using Todo_List_App.Models.Domain;

namespace Todo_List_App.Controllers
{
    public class HomeController : Controller
    {
        private static List<TaskModel> _tasks = new List<TaskModel>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model= new IndexViewModel();
            model.Tasks = _tasks;
            return View(model);
        }

       
        public IActionResult ClearList()
        {
            _tasks.Clear();
            return View("Index", new IndexViewModel());
        }

        public IActionResult Delete(string id)
        {
            Guid idGuid = Guid.Parse(id);
            var task = _tasks.FirstOrDefault(x => x.Id == idGuid);
            if (task != null)
                _tasks.Remove(task);
            var model = new IndexViewModel();
            model.Tasks = _tasks;
            return View("Index", model);
        }
        public IActionResult Search(string searchString)
        {
            ViewData["SearchString"]=searchString;
            var task = _tasks.ToList();
            var filteredResult=new List<TaskModel>();
            var model = new IndexViewModel();
            if(!string.IsNullOrEmpty(searchString))
            {
                filteredResult=task.Where(t=>t.Text.Contains(searchString)).ToList();
                model.Tasks = filteredResult.ToList();
            }
            return View("Index", model);
            
        }
        [HttpPost]
        public IActionResult UpdateSelectedStatus(string id, bool myCheckbox)
        {
            Guid idGuid = Guid.Parse(id);
            var task = _tasks.FirstOrDefault(x => x.Id == idGuid);
            if (task != null)
            { 
            task.IsSelected = !task.IsSelected;
            }
            return RedirectToAction("Index");
        }
        public IActionResult Add(AddTaskViewModel Request,string taskString)
        {
            ViewData["TaskString"] = taskString;
            Request.Text = taskString;

                var task = new TaskModel()
                {
                    Id = Guid.NewGuid(),
                    Text = Request.Text,
                    IsSelected = Request.IsSelected,
                };
                _tasks.Add(task);
                return RedirectToAction("Index");

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}