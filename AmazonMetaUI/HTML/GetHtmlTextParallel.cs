using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AmazonMetaUI.HTML
{
    public static class GetHtmlTextParallel
    {
        public static List<string> getHtml2(string x)
        {
            WebRequest request = WebRequest.Create(x);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            //Console.WriteLine(responseFromServer);
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();

            return CleanHtml.GetCommentsTitlesParallel(responseFromServer);

        }
    }
}
