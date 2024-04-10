using Cox.ApiExample.DataLayer.Interfaces;
using Cox.SignalRDataModel.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Cox.ApiExample.DataLayer
{
    public class HubsService(IHubContext<NotificationsHub, INotificationsHub> notificationsHubContext,
        IClientManagementService clientManagement) : IHubsService
    {
        private readonly IHubContext<NotificationsHub, INotificationsHub> _notificationsHubContext = notificationsHubContext;
        private readonly IClientManagementService _clientManagement = clientManagement;

        public async Task UpdateNotificationsAsync(string userId, object message)
        {
            var clientConnections = _clientManagement.GetClients(userId);
            foreach (var client in clientConnections)
            {
                if (!string.IsNullOrWhiteSpace(client))
                {
                    await _notificationsHubContext.Clients.Clients(client).UpdateNotificationsAsync(message);
                }
            }
        }
    }
}
