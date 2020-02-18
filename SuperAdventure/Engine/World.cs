using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ID_Directory;
using System.Drawing;
using GDIDrawer;

//ARREN WAS HERE!!
namespace Engine
{
    public static class World
    {
        public static CDrawer MiniMap = new CDrawer(375, 375);
        
        public static readonly Location[,] MapArray = new Location[20, 20];
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();
        public static readonly List<Skills> Skills = new List<Skills>();
        public static readonly List<Weapon> Weapons = new List<Weapon>();

        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
            PopulateMapArray();
            PopulateLocations2();
            PopulateSkills();
            MiniMap.Scale = 75;
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

            Weapons.Add(new Weapon(IDWeapon.RUSTY_SWORD, "Rusty sword", "Rusty swords", 0, 5, IDDamageType.SLASH));
            Weapons.Add(new Weapon(IDWeapon.CLUB, "Club", "Clubs", 3, 10, IDDamageType.CRUSH));
        }

        private static void PopulateMonsters()
        {
            Monster rat = new Monster(IDMonster.RAT, "Rat", 5, 30, 10, 3, 3, IDDamageType.SLASH);
            rat.LootTable.Add(new LootItem(ItemByID(IDItem.RAT_TAIL), 75, false));
            rat.LootTable.Add(new LootItem(ItemByID(IDItem.PIECE_OF_FUR), 75, true));

            Monster snake = new Monster(IDMonster.SNAKE, "Snake", 5, 30, 10, 3, 3, IDDamageType.CRUSH);
            snake.LootTable.Add(new LootItem(ItemByID(IDItem.SNAKE_FANG), 75, false));
            snake.LootTable.Add(new LootItem(ItemByID(IDItem.SNAKESKIN), 75, true));

            Monster giantSpider = new Monster(IDMonster.GIANT_SPIDER, "Giant spider", 20, 50, 40, 100, 100, IDDamageType.PIERCE);
            giantSpider.LootTable.Add(new LootItem(ItemByID(IDItem.SPIDER_FANG), 75, true));
            giantSpider.LootTable.Add(new LootItem(ItemByID(IDItem.SPIDER_SILK), 25, false));

            Monster giantweasel = new Monster(IDMonster.GIANT_WEASEL, "Giant Weasel with a fedora.", 10, 100, 200, 40, 40);

            Monsters.Add(rat);
            Monsters.Add(snake);
            Monsters.Add(giantSpider);
            Monsters.Add(giantweasel);
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

            Location path1 = new Location(IDLocation.FARMPATH1, "Path", "A Dirt Path.");
            Location path2 = new Location(IDLocation.FARMPATH2, "Path", "A Dirt Path.");
            Location path3 = new Location(IDLocation.FARMPATH3, "Path", "A Dirt Path.");
            Location path4 = new Location(IDLocation.FARMPATH4, "Path", "A Dirt Path.");
            Location path5 = new Location(IDLocation.FARMPATH5, "Path", "A Dirt Path.");
            Location path6 = new Location(IDLocation.FARMPATH6, "Path", "A Dirt Path.");
            Location path7 = new Location(IDLocation.FARMPATH7, "Path", "A Dirt Path.");
            Location path8 = new Location(IDLocation.FARMPATH8, "Path", "A Dirt Path.");
            Location path9 = new Location(IDLocation.FARMPATH9, "Path", "A Dirt Path.");
            Location path10 = new Location(IDLocation.FARMPATH10, "Path", "A Dirt Path.");
            Location path11 = new Location(IDLocation.FARMPATH11, "Path", "A Dirt Path.");
            Location path12 = new Location(IDLocation.FARMPATH12, "Path", "A Dirt Path.");
            Location path13 = new Location(IDLocation.FARMPATH13, "Path", "A Dirt Path.");
            Location path14 = new Location(IDLocation.FARMPATH14, "Path", "A Dirt Path.");


            Location field1 = new Location(IDLocation.FARMFIELD1, "Field", "A field of wheat.");
            field1.MonsterLivingHere = MonsterByID(IDMonster.RAT);
            Location field2 = new Location(IDLocation.FARMFIELD2, "Field", "A field of wheat.");
            field2.MonsterLivingHere = MonsterByID(IDMonster.RAT);
            Location field3 = new Location(IDLocation.FARMFIELD3, "Field", "A field of wheat.");
            field3.MonsterLivingHere = MonsterByID(IDMonster.RAT);
            Location field4 = new Location(IDLocation.FARMFIELD4, "Field", "A field of wheat.");
            field4.MonsterLivingHere = MonsterByID(IDMonster.RAT);
            Location field5 = new Location(IDLocation.FARMFIELD5, "Field", "A field of wheat.");
            field5.MonsterLivingHere = MonsterByID(IDMonster.RAT);
            Location field6 = new Location(IDLocation.FARMFIELD6, "Field", "A field of wheat.");
            field6.MonsterLivingHere = MonsterByID(IDMonster.RAT);
            Location field7 = new Location(IDLocation.FARMFIELD7, "Field", "A field of wheat.");
            field7.MonsterLivingHere = MonsterByID(IDMonster.RAT);
            Location field8 = new Location(IDLocation.FARMFIELD8, "Field", "A field of wheat.");
            field8.MonsterLivingHere = MonsterByID(IDMonster.RAT);
            Location field9 = new Location(IDLocation.FARMFIELD9, "Field", "A field of wheat.");
            field9.MonsterLivingHere = MonsterByID(IDMonster.RAT);
            Location field10 = new Location(IDLocation.FARMFIELD10, "Field", "A field of wheat.");
            field10.MonsterLivingHere = MonsterByID(IDMonster.RAT);
            Location field11 = new Location(IDLocation.FARMFIELD11, "Field", "A field of wheat.");
            field11.MonsterLivingHere = MonsterByID(IDMonster.RAT);
            Location field12 = new Location(IDLocation.FARMFIELD12, "Field", "A field of wheat.");
            field12.MonsterLivingHere = MonsterByID(IDMonster.RAT);

            Location burrow = new Location(IDLocation.BURROW, "Burrow", "An unusually large animal burrow.");
            Location burrowboss = new Location(IDLocation.BURROWBOSS, "Chamber", "A chamber filled to the brim with wheat.");
            burrowboss.MonsterLivingHere = MonsterByID(IDMonster.GIANT_WEASEL);
            Location burrowtreasure = new Location(IDLocation.BURROWTREASURE, "Treasure", "A room with a treasure chest in the middle");

            Location guardPost = new Location(IDLocation.GUARD_POST1, "Guard post", "There is a large, tough-looking guard here.", ItemByID(IDItem.ADVENTURER_PASS));

            Location bridge = new Location(IDLocation.BRIDGE1, "Bridge", "A stone bridge crosses a wide river.");

            Location spiderField = new Location(IDLocation.SPIDER_FIELD1, "Forest", "You see spider webs covering covering the trees in this forest.");
            spiderField.MonsterLivingHere = MonsterByID(IDMonster.GIANT_SPIDER);

            Location farmhouse2 = new Location(IDLocation.FARMHOUSE2, "Farmhouse2", "Over here is a neighbouring farmhouse.");

            // Add the locations to the static list
            Locations.Add(home);
            Locations.Add(townSquare);
            Locations.Add(guardPost);
            Locations.Add(alchemistHut);
            Locations.Add(alchemistsGarden);
            Locations.Add(farmhouse);

            Locations.Add(path1);
            Locations.Add(path2);
            Locations.Add(path3);
            Locations.Add(path4);
            Locations.Add(path5);
            Locations.Add(path6);
            Locations.Add(path7);
            Locations.Add(path8);
            Locations.Add(path9);
            Locations.Add(path10);
            Locations.Add(path11);
            Locations.Add(path12);
            Locations.Add(path13);
            Locations.Add(path14);

            Locations.Add(field1);
            Locations.Add(field2);
            Locations.Add(field3);
            Locations.Add(field4);
            Locations.Add(field5);
            Locations.Add(field6);
            Locations.Add(field7);
            Locations.Add(field8);
            Locations.Add(field9);
            Locations.Add(field10);
            Locations.Add(field11);
            Locations.Add(field12);

            Locations.Add(burrow);
            Locations.Add(burrowboss);
            Locations.Add(burrowtreasure);

            Locations.Add(bridge);
            Locations.Add(spiderField);
            Locations.Add(farmhouse2);
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
        public static void DrawWorldMap(Location CurrentLocation)
        {
            CDrawer Canvas = new CDrawer(1000, 1000);
            Canvas.Clear();
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
                            Canvas.AddText(locals.Name, 10, row, columb, 1, 1, Color.White);
                        }
                        if (CurrentLocation.Coordinates.SequenceEqual(cordarray))
                        {
                            Canvas.SetBBScaledPixel(row, columb, Color.Green);
                        }
                    }

