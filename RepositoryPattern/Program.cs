using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Ioc;
using RepositoryImplementation;
using RepositoryPattern.Classes;
using StructureMap;

namespace RepositoryPattern.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<NinjaContext>());
            //  Database.SetInitializer(new NullDatabaseInitializer<DbContext>());

            IContainer ico = Ioc.Initialize();
            var ninjaRepository = ico.GetInstance<IRepository<Ninja>>();
            var clanRepository = ico.GetInstance<IRepository<Clan>>();

            //  InsertTestData(ninjaRepository, clanRepository);

            Console.WriteLine("Ninjas:");
            IEnumerable<Ninja> ninjas = ninjaRepository.All();

            foreach (var ninja in ninjas)
            {
                Console.WriteLine(ninja.Name);
            }

            Console.WriteLine();
            Console.WriteLine("Clans:");

            IEnumerable<Clan> clans = clanRepository.All();
            foreach (var clan in clans)
            {
                Console.WriteLine(clan.ClanName);
            }

            Console.ReadLine();
        }

        private static void InsertTestData(IRepository<Ninja> ninjaRepository, IRepository<Clan> clanRepository)
        {
            const string clanName = "Vermont Clan";
            clanRepository.Add(new Clan { ClanName = clanName });

            Clan clan = clanRepository.FindBy(c => c.ClanName == clanName).FirstOrDefault();

            if (clan != null)
            {
                ninjaRepository.Add(new Ninja
                {
                    Name = "JulieSan",
                    ServedInOniwaban = false,
                    DateOfBirth = new DateTime(1980, 1, 1),
                    ClanId = clan.Id
                });
                var s = new Ninja
                {
                    Name = "SampsonSan",
                    ServedInOniwaban = false,
                    DateOfBirth = new DateTime(2008, 1, 28),
                    ClanId = clan.Id
                };
                ninjaRepository.Add(new Ninja
                {
                    Name = "Leonardo",
                    ServedInOniwaban = false,
                    DateOfBirth = new DateTime(1984, 1, 1),
                    ClanId = clan.Id
                });

                ninjaRepository.Add(new Ninja
                {
                    Name = "Raphael",
                    ServedInOniwaban = false,
                    DateOfBirth = new DateTime(1985, 1, 1),
                    ClanId = clan.Id
                });
            }
        }
    }
}