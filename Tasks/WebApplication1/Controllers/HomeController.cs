using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using Task = WebApplication1.Models.Task;
using System.Text;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View("Login");
        }

        public IActionResult Validate(WebApplication1.Models.Administrator admin)
        {
            using (var client = new HttpClient())
            {
                //HTTP POST
                var postTask = client.PostAsync("https://localhost:44396/api/administrator", new StringContent(JsonConvert.SerializeObject(admin), Encoding.UTF8, "application/json"));
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var access = JsonConvert.DeserializeObject<bool>(readTask.Result);

                    if (access)
                    {
                        HttpContext.Session.SetString("SessionName", admin.Name);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
        }

        public IActionResult Index()
        {
            List<Task> tasks = null;
            ViewBag.Name = HttpContext.Session.GetString("SessionName");

            using (var client = new HttpClient())
            {
                //HTTP GET
                var responseTask = client.GetAsync("https://localhost:44396/api/tasks");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    tasks = JsonConvert.DeserializeObject<List<Task>>(readTask.Result);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o administrador.");
                }
            }
            return View(tasks);
        }

        public ActionResult Edit(int id)
        {
            WebApplication1.Models.Task task = null;

            using (var client = new HttpClient())
            {
                //HTTP GET
                var getTask = client.GetAsync("https://localhost:44396/api/task/" + id.ToString());
                getTask.Wait();

                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    task = JsonConvert.DeserializeObject<Task>(readTask.Result);
                }
            }

            return View("Edit", task);
        }

        [HttpPost]
        public ActionResult Edit(WebApplication1.Models.Task task)
        {
            using (var client = new HttpClient())
            {
                //HTTP PUT
                var putTask = client.PutAsync("https://localhost:44396/api/taskUpdate", new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json"));
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return View("Edit");
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("https://localhost:44396/api/taskDelete/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(WebApplication1.Models.Task task)
        {
            using (var client = new HttpClient())
            {
                //HTTP PUT
                var postTask = client.PostAsync("https://localhost:44396/api/taskInsert", new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json"));
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View("New");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
