namespace Cox.ApiExample.DataLayer.Interfaces
{
    public interface IHubsService
    {
        Task UpdateNotificationsAsync(string userId, object message);
    }
}
