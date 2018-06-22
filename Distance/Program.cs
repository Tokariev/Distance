using System;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Xml;
using Echovoice.JSON;

namespace Distance
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string API_KEY = "AIzaSyBUx_zft_23-u1J3LTa8d2CIzzuHYOwVy8";
            string country = "DE";
            string PLZ = "74172";

            string url = @"https://maps.googleapis.com/maps/api/geocode/json?components=postal_code:" + PLZ + "|country:" + country + "&key=" + API_KEY;

            WebRequest request = WebRequest.Create(url);

            WebResponse response = request.GetResponse();

            Stream data = response.GetResponseStream();

            StreamReader reader = new StreamReader(data);

            string unParsed = reader.ReadToEnd();

            response.Close();

            JObject jObject = JObject.Parse(unParsed);


            string lat = (string)jObject["results"][0]["geometry"]["location"]["lat"];
            string lng = (string)jObject["results"][0]["geometry"]["location"]["lng"];

            Console.WriteLine("lat : {0},\nlng: {1}", lat, lng);
        }
    }
}
