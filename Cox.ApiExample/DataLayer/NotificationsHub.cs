using Cox.ApiExample.DataLayer.Interfaces;
using Cox.SignalRDataModel;
using Cox.SignalRDataModel.Interfaces;
using Cox.SignalRHub;
using Microsoft.AspNetCore.SignalR;

namespace Cox.ApiExample.DataLayer
{
    public class NotificationsHub : GeneralHub<INotificationsHub>
    {
        public NotificationsHub(IClientManagementService? clientManagement) : base(clientManagement)
        {
            OnNewClientConnected += NotificationsHub_OnNewClientConnected;
        }

        private void NotificationsHub_OnNewClientConnected(object? sender, ConnectionEventArgs e)
        {
            Clients.Clients(e.ConnectionId).UpdateNotificationsAsync($"New Connection {e.ConnectionId}.");
        }

        public override string GetEventName()
        {
            return nameof(NotificationsHub);
        }
    }
}
