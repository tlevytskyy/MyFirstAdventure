using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class LivingCreature
    {
        public double CurrentHitPoints;
        public double MaximumHitPoints;

        public LivingCreature(double currenthp, double maxhp)
        {
            CurrentHitPoints = currenthp;
            MaximumHitPoints = maxhp;

        }
    }
}
