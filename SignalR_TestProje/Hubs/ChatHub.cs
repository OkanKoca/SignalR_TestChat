using Microsoft.AspNetCore.SignalR;
using SignalR_TestProje.Interfaces;

namespace SignalR_TestProje.Hubs
{
    public class ChatHub : Hub<IMessageClient>
    {
        static List<string> clients = new List<string>();
        //public async Task SendMessageAsync(string message)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", message);
        //}

        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            //await Clients.All.SendAsync("clients", clients);
            await Clients.All.Clients(clients);
            //await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
            await Clients.All.UserConnected(Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clients.Remove(Context.ConnectionId);
            //await Clients.All.SendAsync("clients", clients);
            await Clients.All.Clients(clients);
            //await Clients.All.SendAsync("UserDisconnected", Context.ConnectionId);
            await Clients.All.UserDisconnected(Context.ConnectionId);
        }
    } 
}
