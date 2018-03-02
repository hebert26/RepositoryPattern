using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Repository.Ioc;
using RepositoryImplementation;
using RepositoryPattern.Classes;
using RepositoryPattern.DataModel;
using StructureMap;

namespace RepositoryPattern.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Database.SetInitializer(new NullDatabaseInitializer<DbContext>());

            IContainer ico = Ioc.Initialize();
            var repo = ico.GetInstance<IRepository<Ninja>>();
            Console.WriteLine("Ninjas:");
            IEnumerable<Ninja> ninjas = repo.All();

            foreach (var ninja in ninjas)
            {
                Console.WriteLine(ninja.Name);
            }

            Console.WriteLine();
            Console.WriteLine("Equipments:");

            var repo2 = ico.GetInstance<IRepository<NinjaEquipment>>();
            IEnumerable<NinjaEquipment> ninjaEquipments = repo2.All();
            foreach (var equiment in ninjaEquipments)
            {
                Console.WriteLine(equiment.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Clans:");
            var repo3 = ico.GetInstance<IRepository<Clan>>();
            IEnumerable<Clan> clans = repo3.All();
            foreach (var clan in clans)
            {
                Console.WriteLine(clan.ClanName);
            }

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