using Microsoft.AspNetCore.SignalR;
using SignalR_TestProje.Hubs;

namespace SignalR_TestProje.Business
{
    public class MyBusiness
    {
        readonly IHubContext<ChatHub> _hubContext;

        public MyBusiness(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
