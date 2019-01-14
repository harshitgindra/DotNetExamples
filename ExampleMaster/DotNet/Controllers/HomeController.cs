using DotNet.Core;
using DotNet.SignalR;
using Microsoft.AspNet.SignalR;
using System.Diagnostics;
using System.Threading;
using System.Web.Mvc;

namespace DotNet.Controllers
{
    public class HomeController : Controller
    {
        public CancellationTokenSource TokenSource;

        public HomeController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void StartTask()
        {
            AppConstants.TokenSource = new CancellationTokenSource();
            //context.Clients.All.Send("Admin", "stop the chat");
            for (int i = 0; i < 20; i++)
            {
                if (!AppConstants.TokenSource.Token.IsCancellationRequested)
                {
                    TaskHub.TaskUpdate($"Loop:{i}");
                    Thread.Sleep(2000);
                }
                else
                {
                    TaskHub.TaskUpdate($"Loop stopped");
                    break;
                }
            }

            TaskHub.TaskUpdate($"All Loops complete");
        }

        [HttpPost]
        public void StopTask()
        {
            if (AppConstants.TokenSource != null)
            {
                TaskHub.TaskUpdate($"Cancel Tasks requested");
                AppConstants.TokenSource.Cancel();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}