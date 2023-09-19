using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace code.id.Test_AXA.Utility
{
    public class Request
{
    public static T RequestJsonGet<T>(string endpoint, Dictionary<string, string> header, string contentType = "text/json")
    {

        T response;
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(endpoint);
        httpWebRequest.ContentType = contentType;

        try
        {
            foreach (var v in header)
            {
                httpWebRequest.Headers.Add(v.Key, v.Value);
            }
            httpWebRequest.Method = "GET";

            //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //{
            //    streamWriter.Write(json);
            //}

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string responseText = "";
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                responseText = streamReader.ReadToEnd();
                response = JsonConvert.DeserializeObject<T>(responseText);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(string.Format("URL: {0}  Message: {1}", endpoint, ex.Message));
        }


        return response;
    }
}
}
