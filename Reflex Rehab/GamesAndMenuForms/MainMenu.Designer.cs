namespace Reflex_Rehab.GameAndMenuForms {
    partial class MainMenu {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            panelMain = new Panel();
            panelMenu = new Panel();
            panelMenuDifficultySelection = new Panel();
            btnReturn = new Button();
            btnHard = new Button();
            btnMedium = new Button();
            btnEasy = new Button();
            panelMenuButtons = new Panel();
            btnExit = new Button();
            btnHelp = new Button();
            btnSelectDifficulty = new Button();
            panelHeader = new Panel();
            labelGameName = new Label();
            panelMain.SuspendLayout();
            panelMenu.SuspendLayout();
            panelMenuDifficultySelection.SuspendLayout();
            panelMenuButtons.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelMain.BackColor = Color.Transparent;
            panelMain.Controls.Add(panelMenu);
            panelMain.Controls.Add(panelHeader);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1264, 985);
            panelMain.TabIndex = 0;
            // 
            // panelMenu
            // 
            panelMenu.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelMenu.BackColor = Color.Transparent;
            panelMenu.Controls.Add(panelMenuDifficultySelection);
            panelMenu.Controls.Add(panelMenuButtons);
            panelMenu.Location = new Point(0, 200);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(1264, 785);
            panelMenu.TabIndex = 1;
            // 
            // panelMenuDifficultySelection
            // 
            panelMenuDifficultySelection.BackColor = Color.Transparent;
            panelMenuDifficultySelection.Controls.Add(btnReturn);
            panelMenuDifficultySelection.Controls.Add(btnHard);
            panelMenuDifficultySelection.Controls.Add(btnMedium);
            panelMenuDifficultySelection.Controls.Add(btnEasy);
            panelMenuDifficultySelection.Location = new Point(250, 0);
            panelMenuDifficultySelection.Name = "panelMenuDifficultySelection";
            panelMenuDifficultySelection.Size = new Size(250, 785);
            panelMenuDifficultySelection.TabIndex = 1;
            panelMenuDifficultySelection.Visible = false;
            // 
            // btnReturn
            // 
            btnReturn.Cursor = Cursors.Hand;
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.FlatAppearance.MouseDownBackColor = Color.FromArgb(180, 61, 61, 61);
            btnReturn.FlatAppearance.MouseOverBackColor = Color.FromArgb(180, 33, 33, 33);
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnReturn.ForeColor = SystemColors.Control;
            btnReturn.Location = new Point(0, 375);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(250, 125);
            btnReturn.TabIndex = 4;
            btnReturn.Text = "Powrót";
            btnReturn.TextAlign = ContentAlignment.MiddleLeft;
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += BtnReturn_Click;
            // 
            // btnHard
            // 
            btnHard.Cursor = Cursors.Hand;
            btnHard.FlatAppearance.BorderSize = 0;
            btnHard.FlatAppearance.MouseDownBackColor = Color.FromArgb(180, 61, 61, 61);
            btnHard.FlatAppearance.MouseOverBackColor = Color.FromArgb(180, 33, 33, 33);
            btnHard.FlatStyle = FlatStyle.Flat;
            btnHard.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnHard.ForeColor = SystemColors.Control;
            btnHard.Location = new Point(0, 250);
            btnHard.Name = "btnHard";
            btnHard.Size = new Size(250, 125);
            btnHard.TabIndex = 3;
            btnHard.Text = "Trudny";
            btnHard.TextAlign = ContentAlignment.MiddleLeft;
            btnHard.UseVisualStyleBackColor = true;
            btnHard.Click += BtnHard_Click;
            // 
            // btnMedium
            // 
            btnMedium.Cursor = Cursors.Hand;
            btnMedium.FlatAppearance.BorderSize = 0;
            btnMedium.FlatAppearance.MouseDownBackColor = Color.FromArgb(180, 61, 61, 61);
            btnMedium.FlatAppearance.MouseOverBackColor = Color.FromArgb(180, 33, 33, 33);
            btnMedium.FlatStyle = FlatStyle.Flat;
            btnMedium.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnMedium.ForeColor = SystemColors.Control;
            btnMedium.Location = new Point(0, 125);
            btnMedium.Name = "btnMedium";
            btnMedium.Size = new Size(250, 125);
            btnMedium.TabIndex = 2;
            btnMedium.Text = "Średni";
            btnMedium.TextAlign = ContentAlignment.MiddleLeft;
            btnMedium.UseVisualStyleBackColor = true;
            btnMedium.Click += BtnMedium_Click;
            // 
            // btnEasy
            // 
            btnEasy.Cursor = Cursors.Hand;
            btnEasy.FlatAppearance.BorderSize = 0;
            btnEasy.FlatAppearance.MouseDownBackColor = Color.FromArgb(180, 61, 61, 61);
            btnEasy.FlatAppearance.MouseOverBackColor = Color.FromArgb(180, 33, 33, 33);
            btnEasy.FlatStyle = FlatStyle.Flat;
            btnEasy.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnEasy.ForeColor = SystemColors.Control;
            btnEasy.Location = new Point(0, 0);
            btnEasy.Name = "btnEasy";
            btnEasy.Size = new Size(250, 125);
            btnEasy.TabIndex = 1;
            btnEasy.Text = "Łatwy";
            btnEasy.TextAlign = ContentAlignment.MiddleLeft;
            btnEasy.UseVisualStyleBackColor = true;
            btnEasy.Click += BtnEasy_Click;
            // 
            // panelMenuButtons
            // 
            panelMenuButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelMenuButtons.BackColor = Color.Transparent;
            panelMenuButtons.Controls.Add(btnExit);
            panelMenuButtons.Controls.Add(btnHelp);
            panelMenuButtons.Controls.Add(btnSelectDifficulty);
            panelMenuButtons.Location = new Point(0, 0);
            panelMenuButtons.Name = "panelMenuButtons";
            panelMenuButtons.Size = new Size(250, 785);
            panelMenuButtons.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseDownBackColor = Color.FromArgb(180, 61, 61, 61);
            btnExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(180, 33, 33, 33);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnExit.ForeColor = SystemColors.Control;
            btnExit.Location = new Point(0, 250);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(250, 100);
            btnExit.TabIndex = 3;
            btnExit.Text = "Wyjdź";
            btnExit.TextAlign = ContentAlignment.MiddleLeft;
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += BtnExit_Click;
            // 
            // btnHelp
            // 
            btnHelp.Cursor = Cursors.Hand;
            btnHelp.FlatAppearance.BorderSize = 0;
            btnHelp.FlatAppearance.MouseDownBackColor = Color.FromArgb(180, 61, 61, 61);
            btnHelp.FlatAppearance.MouseOverBackColor = Color.FromArgb(180, 33, 33, 33);
            btnHelp.FlatStyle = FlatStyle.Flat;
            btnHelp.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnHelp.ForeColor = SystemColors.Control;
            btnHelp.Location = new Point(0, 125);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(250, 125);
            btnHelp.TabIndex = 2;
            btnHelp.Text = "Pomoc";
            btnHelp.TextAlign = ContentAlignment.MiddleLeft;
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Click += BtnHelp_Click;
            // 
            // btnSelectDifficulty
            // 
            btnSelectDifficulty.BackColor = Color.Transparent;
            btnSelectDifficulty.Cursor = Cursors.Hand;
            btnSelectDifficulty.FlatAppearance.BorderSize = 0;
            btnSelectDifficulty.FlatAppearance.MouseDownBackColor = Color.FromArgb(180, 61, 61, 61);
            btnSelectDifficulty.FlatAppearance.MouseOverBackColor = Color.FromArgb(180, 33, 33, 33);
            btnSelectDifficulty.FlatStyle = FlatStyle.Flat;
            btnSelectDifficulty.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnSelectDifficulty.ForeColor = SystemColors.Control;
            btnSelectDifficulty.Location = new Point(0, 0);
            btnSelectDifficulty.Name = "btnSelectDifficulty";
            btnSelectDifficulty.Size = new Size(250, 125);
            btnSelectDifficulty.TabIndex = 0;
            btnSelectDifficulty.Text = "Rozpocznij Grę";
            btnSelectDifficulty.TextAlign = ContentAlignment.MiddleLeft;
            btnSelectDifficulty.UseVisualStyleBackColor = false;
            btnSelectDifficulty.Click += BtnSelectDifficulty_Click;
            // 
            // panelHeader
            // 
            panelHeader.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelHeader.BackColor = Color.Transparent;
            panelHeader.Controls.Add(labelGameName);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1264, 200);
            panelHeader.TabIndex = 0;
            // 
            // labelGameName
            // 
            labelGameName.AutoSize = true;
            labelGameName.Font = new Font("Segoe UI", 72F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelGameName.ForeColor = SystemColors.Control;
            labelGameName.Location = new Point(340, 30);
            labelGameName.Name = "labelGameName";
            labelGameName.Size = new Size(594, 128);
            labelGameName.TabIndex = 0;
            labelGameName.Text = "Reflex Rehab";
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.rsz_hex_backgrounds_networking;
            ClientSize = new Size(1264, 985);
            Controls.Add(panelMain);
            Name = "MainMenu";
            Text = "Form1";
            panelMain.ResumeLayout(false);
            panelMenu.ResumeLayout(false);
            panelMenuDifficultySelection.ResumeLayout(false);
            panelMenuButtons.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel panelMenu;
        private Panel panelHeader;
        private Panel panelMenuDifficultySelection;
        private Panel panelMenuButtons;
        private Button btnSelectDifficulty;
        private Button btnExit;
        private Button btnHelp;
        private Button btnReturn;
        private Button btnHard;
        private Button btnMedium;
        private Button btnEasy;
        private Label labelGameName;
    }
}