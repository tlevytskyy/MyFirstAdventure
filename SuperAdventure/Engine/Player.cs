using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ID_Directory;

namespace Engine
{
    public class Player
    {
        public int Gold;
        public int ExperiencePoints;
        public int Level
        {
            get { return ((ExperiencePoints / 100) + 1); }
        }
        public double CurrentHitPoints;

        public double MaximumHitPoints;
        public int Strength;
        public int Dexterity;
        public int Intelligence;
        public int Class;
        public int StatLevel = 1;
        public int BonusHP;

        public Location CurrentLocation;
        public List<InventoryItem> Inventory;
        public List<PlayerQuest> Quests;

        public Player(int currentHitPoints, int maximumHitPoints, int gold, int experiencePoints)
        {
            Gold = gold;
            ExperiencePoints = experiencePoints;
            CurrentHitPoints = currentHitPoints;
            StatLevel = -1;
            Class = IDClass.COMMONER;
            UpdateAllStats();

            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();
        }

        public bool HasRequiredItemToEnterThisLocation(Location location)
        {
            if (location.ItemRequiredToEnter == null)
            {
                // There is no required item for this location, so return "true"
                return true;
            }

            // See if the player has the required item in their inventory
            foreach (InventoryItem ii in Inventory)
            {
                if (ii.Details.ID == location.ItemRequiredToEnter.ID)
                {
                    // We found the required item, so return "true"
                    return true;
                }
            }

            // We didn't find the required item in their inventory, so return "false"
            return false;
        }

        public bool HasThisQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quests)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CompletedThisQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quests)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    return playerQuest.IsCompleted;
                }
            }

            return false;
        }

        public bool HasAllQuestCompletionItems(Quest quest)
        {
            // See if the player has all the items needed to complete the quest here
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                bool foundItemInPlayersInventory = false;

                // Check each item in the player's inventory, to see if they have it, and enough of it
                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.ID == qci.Details.ID) // The player has the item in their inventory
                    {
                        foundItemInPlayersInventory = true;

                        if (ii.Quantity < qci.Quantity) // The player does not have enough of this item to complete the quest
                        {
                            return false;
                        }
                    }
                }

                // The player does not have any of this quest completion item in their inventory
                if (!foundItemInPlayersInventory)
                {
                    return false;
                }
            }

            // If we got here, then the player must have all the required items, and enough of them, to complete the quest.
            return true;
        }

        public void RemoveQuestCompletionItems(Quest quest)
        {
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.ID == qci.Details.ID)
                    {
                        // Subtract the quantity from the player's inventory that was needed to complete the quest
                        ii.Quantity -= qci.Quantity;
                        break;
                    }
                }
            }
        }

        public void AddItemToInventory(Item itemToAdd)
        {
            foreach (InventoryItem ii in Inventory)
            {
                if (ii.Details.ID == itemToAdd.ID)
                {
                    // They have the item in their inventory, so increase the quantity by one
                    ii.Quantity++;

                    return; // We added the item, and are done, so get out of this function
                }
            }

            // They didn't have the item, so add it to their inventory, with a quantity of 1
            Inventory.Add(new InventoryItem(itemToAdd, 1));
        }

        public void MarkQuestCompleted(Quest quest)
        {
            // Find the quest in the player's quest list
            foreach (PlayerQuest pq in Quests)
            {
                if (pq.Details.ID == quest.ID)
                {
                    // Mark it as completed
                    pq.IsCompleted = true;

                    return; // We found the quest, and marked it complete, so get out of this function
                }
            }
        }
        public void UpdateMaxHP()
        {
            MaximumHitPoints = 10 * Level + BonusHP;

        }

        public void UpdateStrength()
        {
            if (Class == IDClass.COMMONER)
            {
                Strength = 10 + 1 * Level;
            }
            else if (Class == IDClass.WARRIOR)
            {
                Strength = 10 + 3 * Level;
            }
            else if (Class == IDClass.ROGUE)
            {
                Strength = 10 + 1 * Level;
            }
            else if (Class == IDClass.MAGE)
            {
                Strength = 10 + 1 * Level;
            }

        }

        public void UpdateDexterity()
        {
            if (Class == IDClass.COMMONER)
            {
                Dexterity = 10 + 1 * Level;
            }
            else if (Class == IDClass.WARRIOR)
            {
                Dexterity = 10 + 1 * Level;
            }
            else if (Class == IDClass.ROGUE)
            {
                Dexterity = 10 + 3 * Level;
            }
            else if (Class == IDClass.MAGE)
            {
                Dexterity = 10 + 1 * Level;
            }


        }

        public void UpdateIntelligence()
        {
            if (Class == IDClass.COMMONER)
            {
                Intelligence = 10 + 1 * Level;
            }
            else if (Class == IDClass.WARRIOR)
            {
                Intelligence = 10 + 1 * Level;
            }
            else if (Class == IDClass.ROGUE)
            {
                Intelligence = 10 + 1 * Level;
            }
            else if (Class == IDClass.MAGE)
            {
                Intelligence = 10 + 3 * Level;
            }

        }
        public void UpdateAllStats()
        {
            if (StatLevel != Level)
            {
                UpdateMaxHP();
                UpdateStrength();
                UpdateDexterity();
                UpdateIntelligence();
                StatLevel = Level;

            }
        }
    }
}