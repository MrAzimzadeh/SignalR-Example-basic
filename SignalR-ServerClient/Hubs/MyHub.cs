using Microsoft.AspNetCore.SignalR;
using SignalR_ServerClient.Interfaces;

namespace SignalR_ServerClient.Hubs;
public class MyHub : Hub<IMessageClient>
{

    static List<string> clients = new List<string>();

    public override async Task OnConnectedAsync()
    {

        clients.Add(Context.ConnectionId);
        //await Clients.All.SendAsync("clients", clients);
        //await Clients.All.SendAsync("userJoined", Context.ConnectionId);
        await Clients.All.Clients(clients);
        await Clients.All.UserJoined(Context.ConnectionId);
    }
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        clients.Remove(Context.ConnectionId);
        //await Clients.All.SendAsync("clients", clients);
        //await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
        await Clients.All.Clients(clients);
        await Clients.All.UserLeaved(Context.ConnectionId);
    }

}
