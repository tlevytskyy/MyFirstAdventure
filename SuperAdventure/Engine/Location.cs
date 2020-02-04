using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Location
    {
        public int[] Coordinates { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Item ItemRequiredToEnter;
        public Quest QuestAvailableHere;
        public Monster MonsterLivingHere;
        public Location LocationToNorth;
        public Location LocationToEast;
        public Location LocationToSouth;
        public Location LocationToWest;
        public Location(int[] coordinates, string name, string description, Item itemrequiredtoenter = null,
            Quest questavailablehere = null, Monster monsterlivinghere = null)
        {
            Coordinates = coordinates;
            Name = name;
            Description = description;
            ItemRequiredToEnter = itemrequiredtoenter;
            QuestAvailableHere = questavailablehere;
            MonsterLivingHere = monsterlivinghere;


        }
    }
}
