namespace csharp_project_4._3___klient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var securityClient = new SecurityService();
            await securityClient.MonitorAndSendDataAsync();
        }
    }
}
