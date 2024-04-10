using Cox.SignalRDataModel.Interfaces;
using Cox.SignalRHub;

namespace Cox.Example
{
    public class NotificationsHub(IClientManagementService? clientManagement) : GeneralHub<INotificationsHub>(clientManagement)
    {
        public override string GetEventName()
        {
            return nameof(NotificationsHub);
        }
    }

    public interface INotificationsHub
    {
        public Task UpdateNotificationsAsync(object data);
    }
}
