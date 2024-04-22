using Microsoft.AspNetCore.SignalR;

namespace SignalR_ServerClient.Hubs;
public class MessageHub : Hub
{
    //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
    public async Task SendMessageAsync(string message, string groupNames)
    {
        #region  Caller 
        //// Sadece Servere bildirim gönderen kullanıcıya bildirim göndermek için
        //await Clients.Caller.SendAsync("receiveMessage", message);
        #endregion
        #region All
        //await Clients.All.SendAsync("receiveMessage", message);
        #endregion
        //await Clients.All.SendAsync("receiveMessage", message);
        #region Others
        //await Clients.Others.SendAsync("receiveMessage", message);
        #endregion

        #region Hub Clients Metotlari
        #region AllExcept
        // AllExcept(connectionIds) => BU id lerden basqa hamiya gonder 
        //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);
        #endregion
        #region Client 
        // sadece bir clienta gedir 
        //Clients.Client(connectionIds.FirstOrDefault()).SendAsync("receiveMessage", message);
        #endregion
        #region Clients
        // birden cox clienta gedir 
        //await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);
        #endregion
        #region Group
        //await Clients.Group(groupName).SendAsync("receiveMessage", message);
        #endregion
        #region GroupExcept
        // Qruup icindeki istisna userler i cixarmaq 
        //await Clients.GroupExcept(groupName, connectionIds).SendAsync("receiveMessage", message);   
        #endregion
        #region Groups
        //await Clients.Groups(groupNames).SendAsync("receiveMessage", message);
        #endregion

        #region OthersInGroup
        await Clients.OthersInGroup(groupNames).SendAsync("receiveMessage", message);


        #endregion
        #endregion
    }
    public override async Task OnConnectedAsync()
    {

        await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);

    }
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
    }


    public async Task addGroup(string connectionId, string groupName)
    {
        await Groups.AddToGroupAsync(connectionId, groupName);
    }


}
