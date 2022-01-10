
using ExamDataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamDataBase;

public class GameDataContext : DbContext
{
    public DbSet<Character> Characters { get; set; }
    public DbSet<Monster> Monsters { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=dndExam;User ID=user1;Password=sasa");
    }
    
}