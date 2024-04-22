using Microsoft.AspNetCore.SignalR;
using SignalR_ServerClient.Hubs;

namespace SignalR_ServerClient.Business;
public class MyBusiness
{
    readonly IHubContext<MyHub> _hubContext;

    public MyBusiness(IHubContext<MyHub> hubContext)
    {
        _hubContext = hubContext;
    }
    public async Task SendMessageAsync(string message)
    {
        await _hubContext.Clients.All.SendAsync(method: "receiveMessage", message);
    }

}

