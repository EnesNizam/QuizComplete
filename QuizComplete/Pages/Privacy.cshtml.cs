using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Net;
using System.Text;

using System.Net.Http;
using System.IO;
using HtmlAgilityPack;

namespace QuizComplete.Pages
{
    [Authorize]
    public class PrivacyModel : PageModel
    {

        private readonly ILogger<PrivacyModel> _logger;


        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
            String html; // yeni bir html oluşturduk.
            Uri url; // uri url nesnemizi tanımladık.
            url = new Uri("https://www.wired.com/"); // gonderilenurl yi uri ye attık
            WebClient client = new WebClient(); //webclient açtık
            client.Encoding = Encoding.UTF8; // ve clienti utf8 e kodladık.
            html = client.DownloadString(url); // url nin html kodlarını html stringine attık
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument(); //doküman oluşturduk.
            doc.LoadHtml(html); // tüm html kodlarını doc a yükledik
            var deneme = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div/main/div[1]/div[1]/section/div[2]/div[2]/div[1]/div[2]/div[2]").InnerText.ToString();
            Console.Write(deneme);
        }
    }
}