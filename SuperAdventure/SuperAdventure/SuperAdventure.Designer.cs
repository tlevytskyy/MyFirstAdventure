namespace SuperAdventure
{
    partial class SuperAdventure
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHitPoints = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblExperience = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboWeapons = new System.Windows.Forms.ComboBox();
            this.cboPotions = new System.Windows.Forms.ComboBox();
            this.btnUsePotion = new System.Windows.Forms.Button();
            this.btnNorth = new System.Windows.Forms.Button();
            this.btnEast = new System.Windows.Forms.Button();
            this.btnSouth = new System.Windows.Forms.Button();
            this.btnWest = new System.Windows.Forms.Button();
            this.btnUseWeapon = new System.Windows.Forms.Button();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.rtbLocation = new System.Windows.Forms.RichTextBox();
            this.dgvQuests = new System.Windows.Forms.DataGridView();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblStrength = new System.Windows.Forms.Label();
            this.lblDexterity = new System.Windows.Forms.Label();
            this.lblIntelligence = new System.Windows.Forms.Label();
            this.lblChooseClass = new System.Windows.Forms.Label();
            this.btnClassWarrior = new System.Windows.Forms.Button();
            this.btnClassRogue = new System.Windows.Forms.Button();
            this.btnClassMage = new System.Windows.Forms.Button();
            this.lblEnergyName = new System.Windows.Forms.Label();
            this.lblEnergy = new System.Windows.Forms.Label();
            this.cboSkills = new System.Windows.Forms.ComboBox();
            this.btnUseSkill = new System.Windows.Forms.Button();
            this.dgvCoolDowns = new System.Windows.Forms.DataGridView();
            this.btnToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnMap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoolDowns)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hit Points:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gold:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Experience:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Level:";
            // 
            // lblHitPoints
            // 
            this.lblHitPoints.AutoSize = true;
            this.lblHitPoints.Location = new System.Drawing.Point(110, 19);
            this.lblHitPoints.Name = "lblHitPoints";
            this.lblHitPoints.Size = new System.Drawing.Size(0, 17);
            this.lblHitPoints.TabIndex = 4;
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(110, 45);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(0, 17);
            this.lblGold.TabIndex = 5;
            // 
            // lblExperience
            // 
            this.lblExperience.AutoSize = true;
            this.lblExperience.Location = new System.Drawing.Point(110, 73);
            this.lblExperience.Name = "lblExperience";
            this.lblExperience.Size = new System.Drawing.Size(0, 17);
            this.lblExperience.TabIndex = 6;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(110, 99);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(0, 17);
            this.lblLevel.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(617, 531);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Select action";
            // 
            // cboWeapons
            // 
            this.cboWeapons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWeapons.FormattingEnabled = true;
            this.cboWeapons.Location = new System.Drawing.Point(347, 558);
            this.cboWeapons.Name = "cboWeapons";
            this.cboWeapons.Size = new System.Drawing.Size(121, 24);
            this.cboWeapons.TabIndex = 9;
            // 
            // cboPotions
            // 
            this.cboPotions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPotions.FormattingEnabled = true;
            this.cboPotions.Location = new System.Drawing.Point(347, 626);
            this.cboPotions.Name = "cboPotions";
            this.cboPotions.Size = new System.Drawing.Size(121, 24);
            this.cboPotions.TabIndex = 10;
            // 
            // btnUsePotion
            // 
            this.btnUsePotion.Location = new System.Drawing.Point(620, 627);
            this.btnUsePotion.Name = "btnUsePotion";
            this.btnUsePotion.Size = new System.Drawing.Size(75, 23);
            this.btnUsePotion.TabIndex = 11;
            this.btnUsePotion.Text = "Use";
            this.btnToolTip.SetToolTip(this.btnUsePotion, "Use the selected potion.");
            this.btnUsePotion.UseVisualStyleBackColor = true;
            this.btnUsePotion.Click += new System.EventHandler(this.btnUsePotion_Click);
            // 
            // btnNorth
            // 
            this.btnNorth.Location = new System.Drawing.Point(493, 433);
            this.btnNorth.Name = "btnNorth";
            this.btnNorth.Size = new System.Drawing.Size(75, 23);
            this.btnNorth.TabIndex = 12;
            this.btnNorth.Text = "North";
            this.btnToolTip.SetToolTip(this.btnNorth, "Travel north");
            this.btnNorth.UseVisualStyleBackColor = true;
            this.btnNorth.Click += new System.EventHandler(this.btnNorth_Click);
            // 
            // btnEast
            // 
            this.btnEast.Location = new System.Drawing.Point(573, 457);
            this.btnEast.Name = "btnEast";
            this.btnEast.Size = new System.Drawing.Size(75, 23);
            this.btnEast.TabIndex = 13;
            this.btnEast.Text = "East";
            this.btnToolTip.SetToolTip(this.btnEast, "Travel East");
            this.btnEast.UseVisualStyleBackColor = true;
            this.btnEast.Click += new System.EventHandler(this.btnEast_Click);
            // 
            // btnSouth
            // 
            this.btnSouth.Location = new System.Drawing.Point(493, 487);
            this.btnSouth.Name = "btnSouth";
            this.btnSouth.Size = new System.Drawing.Size(75, 23);
            this.btnSouth.TabIndex = 14;
            this.btnSouth.Text = "South";
            this.btnToolTip.SetToolTip(this.btnSouth, "Travel South");
            this.btnSouth.UseVisualStyleBackColor = true;
            this.btnSouth.Click += new System.EventHandler(this.btnSouth_Click);
            // 
            // btnWest
            // 
            this.btnWest.Location = new System.Drawing.Point(412, 457);
            this.btnWest.Name = "btnWest";
            this.btnWest.Size = new System.Drawing.Size(75, 23);
            this.btnWest.TabIndex = 15;
            this.btnWest.Text = "West";
            this.btnToolTip.SetToolTip(this.btnWest, "Travel West");
            this.btnWest.UseVisualStyleBackColor = true;
            this.btnWest.Click += new System.EventHandler(this.btnWest_Click);
            // 
            // btnUseWeapon
            // 
            this.btnUseWeapon.Location = new System.Drawing.Point(620, 559);
            this.btnUseWeapon.Name = "btnUseWeapon";
            this.btnUseWeapon.Size = new System.Drawing.Size(75, 23);
            this.btnUseWeapon.TabIndex = 16;
            this.btnUseWeapon.Text = "Attack";
            this.btnToolTip.SetToolTip(this.btnUseWeapon, "Attack with your weapon.");
            this.btnUseWeapon.UseVisualStyleBackColor = true;
            this.btnUseWeapon.Click += new System.EventHandler(this.btnUseWeapon_Click);
            // 
            // rtbMessages
            // 
            this.rtbMessages.Location = new System.Drawing.Point(347, 130);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.ReadOnly = true;
            this.rtbMessages.Size = new System.Drawing.Size(360, 286);
            this.rtbMessages.TabIndex = 17;
            this.rtbMessages.Text = "";
            // 
            // rtbLocation
            // 
            this.rtbLocation.Location = new System.Drawing.Point(347, 19);
            this.rtbLocation.Name = "rtbLocation";
            this.rtbLocation.ReadOnly = true;
            this.rtbLocation.Size = new System.Drawing.Size(360, 105);
            this.rtbLocation.TabIndex = 18;
            this.rtbLocation.Text = "";
            // 
            // dgvQuests
            // 
            this.dgvQuests.AllowUserToAddRows = false;
            this.dgvQuests.AllowUserToDeleteRows = false;
            this.dgvQuests.AllowUserToResizeRows = false;
            this.dgvQuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvQuests.Location = new System.Drawing.Point(16, 446);
            this.dgvQuests.MultiSelect = false;
            this.dgvQuests.Name = "dgvQuests";
            this.dgvQuests.ReadOnly = true;
            this.dgvQuests.RowHeadersVisible = false;
            this.dgvQuests.RowHeadersWidth = 51;
            this.dgvQuests.RowTemplate.Height = 24;
            this.dgvQuests.Size = new System.Drawing.Size(312, 214);
            this.dgvQuests.TabIndex = 19;
            this.dgvQuests.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuests_CellClick);
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AllowUserToResizeRows = false;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInventory.Location = new System.Drawing.Point(16, 131);
            this.dgvInventory.MultiSelect = false;
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.RowHeadersWidth = 51;
            this.dgvInventory.RowTemplate.Height = 24;
            this.dgvInventory.Size = new System.Drawing.Size(312, 309);
            this.dgvInventory.TabIndex = 20;
            this.dgvInventory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventory_CellContentClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(190, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "Strength:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "Dexterity:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(190, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "Intelligence:";
            // 
            // lblStrength
            // 
            this.lblStrength.AutoSize = true;
            this.lblStrength.Location = new System.Drawing.Point(285, 20);
            this.lblStrength.Name = "lblStrength";
            this.lblStrength.Size = new System.Drawing.Size(0, 17);
            this.lblStrength.TabIndex = 24;
            // 
            // lblDexterity
            // 
            this.lblDexterity.AutoSize = true;
            this.lblDexterity.Location = new System.Drawing.Point(285, 46);
            this.lblDexterity.Name = "lblDexterity";
            this.lblDexterity.Size = new System.Drawing.Size(0, 17);
            this.lblDexterity.TabIndex = 25;
            // 
            // lblIntelligence
            // 
            this.lblIntelligence.AutoSize = true;
            this.lblIntelligence.Location = new System.Drawing.Point(285, 74);
            this.lblIntelligence.Name = "lblIntelligence";
            this.lblIntelligence.Size = new System.Drawing.Size(0, 17);
            this.lblIntelligence.TabIndex = 26;
            // 
            // lblChooseClass
            // 
            this.lblChooseClass.AutoSize = true;
            this.lblChooseClass.Location = new System.Drawing.Point(366, 93);
            this.lblChooseClass.Name = "lblChooseClass";
            this.lblChooseClass.Size = new System.Drawing.Size(98, 17);
            this.lblChooseClass.TabIndex = 27;
            this.lblChooseClass.Text = "Choose Class:";
            this.lblChooseClass.Visible = false;
            // 
            // btnClassWarrior
            // 
            this.btnClassWarrior.Location = new System.Drawing.Point(470, 93);
            this.btnClassWarrior.Name = "btnClassWarrior";
            this.btnClassWarrior.Size = new System.Drawing.Size(75, 23);
            this.btnClassWarrior.TabIndex = 28;
            this.btnClassWarrior.Text = "Warrior";
            this.btnToolTip.SetToolTip(this.btnClassWarrior, "Become a Warrior.");
            this.btnClassWarrior.UseVisualStyleBackColor = true;
            this.btnClassWarrior.Visible = false;
            this.btnClassWarrior.Click += new System.EventHandler(this.btnClassWarrior_Click);
            // 
            // btnClassRogue
            // 
            this.btnClassRogue.Location = new System.Drawing.Point(551, 94);
            this.btnClassRogue.Name = "btnClassRogue";
            this.btnClassRogue.Size = new System.Drawing.Size(75, 23);
            this.btnClassRogue.TabIndex = 29;
            this.btnClassRogue.Text = "Rogue";
            this.btnToolTip.SetToolTip(this.btnClassRogue, "Become a Rogue.");
            this.btnClassRogue.UseVisualStyleBackColor = true;
            this.btnClassRogue.Visible = false;
            this.btnClassRogue.Click += new System.EventHandler(this.btnClassRogue_Click);
            // 
            // btnClassMage
            // 
            this.btnClassMage.Location = new System.Drawing.Point(631, 94);
            this.btnClassMage.Name = "btnClassMage";
            this.btnClassMage.Size = new System.Drawing.Size(75, 23);
            this.btnClassMage.TabIndex = 30;
            this.btnClassMage.Text = "Mage";
            this.btnToolTip.SetToolTip(this.btnClassMage, "Become a Mage.");
            this.btnClassMage.UseVisualStyleBackColor = true;
            this.btnClassMage.Visible = false;
            this.btnClassMage.Click += new System.EventHandler(this.btnClassMage_Click);
            // 
            // lblEnergyName
            // 
            this.lblEnergyName.AutoSize = true;
            this.lblEnergyName.Location = new System.Drawing.Point(190, 100);
            this.lblEnergyName.Name = "lblEnergyName";
            this.lblEnergyName.Size = new System.Drawing.Size(0, 17);
            this.lblEnergyName.TabIndex = 31;
            this.lblEnergyName.Visible = false;
            // 
            // lblEnergy
            // 
            this.lblEnergy.AutoSize = true;
            this.lblEnergy.Location = new System.Drawing.Point(285, 100);
            this.lblEnergy.Name = "lblEnergy";
            this.lblEnergy.Size = new System.Drawing.Size(0, 17);
            this.lblEnergy.TabIndex = 32;
            this.lblEnergy.Visible = false;
            // 
            // cboSkills
            // 
            this.cboSkills.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSkills.FormattingEnabled = true;
            this.cboSkills.Location = new System.Drawing.Point(347, 592);
            this.cboSkills.Name = "cboSkills";
            this.cboSkills.Size = new System.Drawing.Size(121, 24);
            this.cboSkills.TabIndex = 33;
            // 
            // btnUseSkill
            // 
            this.btnUseSkill.Location = new System.Drawing.Point(620, 593);
            this.btnUseSkill.Name = "btnUseSkill";
            this.btnUseSkill.Size = new System.Drawing.Size(75, 23);
            this.btnUseSkill.TabIndex = 34;
            this.btnUseSkill.Text = "Cast";
            this.btnToolTip.SetToolTip(this.btnUseSkill, "Cast the selected spell.");
            this.btnUseSkill.UseVisualStyleBackColor = true;
            this.btnUseSkill.Click += new System.EventHandler(this.btnUseSkill_Click);
            // 
            // dgvCoolDowns
            // 
            this.dgvCoolDowns.AllowUserToAddRows = false;
            this.dgvCoolDowns.AllowUserToDeleteRows = false;
            this.dgvCoolDowns.AllowUserToResizeRows = false;
            this.dgvCoolDowns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCoolDowns.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCoolDowns.Location = new System.Drawing.Point(474, 540);
            this.dgvCoolDowns.MultiSelect = false;
            this.dgvCoolDowns.Name = "dgvCoolDowns";
            this.dgvCoolDowns.ReadOnly = true;
            this.dgvCoolDowns.RowHeadersVisible = false;
            this.dgvCoolDowns.RowHeadersWidth = 51;
            this.dgvCoolDowns.RowTemplate.Height = 24;
            this.dgvCoolDowns.Size = new System.Drawing.Size(141, 111);
            this.dgvCoolDowns.TabIndex = 35;
            this.dgvCoolDowns.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCoolDowns_CellContentClick);
            // 
            // btnMap
            // 
            this.btnMap.Location = new System.Drawing.Point(494, 458);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(75, 23);
            this.btnMap.TabIndex = 36;
            this.btnMap.Text = "Map";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // SuperAdventure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 668);
            this.Controls.Add(this.btnMap);
            this.Controls.Add(this.dgvCoolDowns);
            this.Controls.Add(this.btnUseSkill);
            this.Controls.Add(this.cboSkills);
            this.Controls.Add(this.lblEnergy);
            this.Controls.Add(this.lblEnergyName);
            this.Controls.Add(this.btnClassMage);
            this.Controls.Add(this.btnClassRogue);
            this.Controls.Add(this.btnClassWarrior);
            this.Controls.Add(this.lblChooseClass);
            this.Controls.Add(this.lblIntelligence);
            this.Controls.Add(this.lblDexterity);
            this.Controls.Add(this.lblStrength);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.dgvQuests);
            this.Controls.Add(this.rtbLocation);
            this.Controls.Add(this.rtbMessages);
            this.Controls.Add(this.btnUseWeapon);
            this.Controls.Add(this.btnWest);
            this.Controls.Add(this.btnSouth);
            this.Controls.Add(this.btnEast);
            this.Controls.Add(this.btnNorth);
            this.Controls.Add(this.btnUsePotion);
            this.Controls.Add(this.cboPotions);
            this.Controls.Add(this.cboWeapons);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblExperience);
            this.Controls.Add(this.lblGold);
            this.Controls.Add(this.lblHitPoints);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SuperAdventure";
            this.Text = "My Game";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoolDowns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHitPoints;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboWeapons;
        private System.Windows.Forms.ComboBox cboPotions;
        private System.Windows.Forms.Button btnUsePotion;
        private System.Windows.Forms.Button btnNorth;
        private System.Windows.Forms.Button btnEast;
        private System.Windows.Forms.Button btnSouth;
        private System.Windows.Forms.Button btnWest;
        private System.Windows.Forms.Button btnUseWeapon;
        private System.Windows.Forms.RichTextBox rtbMessages;
        private System.Windows.Forms.RichTextBox rtbLocation;
        private System.Windows.Forms.DataGridView dgvQuests;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblStrength;
        private System.Windows.Forms.Label lblDexterity;
        private System.Windows.Forms.Label lblIntelligence;
        public System.Windows.Forms.Label lblChooseClass;
        public System.Windows.Forms.Button btnClassWarrior;
        protected System.Windows.Forms.Button btnClassRogue;
        public System.Windows.Forms.Button btnClassMage;
        private System.Windows.Forms.Label lblEnergyName;
        private System.Windows.Forms.Label lblEnergy;
        private System.Windows.Forms.ComboBox cboSkills;
        private System.Windows.Forms.Button btnUseSkill;
        private System.Windows.Forms.DataGridView dgvCoolDowns;
        private System.Windows.Forms.ToolTip btnToolTip;
        private System.Windows.Forms.Button btnMap;
    }
}

