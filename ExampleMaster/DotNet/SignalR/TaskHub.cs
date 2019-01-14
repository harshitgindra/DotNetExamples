using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace DotNet.SignalR
{
    [HubName("TaskHub")]
    public class TaskHub : Hub
    {
        public static void TaskUpdate(string msg)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<TaskHub>();
            hubContext.Clients.All.taskUpdate(msg);
        }
    }
}