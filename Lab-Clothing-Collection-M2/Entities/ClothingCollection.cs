using System.ComponentModel.DataAnnotations;

namespace Lab_Clothing_Collection_M2.Entities;

public enum Season
{
    Outono,
    Inverno,
    Primavera,
    Verao
}

public enum SystemActivity
{
    Ativa,
    Inativa
}

public class ClothingCollection
{
    [Key] public int Id { get; set; }
    [Required] [MaxLength(150)] public string Name { get; set; }
    [Required] public User User { get; set; }
    [Required] [MaxLength(100)] public string Brand { get; set; }
    [Required] public decimal Budget { get; set; }
    [Required] public DateOnly LaunchYear { get; set; }
    [Required] public Season Season { get; set; }
    [Required] public SystemActivity SystemActivity { get; set; }

    public ClothingCollection(string name, User user, string brand, decimal budget, DateOnly launchYear, Season season,
        SystemActivity systemActivity)
    {
        Name = name;
        User = user;
        Brand = brand;
        Budget = budget;
        LaunchYear = launchYear;
        Season = season;
        SystemActivity = systemActivity;
    }
}