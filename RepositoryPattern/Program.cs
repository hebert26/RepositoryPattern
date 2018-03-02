using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RepositoryPattern.Classes;
using RepositoryPattern.DataModel;

namespace RepositoryPattern.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Database.SetInitializer(new NullDatabaseInitializer<DbContext>());
            /*
             * The job of database initializer is to create the database and the specified tables. When a DbContext type is used to access database for the first time then the database initializer is called.

               The Database.SetInitializer() method does this initialization operation. The following is the method signature(see documentation):
            */
            // InserNinja();
            GetNinjas();

            Console.ReadLine();
        }

        private static void InserNinja()
        {
            using (var dbContexts = new NinjaContext())
            {
                List<Ninja> newNinjas = new List<Ninja>();
                var newNinja1 = new Ninja()
                {
                    Name = "Jose",
                    ServedInOniwaban = false,
                    DateOfBirth = new DateTime(1980, 1, 1),
                    YearOfBirth = new DateTime(1980, 1, 1),
                    ClanId = 1
                };
                newNinjas.Add(newNinja1);

                var newNinja2 = new Ninja()
                {
                    Name = "Anna",
                    ServedInOniwaban = false,
                    DateOfBirth = new DateTime(1980, 1, 1),
                    YearOfBirth = new DateTime(1980, 1, 1),
                    ClanId = 1
                };
                newNinjas.Add(newNinja2);

                var newNinja3 = new Ninja()
                {
                    Name = "David",
                    ServedInOniwaban = false,
                    DateOfBirth = new DateTime(1980, 1, 1),
                    YearOfBirth = new DateTime(1980, 1, 1),
                    ClanId = 1
                };
                newNinjas.Add(newNinja3);

                dbContexts.Database.Log = Console.WriteLine;
                dbContexts.Ninjas.AddRange(newNinjas);
                dbContexts.SaveChanges();
            }
        }

        private static void GetNinjas()
        {
            using (var dbContexts = new NinjaContext())
            {
                IQueryable<Ninja> ninjas = dbContexts.Ninjas.Where(x => x.ClanId == 1);
                foreach (var ninja in ninjas)
                {
                    Console.WriteLine(ninja.Name);
                }
            }
        }
    }
}