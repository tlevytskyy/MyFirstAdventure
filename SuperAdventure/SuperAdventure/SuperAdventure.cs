using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Engine;
using ID_Directory;

namespace SuperAdventure
{
    public partial class SuperAdventure : Form
    {
        private Player _player;
        private Monster _currentMonster;

        public SuperAdventure()
        {
            InitializeComponent();

            _player = new Player(10, 10, 20, 0);
            MoveTo(World.LocationByCords(IDLocation.HOME1));
            _player.Inventory.Add(new InventoryItem(World.ItemByID(IDWeapon.RUSTY_SWORD), 1));

            UpdateStatDisplay();
            UpdateSkillsListInUI();



        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToNorth);
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToEast);
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToSouth);
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToWest);
        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {
            // Get the currently selected weapon from the cboWeapons ComboBox
            Weapon currentWeapon = (Weapon)cboWeapons.SelectedItem;

            DealWeaponDamage(currentWeapon);

            // Check if the monster is dead
            if (_currentMonster.CurrentHitPoints <= 0)
            {
                MonsterIsDead();
            }
            else
            {
                // Monster is still alive
                MonsterDealsDamage();
            }
            //End turn
            EndTurn();
        }

        private void btnUseSkill_Click(object sender, EventArgs e)
        {
            // Get the currently selected skill from the cboSkills ComboBox
            Skills currentskill = (Skills)cboSkills.SelectedItem;

            foreach (Skills sk1 in _player.Skills)
            {
                if (currentskill.ID == sk1.ID)
                {
                    if (sk1.CurrentCoolDown == 0)
                    {
                        DealSkillDamage(currentskill);

                        //Apply Status Effects
                        if (currentskill.DotDuration > 0)
                        {
                            _currentMonster.DotDuration = currentskill.DotDuration;
                            _currentMonster.DotDamageTaken = currentskill.DotDamage;
                        }
                        else if (currentskill.Stun == true)
                        {
                            _currentMonster.StunDuration = currentskill.StunDuration;
                        }

                        // Check if the monster is dead
                        if (_currentMonster.CurrentHitPoints <= 0)
                        {
                            MonsterIsDead();
                        }
                        else
                        {
                            //monster deals damage
                            MonsterDealsDamage();

                        }
                        //Set ability on cooldown
                        foreach (Skills sk in _player.Skills)
                        {
                            if (sk.ID == currentskill.ID)
                            {
                                sk.CurrentCoolDown = sk.CoolDown + 1;
                            }
                        }

                        EndTurn();

                    }
                    else
                    {
                        rtbMessages.Text += "This skill is on cooldown" + Environment.NewLine;
                        ScrollToBottomOfMessages();
                    }

                }
            }

        }

        private void MoveTo(Location newLocation)
        {
            //Does the location have any required items
            if (!_player.HasRequiredItemToEnterThisLocation(newLocation))
            {
                rtbMessages.Text += "You must have a " + newLocation.ItemRequiredToEnter.Name + " to enter this location." + Environment.NewLine;
                ScrollToBottomOfMessages();
                return;
            }

            // Update the player's current location
            _player.CurrentLocation = newLocation;

            // Show/hide available movement buttons
            btnNorth.Visible = (newLocation.LocationToNorth != null);
            btnEast.Visible = (newLocation.LocationToEast != null);
            btnSouth.Visible = (newLocation.LocationToSouth != null);
            btnWest.Visible = (newLocation.LocationToWest != null);

            // Display current location name and description
            rtbLocation.Text = newLocation.Name + Environment.NewLine;
            rtbLocation.Text += newLocation.Description + Environment.NewLine;
            ScrollToBottomOfMessages();

            // Completely heal the player
            _player.CurrentHitPoints = _player.MaximumHitPoints;

            // Update Hit Points in UI
            lblHitPoints.Text = _player.CurrentHitPoints.ToString();

            // Update Mana for Mages
            if (_player.Class == IDClass.MAGE)
            {
                _player.Energy += 20;
                if (_player.Energy > _player.MaximumEnergy)
                {
                    _player.Energy = _player.MaximumEnergy;
                }
                UpdateStatDisplay();
            }

            // Does the location have a quest?
            if (newLocation.QuestAvailableHere != null)
            {
                // See if the player already has the quest, and if they've completed it
                bool playerAlreadyHasQuest = _player.HasThisQuest(newLocation.QuestAvailableHere);
                bool playerAlreadyCompletedQuest = _player.CompletedThisQuest(newLocation.QuestAvailableHere);

                // See if the player already has the quest
                if (playerAlreadyHasQuest)
                {
                    // If the player has not completed the quest yet
                    if (!playerAlreadyCompletedQuest)
                    {
                        // See if the player has all the items needed to complete the quest
                        bool playerHasAllItemsToCompleteQuest = _player.HasAllQuestCompletionItems(newLocation.QuestAvailableHere);

                        // The player has all items required to complete the quest
                        if (playerHasAllItemsToCompleteQuest)
                        {
                            // Display message
                            rtbMessages.Text += Environment.NewLine;
                            rtbMessages.Text += "You complete the '" + newLocation.QuestAvailableHere.Name + "' quest." + Environment.NewLine;
                            ScrollToBottomOfMessages();

                            // Remove quest items from inventory
                            _player.RemoveQuestCompletionItems(newLocation.QuestAvailableHere);

                            // Give quest rewards
                            rtbMessages.Text += "You receive: " + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardExperiencePoints.ToString() + " experience points" + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardGold.ToString() + " gold" + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardItem.Name + Environment.NewLine;
                            rtbMessages.Text += Environment.NewLine;
                            ScrollToBottomOfMessages();

                            _player.ExperiencePoints += newLocation.QuestAvailableHere.RewardExperiencePoints;
                            _player.Gold += newLocation.QuestAvailableHere.RewardGold;

                            // Add the reward item to the player's inventory
                            _player.AddItemToInventory(newLocation.QuestAvailableHere.RewardItem);

                            // Mark the quest as completed
                            _player.MarkQuestCompleted(newLocation.QuestAvailableHere);
                        }
                    }
                }
                else
                {
                    // The player does not already have the quest

                    // Display the messages
                    rtbMessages.Text += "You receive the " + newLocation.QuestAvailableHere.Name + " quest." + Environment.NewLine;
                    rtbMessages.Text += newLocation.QuestAvailableHere.Description + Environment.NewLine;
                    rtbMessages.Text += "To complete it, return with:" + Environment.NewLine;
                    ScrollToBottomOfMessages();
                    foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                    {
                        if (qci.Quantity == 1)
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.Name + Environment.NewLine;
                            ScrollToBottomOfMessages();
                        }
                        else
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.NamePlural + Environment.NewLine;
                            ScrollToBottomOfMessages();
                        }
                    }
                    rtbMessages.Text += Environment.NewLine;
                    ScrollToBottomOfMessages();

                    // Add the quest to the player's quest list
                    _player.Quests.Add(new PlayerQuest(newLocation.QuestAvailableHere));
                }
            }
                 // Does the location have a monster?
            if (newLocation.MonsterLivingHere != null)
            {
                rtbMessages.Text += "You see a " + newLocation.MonsterLivingHere.Name + Environment.NewLine;
                ScrollToBottomOfMessages();

                // Make a new monster, using the values from the standard monster in the World.Monster list
                Monster standardMonster = World.MonsterByID(newLocation.MonsterLivingHere.ID);

                _currentMonster = new Monster(standardMonster.ID, standardMonster.Name, standardMonster.MaximumDamage,
                    standardMonster.RewardExperiencePoints, standardMonster.RewardGold, standardMonster.CurrentHitPoints, standardMonster.MaximumHitPoints, standardMonster.Weakness);

                foreach (LootItem lootItem in standardMonster.LootTable)
                {
                    _currentMonster.LootTable.Add(lootItem);
                }

                dgvCoolDowns.Visible = true;
                cboSkills.Visible = true;
                cboWeapons.Visible = true;
                cboPotions.Visible = true;
                btnUseWeapon.Visible = true;
                btnUsePotion.Visible = true;
                btnUseSkill.Visible = true;
            }
            else
            {
                _currentMonster = null;

                dgvCoolDowns.Visible = false;
                cboSkills.Visible = false;
                cboWeapons.Visible = false;
                cboPotions.Visible = false;
                btnUseWeapon.Visible = false;
                btnUsePotion.Visible = false;
                btnUseSkill.Visible = false;
            }

            // Refresh player's inventory list
            UpdateInventoryListInUI();

            // Refresh player's quest list
            UpdateQuestListInUI();

            // Refresh player's weapons combobox
            UpdateWeaponListInUI();

            // Refresh player's potions combobox
            UpdatePotionListInUI();
        }

        private void UpdateInventoryListInUI()
        {
            dgvInventory.RowHeadersVisible = false;

            dgvInventory.ColumnCount = 2;
            dgvInventory.Columns[0].Name = "Name";
            dgvInventory.Columns[0].Width = 197;
            dgvInventory.Columns[1].Name = "Quantity";

            dgvInventory.Rows.Clear();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Quantity > 0)
                {
                    dgvInventory.Rows.Add(new[] { inventoryItem.Details.Name, inventoryItem.Quantity.ToString() });
                }
            }
        }

        private void UpdateQuestListInUI()
        {
            dgvQuests.RowHeadersVisible = false;

            dgvQuests.ColumnCount = 2;
            dgvQuests.Columns[0].Name = "Name";
            dgvQuests.Columns[0].Width = 197;
            dgvQuests.Columns[1].Name = "Done?";


            dgvQuests.Rows.Clear();

            foreach (PlayerQuest playerQuest in _player.Quests)
            {
                dgvQuests.Rows.Add(new[] { playerQuest.Details.Name, playerQuest.IsCompleted.ToString() });
            }
        }

        private void UpdateWeaponListInUI()
        {
            List<Weapon> weapons = new List<Weapon>();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Details is Weapon)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        weapons.Add((Weapon)inventoryItem.Details);
                    }
                }
            }

            if (weapons.Count == 0)
            {
                // The player doesn't have any weapons, so hide the weapon combobox and "Use" button
                cboWeapons.Visible = false;
                btnUseWeapon.Visible = false;
            }
            else
            {
                cboWeapons.DataSource = weapons;
                cboWeapons.DisplayMember = "Name";
                cboWeapons.ValueMember = "ID";

                cboWeapons.SelectedIndex = 0;
            }
        }

        private void UpdatePotionListInUI()
        {
            List<HealingPotion> healingPotions = new List<HealingPotion>();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Details is HealingPotion)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        healingPotions.Add((HealingPotion)inventoryItem.Details);
                    }
                }
            }

            if (healingPotions.Count == 0)
            {
                // The player doesn't have any potions, so hide the potion combobox and "Use" button
                cboPotions.Visible = false;
                btnUsePotion.Visible = false;
            }
            else
            {
                cboPotions.DataSource = healingPotions;
                cboPotions.DisplayMember = "Name";
                cboPotions.ValueMember = "ID";

                cboPotions.SelectedIndex = 0;
            }
        }

        private void UpdateSkillsListInUI()
        {
            //Update skill combobox
            List<Skills> skills = new List<Skills>();

            foreach (Skills skills1 in _player.Skills)
            {
                skills.Add((Skills)skills1);
            }
            if (skills.Count == 0)
            {
                cboSkills.Visible = false;
                btnUseSkill.Visible = false;
            }
            else
            {
                cboSkills.DataSource = skills;
                cboSkills.DisplayMember = "Name";
                cboSkills.ValueMember = "ID";

                cboSkills.SelectedIndex = 0;
            }

            //foreach (Skills skills in _player.Skills)
            //{

            //    cboSkills.Items.Add(skills);
            //    cboSkills.DisplayMember = "Name";
            //    cboSkills.ValueMember = "ID";
            //    cboSkills.SelectedIndex = 0;
            //}

        }

        private void UpdateStatDisplay()
        {
            lblHitPoints.Text = _player.CurrentHitPoints.ToString();
            lblGold.Text = _player.Gold.ToString();
            lblExperience.Text = _player.ExperiencePoints.ToString();
            lblLevel.Text = _player.Level.ToString();
            lblStrength.Text = _player.Strength.ToString();
            lblDexterity.Text = _player.Dexterity.ToString();
            lblIntelligence.Text = _player.Intelligence.ToString();
            lblEnergy.Text = _player.Energy.ToString();
        }

        private void UpdatePlayerClass()
        {
            if (_player.Class == IDClass.COMMONER && _player.Level >= 5)
            {
                lblChooseClass.Visible = true;
                btnClassMage.Visible = true;
                btnClassRogue.Visible = true;
                btnClassWarrior.Visible = true;
            }
        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {
            // Get the currently selected potion from the combobox
            HealingPotion potion = (HealingPotion)cboPotions.SelectedItem;

            // Add healing amount to the player's current hit points
            _player.CurrentHitPoints = (_player.CurrentHitPoints + potion.AmountToHeal);

            // CurrentHitPoints cannot exceed player's MaximumHitPoints
            if (_player.CurrentHitPoints > _player.MaximumHitPoints)
            {
                _player.CurrentHitPoints = _player.MaximumHitPoints;
            }

            // Remove the potion from the player's inventory
            foreach (InventoryItem ii in _player.Inventory)
            {
                if (ii.Details.ID == potion.ID)
                {
                    ii.Quantity--;
                    break;
                }
            }

            // Display message
            rtbMessages.Text += "You drink a " + potion.Name + Environment.NewLine;
            ScrollToBottomOfMessages();

            // Monster gets their turn to attack
            MonsterDealsDamage();

            EndTurn();

            //update inventory and potion lists
            UpdateInventoryListInUI();
            UpdatePotionListInUI();
        }

        private void ScrollToBottomOfMessages()
        {
            rtbMessages.SelectionStart = rtbMessages.Text.Length;
            rtbMessages.ScrollToCaret();
           
        }

        private void btnClassWarrior_Click(object sender, EventArgs e)
        {
            _player.Class = IDClass.WARRIOR;
            _player.UpdateMaxHP();
            _player.UpdateStrength();
            _player.UpdateDexterity();
            _player.UpdateIntelligence();
            UpdateStatDisplay();
            _player.Skills.Add(World.SkillsByID(IDSkills.WARRIOR_HEROIC_STRIKE));
            UpdateSkillsListInUI();
            btnClassMage.Visible = false;
            btnClassRogue.Visible = false;
            btnClassWarrior.Visible = false;
            lblChooseClass.Visible = false;
            lblEnergy.Visible = true;
            lblEnergyName.Text = "Rage";
            lblEnergyName.Visible = true;
        }

        private void btnClassRogue_Click(object sender, EventArgs e)
        {
            _player.Class = IDClass.ROGUE;
            _player.UpdateMaxHP();
            _player.UpdateStrength();
            _player.UpdateDexterity();
            _player.UpdateIntelligence();
            UpdateStatDisplay();
            _player.Skills.Add(World.SkillsByID(IDSkills.ROGUE_RAPID_STABS));
            UpdateSkillsListInUI();
            btnClassMage.Visible = false;
            btnClassRogue.Visible = false;
            btnClassWarrior.Visible = false;
            lblChooseClass.Visible = false;
            lblEnergy.Visible = true;
            lblEnergyName.Text = "Energy";
            lblEnergyName.Visible = true;
        }

        private void btnClassMage_Click(object sender, EventArgs e)
        {
            _player.Class = IDClass.MAGE;
            _player.UpdateMaxHP();
            _player.UpdateStrength();
            _player.UpdateDexterity();
            _player.UpdateIntelligence();
            UpdateStatDisplay();
            _player.Skills.Add(World.SkillsByID(IDSkills.MAGE_FIREBALL));
            UpdateSkillsListInUI();
            btnClassMage.Visible = false;
            btnClassRogue.Visible = false;
            btnClassWarrior.Visible = false;
            lblChooseClass.Visible = false;
            lblEnergy.Visible = true;
            lblEnergyName.Text = "Mana";
            lblEnergyName.Visible = true;
        }

        private void MonsterIsDead()
        {
            // Monster is dead
            rtbMessages.Text += Environment.NewLine;
            rtbMessages.Text += "You defeated the " + _currentMonster.Name + Environment.NewLine;
            ScrollToBottomOfMessages();

            // Give player experience points for killing the monster
            _player.ExperiencePoints += _currentMonster.RewardExperiencePoints;
            rtbMessages.Text += "You receive " + _currentMonster.RewardExperiencePoints.ToString() + " experience points" + Environment.NewLine;
            ScrollToBottomOfMessages();

            //update player stats
            UpdatePlayerClass();
            _player.UpdateAllStats();
            UpdateStatDisplay();

            // Give player gold for killing the monster 
            _player.Gold += _currentMonster.RewardGold;
            rtbMessages.Text += "You receive " + _currentMonster.RewardGold.ToString() + " gold" + Environment.NewLine;
            ScrollToBottomOfMessages();

            // Get random loot items from the monster
            List<InventoryItem> lootedItems = new List<InventoryItem>();

            // Add items to the lootedItems list, comparing a random number to the drop percentage
            foreach (LootItem lootItem in _currentMonster.LootTable)
            {
                if (RandomNumberGenerator.NumberBetween(1, 100) <= lootItem.DropPercentage)
                {
                    lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                }
            }

            // If no items were randomly selected, then add the default loot item(s).
            if (lootedItems.Count == 0)
            {
                foreach (LootItem lootItem in _currentMonster.LootTable)
                {
                    if (lootItem.IsDefaultItem)
                    {
                        lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                    }
                }
            }

            // Add the looted items to the player's inventory
            foreach (InventoryItem inventoryItem in lootedItems)
            {
                _player.AddItemToInventory(inventoryItem.Details);

                if (inventoryItem.Quantity == 1)
                {
                    rtbMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.Name + Environment.NewLine;
                    ScrollToBottomOfMessages();
                }
                else
                {
                    rtbMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.NamePlural + Environment.NewLine;
                    ScrollToBottomOfMessages();
                }
            }


            // Refresh player information and inventory controls
            UpdateStatDisplay();

            UpdateInventoryListInUI();
            UpdateWeaponListInUI();
            UpdatePotionListInUI();

            // Add a blank line to the messages box, just for appearance.
            rtbMessages.Text += Environment.NewLine;
            ScrollToBottomOfMessages();

            // Move player to current location (to heal player and create a new monster to fight)
            MoveTo(_player.CurrentLocation);
        }

        private void MonsterDealsDamage()
        {
            // Monster is still alive

            //check if monster is taking dot damage
            if (_currentMonster.DotDuration > 0)
            {
                _currentMonster.CurrentHitPoints -= _currentMonster.DotDamageTaken;
                _currentMonster.DotDuration--;
                rtbMessages.Text += "The monster takes " + _currentMonster.DotDamageTaken + " burn damage." + Environment.NewLine;
                // Check if the monster is dead
                if (_currentMonster.CurrentHitPoints <= 0)
                {
                    MonsterIsDead();
                    return;
                }
            }

            //check if the monster is stunned
            if (_currentMonster.StunDuration > 0)
            {
                //monster skps a turn / stun counter down by 1
                rtbMessages.Text += "The monster is stunned." + Environment.NewLine;
                _currentMonster.StunDuration--;
            }
            else
            {
               
                // Determine the amount of damage the monster does to the player
                double damageToPlayer = RandomNumberGenerator.NumberBetween(0, _currentMonster.MaximumDamage);

                // Display message
                rtbMessages.Text += "The " + _currentMonster.Name + " did " + damageToPlayer.ToString() + " points of damage." + Environment.NewLine;
                ScrollToBottomOfMessages();

                // Subtract damage from player
                _player.CurrentHitPoints -= damageToPlayer;

                //Generate Rage for warriors
                if (_player.Class == IDClass.WARRIOR)
                {
                    _player.Energy += Convert.ToInt32(damageToPlayer) * 10;
                    if (_player.Energy > _player.MaximumEnergy)
                    {
                        _player.Energy = _player.MaximumEnergy;
                    }
                    UpdateStatDisplay();
                }
                // Refresh player data in UI
                lblHitPoints.Text = _player.CurrentHitPoints.ToString();

                if (_player.CurrentHitPoints <= 0)
                {
                    // Display message
                    rtbMessages.Text += "The " + _currentMonster.Name + " killed you." + Environment.NewLine;

                    // Move player to "Home"
                    MoveTo(World.LocationByCords(IDLocation.HOME1));
                }
            }
        }

        private void DealWeaponDamage(Weapon currentweapon)
        {
            // Determine the amount of damage to do to the monster
            double damageToMonster = RandomNumberGenerator.NumberBetween(currentweapon.MinimumDamage, currentweapon.MaximumDamage) * (0.1 * _player.Strength);

            //Determine weather this monster is weak to the weapon used.
            if (Monster.IsWeakTo(_currentMonster.Weakness, currentweapon.DamageType))
            {
                damageToMonster = damageToMonster * 1.25;
                rtbMessages.Text += "Its super effective." + Environment.NewLine;
                ScrollToBottomOfMessages();
            }

            // Apply the damage to the monster's CurrentHitPoints
            _currentMonster.CurrentHitPoints -= damageToMonster;

            // Display message
            rtbMessages.Text += "You hit the " + _currentMonster.Name + " for " + damageToMonster.ToString("F0") + " points." + Environment.NewLine;
            ScrollToBottomOfMessages();
        }

        private void DealSkillDamage(Skills currentskills)
        {
            for (int i = 0; i < currentskills.NumberOfAttacks; i++)
            {
                // Determine the amount of damage to do to the monster
                double damageToMonster = RandomNumberGenerator.NumberBetween(currentskills.MinimumDamage, currentskills.MaximumDamage);

                //Determine weather this monster is weak to the weapon used.
                if (Monster.IsWeakTo(_currentMonster.Weakness, currentskills.DamageType))
                {
                    damageToMonster = damageToMonster * 1.25;
                    rtbMessages.Text += "Its super effective." + Environment.NewLine;
                    ScrollToBottomOfMessages();
                }

                // Apply the damage to the monster's CurrentHitPoints
                _currentMonster.CurrentHitPoints -= damageToMonster;

                // Display message
                rtbMessages.Text += "You hit the " + _currentMonster.Name + " for " + damageToMonster.ToString("F0") + " points." + Environment.NewLine;
                ScrollToBottomOfMessages();
            }
        }

        private void EndTurn()
        {
            foreach (Skills sk in _player.Skills)
            {
                if (sk.CurrentCoolDown != 0)
                {
                    sk.CurrentCoolDown--;
                }
            }

            dgvCoolDowns.RowHeadersVisible = false;

            dgvCoolDowns.ColumnCount = 2;
            dgvCoolDowns.Columns[0].Name = "Skill";
            dgvCoolDowns.Columns[0].Width = 70;
            dgvCoolDowns.Columns[1].Name = "CD";
            dgvCoolDowns.Columns[1].Width = 34;
            dgvCoolDowns.Rows.Clear();

            foreach (Skills playerskills in _player.Skills)
            {
                dgvCoolDowns.Rows.Add(new[] { playerskills.Name, playerskills.CurrentCoolDown.ToString() });
            }

            if (_player.Class == IDClass.ROGUE)
            {
                _player.Energy += 10;
                if (_player.Energy > _player.MaximumEnergy)
                {
                    _player.Energy = _player.MaximumEnergy;
                }
                UpdateStatDisplay();
            }
        }
    }
    
}