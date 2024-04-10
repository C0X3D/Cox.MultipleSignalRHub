using Cox.ApiExample.DataLayer;
using Cox.ApiExample.DataLayer.Interfaces;
using Cox.SignalRDataModel.Interfaces;
using Cox.SignalRHub;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSignalR(config => { config.EnableDetailedErrors = true; });
        builder.Services.AddSingleton<IClientManagementService, ClientManagementService>();
        builder.Services.AddSingleton<IHubsService, HubsService>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        app.MapHub<NotificationsHub>(nameof(NotificationsHub));

        app.Run();
    }
}