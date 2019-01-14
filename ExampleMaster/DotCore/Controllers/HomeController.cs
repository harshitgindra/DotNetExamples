using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace DotCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHubContext<TaskHub> _hubContext;

        public HomeController(IHubContext<TaskHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public async Task StartTask()
        {
            AppConstants.TokenSource = new CancellationTokenSource();
            for (int i = 0; i < 20; i++)
            {
                if (!AppConstants.TokenSource.Token.IsCancellationRequested)
                {
                    await SendUpdates($"Loop:{i}");
                    Thread.Sleep(2000);
                }
                else
                {
                    await SendUpdates($"Loop stopped");
                    break;
                }
            }
        }

        [HttpPost]
        public async Task StopTask()
        {
            if (AppConstants.TokenSource != null)
            {
                await SendUpdates($"Cancel Tasks requested");
                AppConstants.TokenSource.Cancel();
            }
        }

        private async Task SendUpdates(string msg)
        {
            await _hubContext.Clients.All.SendAsync("TaskUpdate", msg);
        }
    }
}