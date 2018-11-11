using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GspNetBegin
{
    class GspNetServer
    {
        public string Domain { get; set; }
        public int Port { get; set; }

        private HttpListener httpListener;

        public GspNetServer(string domain, int port)
        {
            Domain = domain;
            Port = port;
            httpListener = new HttpListener();
            httpListener.Prefixes.Add($"{domain}:{port}/");
        }

        public void Run()
        {
            httpListener.Start();
            while (true)
            {
                var context = httpListener.GetContext();
                Task.Run(() => Process(context));
            }
        }

        private void Process(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            StreamReader reader = new StreamReader(request.InputStream);
            StreamWriter writer = new StreamWriter(response.OutputStream);

            writer.WriteLine("Hello!");

            writer.Close();
        }
    }
}
