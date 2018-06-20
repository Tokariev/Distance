using System;
using System.Net;
using System.IO;

namespace Distance
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Create a request using a URL that can receive a post.   
            WebRequest request = WebRequest.Create("http://127.0.0.1:5000/ ");
            // Set the Method property of the request to POST.  
            request.Method = "POST";

            WebResponse response = request.GetResponse();

            Stream data = response.GetResponseStream();
            StreamReader reader = new StreamReader(data);
            string responseFromServer = reader.ReadToEnd();

            Console.WriteLine(responseFromServer);
        }
    }
}
