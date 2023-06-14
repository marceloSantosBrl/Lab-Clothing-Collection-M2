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
            BirthDate = new DateTime(1990, 01, 01),
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
            BirthDate = new DateTime(1995, 05, 15),
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
            BirthDate = new DateTime(1975, 11, 15),
            Cpf = null,
            Cnpj = "22.333.444.555-0001",
            PhoneNumber = "+1 (555) 902-3846",
            Email = "bruce.wayne@example.com",
            UserType = UserType.Creator
        };
        
        
        //Collections
        
        
        var collection1 = new
        {
            Id = 1,
            Name = "Autumn Vibes",
            UserId = 1,
            Brand = "Acme Clothing",
            Budget = 5000m,
            LaunchYear = new DateTime(2021, 1, 1),
            Season = Season.Fall,
            SystemActivity = SystemActivity.Active
        };
        var collection2 = new 
        {
            Id = 2,
            Name = "Winter Wonderland",
            UserId = 1,
            Brand = "Snowy Styles",
            Budget = 7000m,
            LaunchYear = new DateTime(2021, 1, 1),
            Season = Season.Winter,
            SystemActivity = SystemActivity.Active
        };
        var collection3 = new
        {
            Id = 3,
            Name = "Spring Bloom",
            UserId = 3,
            Brand = "Floral Fashion",
            Budget = 8000m,
            LaunchYear = new DateTime(2022, 1, 1),
            Season = Season.Spring,
            SystemActivity = SystemActivity.Active
        };
        var collection4 = new
        {
            Id = 4,
            Name = "Summer Breeze",
            UserId = 2,
            Brand = "Beachwear Boutique",
            Budget = 6000m,
            LaunchYear = new DateTime(2022, 1, 1),
            Season = Season.Summer,
            SystemActivity = SystemActivity.Active
        };
        
        //ClothingModels

        var model1 = new
        {
            Id = 1,
            Name = "Beach Shorts",
            ClothingCollectionId = 1,
            ClothingType = ClothingType.Shorts,
            ClothingLayout = ClothingLayout.Plain
        };
        var model2 = new
        {
            Id = 2,
            Name = "Floral Bikini",
            ClothingCollectionId = 2,
            ClothingType = ClothingType.Bikini,
            ClothingLayout = ClothingLayout.Needlework
        };
        var model3 = new
        {
            Id = 3,
            Name = "Leather Purse",
            ClothingCollectionId = 3,
            ClothingType = ClothingType.Purse,
            ClothingLayout = ClothingLayout.DiePressed
        };
        var model4 = new
        {
            Id = 4,
            Name = "Baseball Cap",
            ClothingCollectionId = 4,
            ClothingType = ClothingType.Cap,
            ClothingLayout = ClothingLayout.Plain
        };
        var model5 = new
        {
            Id = 5,
            Name = "Pleated Skirt",
            ClothingCollectionId = 1,
            ClothingType = ClothingType.Skirt,
            ClothingLayout = ClothingLayout.Needlework
        };
        var model6 = new
        {
            Id = 6,
            Name = "Casual Pants",
            ClothingCollectionId = 2,
            ClothingType = ClothingType.Pants,
            ClothingLayout = ClothingLayout.Plain,
        };
        var model7 = new
        {
            Id = 7,
            Name = "Sneakers",
            ClothingCollectionId = 3,
            ClothingType = ClothingType.Shoe,
            ClothingLayout = ClothingLayout.DiePressed
        };

        var person1 = new Person()
        {
            Id = 4,
            Name = "Silvia Lopez",
            Gender = "Female",
            BirthDate = new DateTime(1988, 04, 23),
            Cpf = "444.555.666-77",
            Cnpj = null,
            PhoneNumber = "+1 (555) 202-7634"
        };
        var person2 = new Person()
        {
            Id = 5,
            Name = "Catherine Brown",
            Gender = "Female",
            BirthDate = new DateTime(1985, 03, 12),
            Cpf = "333.444.555-66",
            Cnpj = null,
            PhoneNumber = "+1 (555) 112-3581"
        };
        modelBuilder.Entity<Person>().HasData(person1, person2);
        modelBuilder.Entity<User>().HasData(user1, user2, user3);
        modelBuilder.Entity<ClothingCollection>().HasData(collection1, collection2, collection3, collection4);
        modelBuilder.Entity<ClothingModel>().HasData(model1, model2, model3, model4, model5, model6, model7);
    }
}