using System;
using System.Collections.Generic;
using Microsoft.Build.Framework;
using RepositoryPattern.Classes.Enums;

namespace RepositoryPattern.Classes
{
    public abstract class EntityBase
    {
        public int Id { get; protected set; }
    }

    public class Ninja : EntityBase
    {
        public string Name { get; set; }
        public bool ServedInOniwaban { get; set; }
        public Clan Clan { get; set; }
        public int ClanId { get; set; }
        public List<NinjaEquipment> EquipmentOwned { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class Clan : EntityBase
    {
        public string ClanName { get; set; }
        public List<Ninja> Ninjas { get; set; }
    }

    public class NinjaEquipment : EntityBase
    {
        public string Name { get; set; }
        public EquipmentType Type { get; set; }

        [Required]
        public Ninja Ninja { get; set; }
    }
}