using EtecVeiculos.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EtecVeiculos.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<TipoVeiculo> TipoVeiculos { get; set; }
    public DbSet<Marca> Marca { get; set; }
    public DbSet<Modelo> Modelo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        AppDbSeed appDbSeed = new(modelBuilder);
    }

}
