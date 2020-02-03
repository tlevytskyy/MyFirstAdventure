using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Monster
    {
        public int ID;
        public string Name;
        public double MaximumDamage;
        public int RewardExperiencePoints;
        public int RewardGold;
        public int Weakness;
        public List<LootItem> LootTable;
        public double CurrentHitPoints;
        public double MaximumHitPoints;

        public Monster(int id, string name, double maxdamage, int rewardexp, int rewardgold, double currenthp, double maxhp, int weakness)
        {
            ID = id;
            Name = name;
            MaximumDamage = maxdamage;
            CurrentHitPoints = currenthp;
            MaximumHitPoints = maxhp;
            Weakness = weakness;

            RewardExperiencePoints = rewardexp;
            RewardGold = rewardgold;
            LootTable = new List<LootItem>();


        }
        public Monster(int id, string name, double maxdamage, int rewardexp, int rewardgold, double currenthp, double maxhp)
        {
            ID = id;
            Name = name;
            MaximumDamage = maxdamage;
            CurrentHitPoints = currenthp;
            MaximumHitPoints = maxhp;

            RewardExperiencePoints = rewardexp;
            RewardGold = rewardgold;
            LootTable = new List<LootItem>();


        }
        public static bool IsWeakTo(int monsterweakness, int damagetype)
        {
            bool weakness = false;
            while (monsterweakness != 0)
            {
                if (monsterweakness == damagetype)
                {
                    weakness = true;
                    return weakness;
                }
                else
                    return weakness;
            }
            return weakness;
        }
    }
}
