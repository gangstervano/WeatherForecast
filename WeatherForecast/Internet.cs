using System.Net;
using System.IO;

namespace WeatherForecast
{
    class Internet
    {
        static public string GetHtmlPage(string url)
        {
            string HtmlText = string.Empty;
            HttpWebRequest myHttwebrequest = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse myHttpWebresponse = (HttpWebResponse)myHttwebrequest.GetResponse();
            StreamReader strm = new StreamReader(myHttpWebresponse.GetResponseStream());
            HtmlText = strm.ReadToEnd();
            return HtmlText;
        }
    }
}
