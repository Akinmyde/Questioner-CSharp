using Microsoft.EntityFrameworkCore;

namespace Questioner_CSharp.Models {
  public class QuestionerContext : DbContext {
    public QuestionerContext(DbContextOptions<QuestionerContext> options) : base(options) {

    }
    public DbSet<Users> Users { get; set; }
  }
}