using Lab_Clothing_Collection_M2.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab_Clothing_Collection_M2.Context;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        
        //Users
        
        var user1 = new User()
        {
            Id = 1,
            Name = "John Smith",
            Gender = "Male",
            BirthDate = new DateOnly(1990, 01, 01),
            Cpf = "111.222.333-44",
            Cnpj = null,
            PhoneNumber = "+1 (555) 123-4567",
            Email = "john.smith@example.com",
            UserType = UserType.Creator
        };
        var user2 = new User()
        {
            Id = 2,
            Name = "Mary Johnson",
            Gender = "Female",
            BirthDate = new DateOnly(1995, 05, 15),
            Cpf = "222.333.444-55",
            Cnpj = null,
            PhoneNumber = "+1 (555) 987-6543",
            Email = "mary.johnson@example.com",
            UserType = UserType.Creator
        };
        var user3 = new User()
        {
            Id = 3,
            Name = "Bruce Wayne",
            Gender = "Male",
            BirthDate = new DateOnly(1975, 11, 15),
            Cpf = null,
            Cnpj = "22.333.444.555-0001",
            PhoneNumber = "+1 (555) 902-3846",
            Email = "bruce.wayne@example.com",
            UserType = UserType.Creator
        };
        
        
        //Collections
        
        
        var collection1 = new ClothingCollection()
        {
            Id = 1,
            Name = "Autumn Vibes",
            User = user2,
            Brand = "Acme Clothing",
            Budget = 5000m,
            LaunchYear = new DateOnly(2021, 1, 1),
            Season = Season.Fall,
            SystemActivity = SystemActivity.Active
        };
        var collection2 = new ClothingCollection()
        {
            Id = 2,
            Name = "Winter Wonderland",
            User = user1,
            Brand = "Snowy Styles",
            Budget = 7000m,
            LaunchYear = new DateOnly(2021, 1, 1),
            Season = Season.Winter,
            SystemActivity = SystemActivity.Active
        };
        var collection3 = new ClothingCollection()
        {
            Id = 3,
            Name = "Spring Bloom",
            User = user3,
            Brand = "Floral Fashion",
            Budget = 8000m,
            LaunchYear = new DateOnly(2022, 1, 1),
            Season = Season.Spring,
            SystemActivity = SystemActivity.Active
        };
        var collection4 = new ClothingCollection()
        {
            Id = 4,
            Name = "Summer Breeze",
            User = user3,
            Brand = "Beachwear Boutique",
            Budget = 6000m,
            LaunchYear = new DateOnly(2022, 1, 1),
            Season = Season.Summer,
            SystemActivity = SystemActivity.Active
        };
        
        //ClothingModels

        var model1 = new ClothingModel()
        {
            Id = 1,
            Name = "Beach Shorts",
            ClothingCollection = collection1,
            ClothingType = ClothingType.Shorts,
            ClothingLayout = ClothingLayout.Plain
        };
        var model2 = new ClothingModel()
        {
            Id = 2,
            Name = "Floral Bikini",
            ClothingCollection = collection2,
            ClothingType = ClothingType.Bikini,
            ClothingLayout = ClothingLayout.Needlework
        };
        var model3 = new ClothingModel()
        {
            Id = 3,
            Name = "Leather Purse",
            ClothingCollection = collection3,
            ClothingType = ClothingType.Purse,
            ClothingLayout = ClothingLayout.DiePressed
        };
        var model4 = new ClothingModel()
        {
            Id = 4,
            Name = "Baseball Cap",
            ClothingCollection = collection4,
            ClothingType = ClothingType.Cap,
            ClothingLayout = ClothingLayout.Plain
        };
        var model5 = new ClothingModel()
        {
            Id = 5,
            Name = "Pleated Skirt",
            ClothingCollection = collection1,
            ClothingType = ClothingType.Skirt,
            ClothingLayout = ClothingLayout.Needlework
        };
        var model6 = new ClothingModel()
        {
            Id = 6,
            Name = "Casual Pants",
            ClothingCollection = collection2,
            ClothingType = ClothingType.Pants,
            ClothingLayout = ClothingLayout.Plain
        };
        var model7 = new ClothingModel()
        {
            Id = 7,
            Name = "Sneakers",
            ClothingCollection = collection3,
            ClothingType = ClothingType.Shoe,
            ClothingLayout = ClothingLayout.DiePressed
        };
        
        modelBuilder.Entity<ClothingModel>().HasData(model1, model2, model3, model4, model5, model6, model7);
        var person1 = new Person()
        {
            Id = 1,
            Name = "Silvia Lopez",
            Gender = "Female",
            BirthDate = new DateOnly(1988, 04, 23),
            Cpf = "444.555.666-77",
            Cnpj = null,
            PhoneNumber = "+1 (555) 202-7634"
        };
        var person2 = new Person()
        {
            Id = 3,
            Name = "Catherine Brown",
            Gender = "Female",
            BirthDate = new DateOnly(1985, 03, 12),
            Cpf = "333.444.555-66",
            Cnpj = null,
            PhoneNumber = "+1 (555) 112-3581"
        };
        modelBuilder.Entity<Person>().HasData(person1, person2);
    }
}