using System.Linq;
using Microsoft.EntityFrameworkCore;
using Parcial1.Entidades;


namespace Parcial1.DAL;

public class Contexto:DbContext
{

    public DbSet<Productos>? Productos { get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source = DATA/Productos.db");
    }
}