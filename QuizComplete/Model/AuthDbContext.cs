using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace QuizComplete.Model
{
    public class AuthDbContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
              => options.UseSqlite(@"DataSource=Quiz.db;");
    }
}
