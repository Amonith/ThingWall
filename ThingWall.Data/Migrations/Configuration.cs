namespace ThingWall.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ThingWall.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ThingWall.Data.DataContext context)
        {
            //PROTIP: tutaj mo�na wype�ni� baz� danych wst�pnymi danymi
            //UWAGA: trzeba sprawdza�, czy dany rekord ju� istnieje, Seed uruchamiany jest po ka�dej migracji

            var examples = new List<ExampleItem>()
            {
                new ExampleItem() { Name = "Test 1" },
                new ExampleItem() { Name = "Test 2" },
                new ExampleItem() { Name = "Test 3" }
            };

            //PROTIP: mechanizm u�ytkownik�w dostarza ASP.NET Identity
            //klasa UserManager pozwala troch� �atwiej ich ogarn��
            var userManager = new Microsoft.AspNet.Identity.UserManager<User>(new UserStore<User>(context));

            var testUser = userManager.FindByEmail("test@test.pl");
            if(testUser == null)
            {
                var hasher = new PasswordHasher();

                testUser = new User()
                {
                    UserName = "test",
                    Email = "test@test.pl",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword("test")
                };

                userManager.Create(testUser);
            }

            foreach(var example in examples)
            {
                if(!context.ExampleItems.Any(i => i.Name == example.Name))
                {
                    //PROTIP: ustawianie klucza obcego wystarczy do "zrobienia" relacji
                    example.OwnerId = testUser.Id;
                    context.ExampleItems.Add(example);
                }
            }

            //PROTIP: SaveChanges poza p�tl� wrzuca wszystkie zmiany w kolejce jednym zapytaniem
            context.SaveChanges();
        }
    }
}
