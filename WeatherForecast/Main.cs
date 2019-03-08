using System;
using System.IO;
using System.Windows.Forms;

namespace WeatherForecast
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter outputFile = new StreamWriter("GisMeteo.txt");
            string HtmlText = Internet.GetHtmlPage("https://www.gismeteo.ru/city/daily/4327/");
            outputFile.WriteLine(HtmlText);
        }
    }
}
