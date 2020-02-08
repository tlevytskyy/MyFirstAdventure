using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ID_Directory;
using System.Drawing;
using GDIDrawer;

namespace Engine
{
    public static class World
    {
        public static readonly Location[,] MapArray = new Location[10, 10];
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();

        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
            PopulateMapArray();
            PopulateLocations2();
            DrawMapArray();
        }
        
        private static void PopulateItems()
        {
            Items.Add(new Weapon(IDWeapon.RUSTY_SWORD, "Rusty sword", "Rusty swords", 0, 5, IDDamageType.SLASH));
            Items.Add(new Item(IDItem.RAT_TAIL, "Rat tail", "Rat tails"));
            Items.Add(new Item(IDItem.PIECE_OF_FUR, "Piece of fur", "Pieces of fur"));
            Items.Add(new Item(IDItem.SNAKE_FANG, "Snake fang", "Snake fangs"));
            Items.Add(new Item(IDItem.SNAKESKIN, "Snakeskin", "Snakeskins"));
            Items.Add(new Weapon(IDWeapon.CLUB, "Club", "Clubs", 3, 10, IDDamageType.CRUSH));
            Items.Add(new HealingPotion(IDPotion.HEALING_POTION, "Healing potion", "Healing potions", 5));
            Items.Add(new Item(IDItem.SPIDER_FANG, "Spider fang", "Spider fangs"));
            Items.Add(new Item(IDItem.SPIDER_SILK, "Spider silk", "Spider silks"));
            Items.Add(new Item(IDItem.ADVENTURER_PASS, "Adventurer pass", "Adventurer passes"));
        }

        private static void PopulateMonsters()
        {
            Monster rat = new Monster(IDMonster.RAT, "Rat", 5, 30, 10, 3, 3, IDDamageType.SLASH);
            rat.LootTable.Add(new LootItem(ItemByID(IDItem.RAT_TAIL), 75, false));
            rat.LootTable.Add(new LootItem(ItemByID(IDItem.PIECE_OF_FUR), 75, true));

            Monster snake = new Monster(IDMonster.SNAKE, "Snake", 5, 30, 10, 3, 3, IDDamageType.CRUSH);
            snake.LootTable.Add(new LootItem(ItemByID(IDItem.SNAKE_FANG), 75, false));
            snake.LootTable.Add(new LootItem(ItemByID(IDItem.SNAKESKIN), 75, true));

            Monster giantSpider = new Monster(IDMonster.GIANT_SPIDER, "Giant spider", 20, 50, 40, 10, 10, IDDamageType.PIERCE);
            giantSpider.LootTable.Add(new LootItem(ItemByID(IDItem.SPIDER_FANG), 75, true));
            giantSpider.LootTable.Add(new LootItem(ItemByID(IDItem.SPIDER_SILK), 25, false));

            Monsters.Add(rat);
            Monsters.Add(snake);
            Monsters.Add(giantSpider);
        }

