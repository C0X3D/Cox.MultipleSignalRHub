using Cox.ApiExample.DataLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cox.ApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SameUserMultipleClientsNotification(IHubsService hubsService) : ControllerBase
    {
        private readonly IHubsService _hubsService = hubsService;

        [HttpPost]
        public async Task<ActionResult<object>> UpdateAllClientClients([FromQuery] string clientId,[FromBody] object notification)
        {
            await _hubsService.UpdateNotificationsAsync(clientId, notification);
            return Ok(new
            {
                Response = $"Notification has been set to all {clientId} clients!"
            });
        }
    }
}
