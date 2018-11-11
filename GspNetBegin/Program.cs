using System;

namespace GspNetBegin
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new GspNetServer("http://+", 8080);
            server.Run();
        }
    }
}