                    cordarray[1]++;
                }
                cordarray[1] = 0;
                cordarray[0]++;
            }
        }
        public static void UpdateMiniMap(Location CurrentLocation)
        {
            
            MiniMap.Clear();
            
            int[] cordarray = new int[2] { CurrentLocation.Coordinates[0] - 2, CurrentLocation.Coordinates[1] - 2};
            for (int row = 0; row < 5; row++)
            {
                for (int columb = 0; columb < 5; columb++)
                { 
                    foreach (Location locals in Locations)
                    {
                        if (locals.Coordinates.SequenceEqual(cordarray))
                        {
                            MiniMap.AddRectangle(row, columb, 1, 1, Color.Red);
                            MiniMap.AddText(locals.Name, 10, row, columb, 1, 1, Color.White);
                        }
                        if (CurrentLocation.Coordinates.SequenceEqual(cordarray))
                        {
                            MiniMap.AddRectangle(row, columb, 1, 1, Color.Green);
                            MiniMap.AddText(CurrentLocation.Name, 10, row, columb, 1, 1, Color.White);
                        }
                    }

                    cordarray[1]++;
                }
                cordarray[1] = CurrentLocation.Coordinates[1] - 2;
                cordarray[0]++;
            }
        }

        private static void PopulateLocations2()
        {
            foreach (Location local in Locations)
            {

                if ( local.Coordinates[1] != 0)
                {
                    if (MapArray[local.Coordinates[0], local.Coordinates[1] - 1] != null)
                    {
                        local.LocationToNorth = MapArray[local.Coordinates[0], local.Coordinates[1] - 1];
                    }
                }

                if (local.Coordinates[1] != MapArray.GetLength(1)-1)
                {
                    if (MapArray[local.Coordinates[0], local.Coordinates[1] + 1] != null)
                    {
                        local.LocationToSouth = MapArray[local.Coordinates[0], local.Coordinates[1] + 1];
                    }
                }

                if(local.Coordinates[0] != MapArray.GetLength(0)-1)
                {
                    if (MapArray[local.Coordinates[0] + 1, local.Coordinates[1]] != null)
                    {
                        local.LocationToEast = MapArray[local.Coordinates[0] + 1, local.Coordinates[1]];
                    }
                }

                if(local.Coordinates[0] != 0)
                {
                    if (MapArray[local.Coordinates[0] - 1, local.Coordinates[1]] != null)
                    {
                        local.LocationToWest = MapArray[local.Coordinates[0] - 1, local.Coordinates[1]];
                    }
                }
 
            }
 
        }
        private static void PopulateSkills()
        {
            Skills.Add(new Skills(IDSkills.WARRIOR_HEROIC_STRIKE, "Heroic Strike", 12, 18, 3, 30, IDDamageType.SLASH));
            Skills.Add(new Skills(IDSkills.COMMONER_KICK, "Kick", 4, 6, true, 3, 4, 0, IDDamageType.CRUSH));
            Skills.Add(new Skills(IDSkills.ROGUE_RAPID_STABS, "Rapid Stabs", 4, 6, 3, 3, 60, IDDamageType.PIERCE));
            Skills.Add(new Skills(IDSkills.MAGE_FIREBALL, "Fireball", 8, 12, 3, 4, 4, 30, IDDamageType.FIRE));
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

        public static Weapon WeaponByID(int id)
        {
            foreach (Weapon item in Weapons)
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

        public static Skills SkillsByID(int id)
        {
            foreach (Skills skills in Skills)
            {
                if (skills.ID == id)
                {
                    return skills;
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
    }
}