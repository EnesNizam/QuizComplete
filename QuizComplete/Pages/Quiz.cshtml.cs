using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using QuizComplete.Model;
using QuizComplete.ViewModels;

namespace QuizComplete.Pages
{
    public class QuizModel : PageModel
    {
        private readonly ILogger<PrivacyModel> logger;
        private readonly AuthDbContext authDbContext;
        private readonly IToastNotification toastNotification;

        public QuizModel(ILogger<PrivacyModel> logger, AuthDbContext authDbContext, IToastNotification toastNotification)
        {
            this.logger = logger;
            this.authDbContext = authDbContext;
            this.toastNotification = toastNotification;
        }

        public QuestionList QuestionList { get; set; }
        public List<Question> Questions { get; set; }
        public IActionResult OnGet(int id)
        {
            QuestionList = authDbContext.QuestionsLists.Find(id);

            if(QuestionList == null)
            {
                return NotFound();
            }
            Questions = authDbContext.Questions.ToList().Where(x => x.QuestionListID == id).ToList();
     
            return Page();
        }
    }
}
