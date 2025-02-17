using Angel_Paredes_AP_AP1.Models;
using Microsoft.EntityFrameworkCore;

namespace Angel_Paredes_AP_AP1.DAL
{
    //Contexto
    public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
    {
        public DbSet<Aportes> Aportes { get; set; }
    }

}
