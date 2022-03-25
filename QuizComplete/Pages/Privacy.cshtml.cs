using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Net;
using System.Text;

using System.Net.Http;
using System.IO;
using HtmlAgilityPack;
using QuizComplete.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QuizComplete.Pages
{
    [Authorize]
    public class PrivacyModel : PageModel
    {

        private readonly ILogger<PrivacyModel> _logger;
        private readonly List<QuestionList> questionLists;

        [BindProperty]
        public QuestionList Model { get; set; }
       public List<QuestionList> GetLists { get; set; }
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
            var sorubaslik1 = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div/main/div[1]/div[1]/section/div[2]/div[2]/div[1]/div[2]/div[2]").InnerText.ToString();
            var soruaciklama1 = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div/main/div[1]/div[2]/div/div[2]/div[1]/div/div[2]/div[2]").InnerText.ToString();
            var sorubaslik2 = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div/main/div[1]/div[2]/div/div[2]/div[2]/div/div[2]/a/h3").InnerText.ToString();
            var soruaciklama2 = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div/main/div[1]/div[2]/div/div[2]/div[2]/div/div[2]/div[2]").InnerText.ToString();
            var sorubaslik3 = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div/main/div[1]/div[2]/div/div[2]/div[3]/div[2]/div[2]/a/h3").InnerText.ToString();
            var soruaciklama3 = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div/main/div[1]/div[2]/div/div[2]/div[3]/div[2]/div[2]/div[2]").InnerText.ToString();
           

            GetLists = new List<QuestionList>
            {
             new QuestionList { Explanation=soruaciklama1,Header = sorubaslik1},
             new QuestionList {  Explanation=soruaciklama2,Header =sorubaslik2 },
             new QuestionList {  Explanation=soruaciklama3,Header = sorubaslik3 }
            };
        }




    }
}