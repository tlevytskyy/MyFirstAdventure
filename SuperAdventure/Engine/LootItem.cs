using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class LootItem
    {
        public Item Details;
        public int DropPercentage;
        public bool IsDefaultItem;

        public LootItem(Item details, int droppercentage, bool isdefaultitem)
        {
            Details = details;
            DropPercentage = droppercentage;
            IsDefaultItem = isdefaultitem;

        }


    }
}
