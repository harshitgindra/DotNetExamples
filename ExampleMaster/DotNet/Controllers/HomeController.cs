using DotNet.Core;
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
            for (int i = 0; i < 20; i++)
            {
                if (!AppConstants.TokenSource.Token.IsCancellationRequested)
                {
                    Debug.WriteLine($"Loop:{i}");
                    Thread.Sleep(2000);
                }
                else
                {
                    Debug.WriteLine($"Cancellation Token Requested");
                    break;
                }
            }
        }

        [HttpPost]
        public void StopTask()
        {
            if (AppConstants.TokenSource != null)
            {
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