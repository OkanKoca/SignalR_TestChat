using Microsoft.AspNetCore.SignalR;

namespace SignalR_TestProje.Hubs
{
    public class MessageHub : Hub
    {
        //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)

        //public async Task SendMessageAsync(string message, string groupName)

        //public async Task SendMessageAsync(string message, string groupName, IEnumerable<string> connectionIds)

        //public async Task SendMessageAsync(string message, IEnumerable<string> groups)
        public async Task SendMessageAsync(string message, string groupName)
        {
            #region Caller
            // Send the message back to the caller only
            //await Clients.Caller.SendAsync("ReceiveMessage", message);
            #endregion

            #region All
            // Send the message to all connected clients
            //await Clients.All.SendAsync("ReceiveMessag
            #endregion

            #region Others
            // Send the message to all clients except the caller
            //await Clients.Others.SendAsync("ReceiveMessage", message);
            #endregion

            #region Client Methods

            #region AllExcept
            // Example: Send the message to all clients except specific connection IDs
            //await Clients.AllExcept(connectionIds).SendAsync("ReceiveMessage", message);
            #endregion

            #region Clients
            // Send the message to specific clients identified by their connection IDs
            //await Clients.Clients(connectionIds).SendAsync("ReceiveMessage", message);
            #endregion

            #region Client
            // Example: Send the message to a single client identified by its connection ID
            //await Clients.Client(connectionIds.First()).SendAsync("ReceiveMessage", message);
            #endregion

            #region Group
            // Example: Send the message to all clients in a specific group
            // Firstly you need to create groups and add clients to a group using Groups.AddToGroupAsync method
            //await Clients.Group(groupName).SendAsync("ReceiveMessage", message);
            #endregion

            #region GroupExcept
            // Example: Send the message to all clients in a group except specific connection IDs

            //await Clients.GroupExcept(groupName, connectionIds).SendAsync("ReceiveMessage", message);
            #endregion

            #region Groups
            // Example: Send the message to multiple groups
            //await Clients.Groups(groups).SendAsync("ReceiveMessage", message);
            #endregion

            #region OthersInGroup
            // Example: Send the message to all clients in a group except the caller
            //await Clients.OthersInGroup(groupName).SendAsync("ReceiveMessage", message);
            #endregion

            #region User
            // Example: Send the message to a specific user identified by their user ID
            //await Clients.User(userId).SendAsync("ReceiveMessage", message);
            #endregion

            #region Users
            // Example: Send the message to multiple users identified by their user IDs
            //await Clients.Users(userIds).SendAsync("ReceiveMessage", message);
            #endregion

            #endregion
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }

        public async Task JoinGroup(string connectionId, string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }
    }
}
