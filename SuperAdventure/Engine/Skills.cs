using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Skills
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaximumDamage;
        public int MinimumDamage;
        public int CoolDown;
        public int NumberOfAttacks = 1;
        public int DotDamage;
        public int DotDuration;
        public bool Stun;
        public int StunDuration;
        public int DamageType;

        public Skills(int id, string name, int maxdamage, int mindamage,int cooldown,int damagetype)
        {
            ID = id;
            Name = name;
            MaximumDamage = maxdamage;
            MinimumDamage = mindamage;
            CoolDown = cooldown;
            DamageType = damagetype;

        }
        public Skills(int id, string name, int maxdamage, int mindamage, int numberofattacks, int cooldown, int damagetype)
        {
            ID = id;
            Name = name;
            MaximumDamage = maxdamage;
            MinimumDamage = mindamage;
            NumberOfAttacks = numberofattacks;
            CoolDown = cooldown;
            DamageType = damagetype;
        }
        public Skills(int id, string name, int maxdamage, int mindamage, int dotduration, int dotdamage, int cooldown, int damagetype)
        {
            ID = id;
            Name = name;
            MaximumDamage = maxdamage;
            MinimumDamage = mindamage;
            DotDamage = dotdamage;
            DotDuration = dotduration;
            CoolDown = cooldown;
            DamageType = damagetype;
        }
        public Skills(int id, string name, int maxdamage, int mindamage, bool stun, int stunduration, int cooldown, int damagetype)
        {
            ID = id;
            Name = name;
            MaximumDamage = maxdamage;
            MinimumDamage = mindamage;
            Stun = stun;
            StunDuration = stunduration;
            CoolDown = cooldown;
            DamageType = damagetype;
        }
    }
}
