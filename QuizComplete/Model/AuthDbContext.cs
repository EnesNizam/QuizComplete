using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizComplete.ViewModels;

namespace QuizComplete.Model
{
    public class AuthDbContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
              => options.UseSqlite(@"DataSource=Quiz.db;");

        public DbSet<Question>? Questions { get; set; }

        public DbSet<QuestionList>? QuestionsLists { get; set; }
    }
}
