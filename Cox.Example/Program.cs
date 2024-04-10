using Cox.Example;

internal class Program
{
    private static void Main(string[] args)
    {
        var app = new object();
        app.MapHub<NotificationsHub>("newshub");
    }
}