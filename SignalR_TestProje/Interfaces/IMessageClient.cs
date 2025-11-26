namespace SignalR_TestProje.Interfaces
{
    public interface IMessageClient
    {
        Task Clients(List<string> clients);

        Task UserConnected(string connectionId);

        Task UserDisconnected(string connectionId);
    }
}
