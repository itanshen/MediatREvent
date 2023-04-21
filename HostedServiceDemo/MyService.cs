namespace HostedServiceDemo
{
    public class MyService : BackgroundService
    {
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("running");
                await File.WriteAllTextAsync("d:/123.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), stoppingToken);
                await Task.Delay(10000);
            }
        }
    }
}
