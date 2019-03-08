using System.Net;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WeatherForecast
{
    class Internet
    {

        static public string GetHtmlData2(string urlAddress)
        {
            WebClient web = new WebClient();
            string data = web.DownloadString(urlAddress);
            return data;
        }

        static public string GetHtmlData(string urlAddress)
        {
            string data = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);

            if (request.CookieContainer == null)
            {
                request.CookieContainer = new CookieContainer();
            }

            request.CookieContainer.Add(new System.Uri(urlAddress), new Cookie("beget", "begetok"));

            request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/vnd.ms-xpsdocument, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
            request.ContentType = "text/html; charset=utf-8";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.04506.30; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET4.0C; .NET4.0E)";


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }
                data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
            }
            return data;
            
        }
    }
}
