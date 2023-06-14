using Lab_Clothing_Collection_M2.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab_Clothing_Collection_M2.Context;

public class ClothingContext: DbContext
{
    public DbSet<ClothingCollection> ClothingContexts { get; set; }
    public DbSet<ClothingModel> ClothingModels { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<User> Users { get; set; }

    private readonly IConfiguration _configuration;

    public ClothingContext(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new Exception("Configuração não encontrada");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();
    }
}