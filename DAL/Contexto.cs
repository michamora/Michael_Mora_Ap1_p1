using Microsoft.EntityFrameworkCore;


public class Contexto:DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=Data\Name.db");
    }
}