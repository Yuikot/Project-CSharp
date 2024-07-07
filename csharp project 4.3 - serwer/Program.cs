using System.Net;
using csharp_project_4._3___serwer;

class Program
{
    static void Main(string[] args)
    {
        var securityServer = new SecurityServer();

        using (var listener = new HttpListener())
        {
            listener.Prefixes.Add("http://localhost:8080/");

            try
            {
                listener.Start();
                Console.WriteLine("Security server started. Waiting for connections...");

                while (true)
                {
                    var context = listener.GetContext();

                    Task.Run(() =>
                    {
                        securityServer.HandleClientRequest(context);
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting server: {ex.Message}");
            }
        }
    }
}