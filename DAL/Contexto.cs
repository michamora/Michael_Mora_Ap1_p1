using Microsoft.EntityFrameworkCore;
using Parcial1.Entidades;

   
public class Contexto:DbContext
{

    public DbSet<Productos>? Productos { get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = Productos.db");
    }
}