        private static void PopulateQuests()
        {
            Quest clearAlchemistGarden =
                new Quest(
                    IDQuest.CLEAR_ALCHEMIST_GARDEN,
                    "Clear the alchemist's garden",
                    "Kill rats in the alchemist's garden and bring back 3 rat tails. You will receive a healing potion and 10 gold pieces.", 20, 10);

            clearAlchemistGarden.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(IDItem.RAT_TAIL), 3));

            clearAlchemistGarden.RewardItem = ItemByID(IDPotion.HEALING_POTION);

            Quest clearFarmersField =
                new Quest(
                    IDQuest.CLEAR_FARMERS_FIELD,
                    "Clear the farmer's field",
                    "Kill snakes in the farmer's field and bring back 3 snake fangs. You will receive an adventurer's pass and 20 gold pieces.", 20, 20);

            clearFarmersField.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(IDItem.SNAKE_FANG), 3));

            clearFarmersField.RewardItem = ItemByID(IDItem.ADVENTURER_PASS);

            Quests.Add(clearAlchemistGarden);
            Quests.Add(clearFarmersField);
        }

        private static void PopulateLocations()
        {
            // Create each location
            Location home = new Location(IDLocation.HOME1, "Home", "Your house. You really need to clean up the place.");

            Location townSquare = new Location(IDLocation.TOWN_SQUARE1, "Town square", "You see a fountain.");

            Location alchemistHut = new Location(IDLocation.ALCHEMIST_HUT1, "Alchemist's hut", "There are many strange plants on the shelves.");
            alchemistHut.QuestAvailableHere = QuestByID(IDQuest.CLEAR_ALCHEMIST_GARDEN);

            Location alchemistsGarden = new Location(IDLocation.ALCHEMISTS_GARDEN1, "Alchemist's garden", "Many plants are growing here.");
            alchemistsGarden.MonsterLivingHere = MonsterByID(IDMonster.RAT);

            Location farmhouse = new Location(IDLocation.FARMHOUSE1, "Farmhouse", "There is a small farmhouse, with a farmer in front.");
            farmhouse.QuestAvailableHere = QuestByID(IDQuest.CLEAR_FARMERS_FIELD);

            Location farmersField = new Location(IDLocation.FARM_FIELD1, "Farmer's field", "You see rows of vegetables growing here.");
            farmersField.MonsterLivingHere = MonsterByID(IDMonster.SNAKE);

            Location guardPost = new Location(IDLocation.GUARD_POST1, "Guard post", "There is a large, tough-looking guard here.", ItemByID(IDItem.ADVENTURER_PASS));

            Location bridge = new Location(IDLocation.BRIDGE1, "Bridge", "A stone bridge crosses a wide river.");

            Location spiderField = new Location(IDLocation.SPIDER_FIELD1, "Forest", "You see spider webs covering covering the trees in this forest.");
            spiderField.MonsterLivingHere = MonsterByID(IDMonster.GIANT_SPIDER);

            // Add the locations to the static list
            Locations.Add(home);
            Locations.Add(townSquare);
            Locations.Add(guardPost);
            Locations.Add(alchemistHut);
            Locations.Add(alchemistsGarden);
            Locations.Add(farmhouse);
            Locations.Add(farmersField);
            Locations.Add(bridge);
            Locations.Add(spiderField);
        }

        public static Item ItemByID(int id)
        {
            foreach (Item item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }

        public static Monster MonsterByID(int id)
        {
            foreach (Monster monster in Monsters)
            {
                if (monster.ID == id)
                {
                    return monster;
                }
            }

            return null;
        }

        public static Quest QuestByID(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.ID == id)
                {
                    return quest;
                }
            }

            return null;
        }

        public static Location LocationByCords(int[] cords)
        {
            foreach (Location location in Locations)
            {
                if (location.Coordinates.SequenceEqual(cords))
                {
                    return location;
                }
            }

            return null;
        }
        public static void PopulateMapArray()
        {
          
            int[] cordarray = new int[2] { 0, 0 };

            for (int row = 0; row < MapArray.GetLength(0); row++)
            {
                for (int columb = 0; columb < MapArray.GetLength(1); columb++)
                {
                    foreach (Location locals in Locations)
                    {
                        if (locals.Coordinates.SequenceEqual(cordarray))
                        {
                            MapArray[cordarray[0], cordarray[1]] = locals;
                        }
                    }
                    cordarray[1]++;




                }
                cordarray[1] = 0;
                cordarray[0]++;



            }

        }
        public static void DrawMapArray()
        {
            CDrawer Canvas = new CDrawer(500,500);
            Canvas.Scale = 50;
            int[] cordarray = new int[2] { 0, 0 };
            for (int row = 0; row < MapArray.GetLength(0); row++)
            {
                for (int columb = 0; columb < MapArray.GetLength(1); columb++)
                {
                    foreach (Location locals in Locations)
                    {
                        if (locals.Coordinates.SequenceEqual(cordarray))
                        {
                            Canvas.SetBBScaledPixel(row, columb, Color.Red);
                        }
                    }
                    
                    cordarray[1]++;
                }
                cordarray[1] = 0;
                cordarray[0]++;
            }
        }

        private static void PopulateLocations2()
        {
            foreach (Location local in Locations)
            {
                if (MapArray[local.Coordinates[0], local.Coordinates[1] - 1] != null)
                {
                    local.LocationToNorth = MapArray[local.Coordinates[0], local.Coordinates[1] - 1];
                }
                if (MapArray[local.Coordinates[0], local.Coordinates[1] + 1] != null)
                {
                    local.LocationToSouth = MapArray[local.Coordinates[0], local.Coordinates[1] + 1];
                }
                if (MapArray[local.Coordinates[0] + 1, local.Coordinates[1]] != null)
                {
                    local.LocationToEast = MapArray[local.Coordinates[0] + 1, local.Coordinates[1]];
                }
                if (MapArray[local.Coordinates[0] - 1, local.Coordinates[1]] != null)
                {
                    local.LocationToWest = MapArray[local.Coordinates[0] - 1, local.Coordinates[1]];
                }

            }
        }
    }
}