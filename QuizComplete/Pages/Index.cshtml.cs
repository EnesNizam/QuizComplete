using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizComplete.Model;
using QuizComplete.ViewModels;

namespace QuizComplete.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AuthDbContext authDbContext;

        [BindProperty]
        public List<QuestionList> questionLists { get; set; }
        public IndexModel(ILogger<IndexModel> logger, AuthDbContext authDbContext)
        {
            _logger = logger;
            this.authDbContext = authDbContext;
        }

        public void OnGet()
        {
            questionLists = this.authDbContext.QuestionsLists.ToList();
        }
        public IActionResult OnGetDelete(int id)
        {
            authDbContext.Remove(authDbContext.QuestionsLists.Find(id));
            authDbContext.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}