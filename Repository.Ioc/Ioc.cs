﻿using System.Data.Entity;
using RepositoryImplementation;
using RepositoryPattern.Classes;
using RepositoryPattern.DataModel;
using StructureMap;

namespace Repository.Ioc
{
    public static class Ioc
    {
        public static IContainer Initialize()
        {
            return new Container(c =>
            {
                c.Scan(scanner =>
                   {
                       scanner.TheCallingAssembly();
                       scanner.WithDefaultConventions();
                   });
                c.AddRegistry<DefaultRegistry>();
            });
        }
    }

    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            For<DbContext>().Use<NinjaContext>().Transient();
            For<IRepository<Ninja>>().Use<Repository<Ninja>>().Transient();
            For<IRepository<NinjaEquipment>>().Use<Repository<NinjaEquipment>>().Transient();
            For<IRepository<Clan>>().Use<Repository<Clan>>().Transient();
        }
    }
}