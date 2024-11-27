namespace Reflex_Rehab {
    partial class MainWindow {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            panelWelcomeScreen = new Panel();
            btnWelcomeScreen = new Button();
            labelWelcomeScreen = new Label();
            panelWelcomeScreen.SuspendLayout();
            SuspendLayout();
            // 
            // panelWelcomeScreen
            // 
            panelWelcomeScreen.BackColor = Color.Transparent;
            panelWelcomeScreen.BackgroundImage = Properties.Resources.rsz_hex_backgrounds_networking;
            panelWelcomeScreen.Controls.Add(btnWelcomeScreen);
            panelWelcomeScreen.Controls.Add(labelWelcomeScreen);
            panelWelcomeScreen.Dock = DockStyle.Fill;
            panelWelcomeScreen.Location = new Point(0, 0);
            panelWelcomeScreen.Name = "panelWelcomeScreen";
            panelWelcomeScreen.Size = new Size(1264, 985);
            panelWelcomeScreen.TabIndex = 0;
            // 
            // btnWelcomeScreen
            // 
            btnWelcomeScreen.BackColor = Color.Transparent;
            btnWelcomeScreen.FlatAppearance.BorderSize = 0;
            btnWelcomeScreen.FlatAppearance.MouseDownBackColor = Color.FromArgb(180, 61, 61, 61);
            btnWelcomeScreen.FlatAppearance.MouseOverBackColor = Color.FromArgb(180, 33, 33, 33);
            btnWelcomeScreen.FlatStyle = FlatStyle.Flat;
            btnWelcomeScreen.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnWelcomeScreen.ForeColor = SystemColors.Control;
            btnWelcomeScreen.Location = new Point(532, 500);
            btnWelcomeScreen.Name = "btnWelcomeScreen";
            btnWelcomeScreen.Size = new Size(200, 100);
            btnWelcomeScreen.TabIndex = 1;
            btnWelcomeScreen.Text = "Wejdź do gry";
            btnWelcomeScreen.UseVisualStyleBackColor = false;
            btnWelcomeScreen.Click += BtnWelcomeScreen_Click;
            // 
            // labelWelcomeScreen
            // 
            labelWelcomeScreen.AutoSize = true;
            labelWelcomeScreen.BackColor = Color.Transparent;
            labelWelcomeScreen.Font = new Font("Segoe UI", 72F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelWelcomeScreen.ForeColor = SystemColors.Control;
            labelWelcomeScreen.Location = new Point(335, 250);
            labelWelcomeScreen.Name = "labelWelcomeScreen";
            labelWelcomeScreen.Size = new Size(594, 128);
            labelWelcomeScreen.TabIndex = 0;
            labelWelcomeScreen.Text = "Reflex Rehab";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1264, 985);
            Controls.Add(panelWelcomeScreen);
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reflex Rehab";
            panelWelcomeScreen.ResumeLayout(false);
            panelWelcomeScreen.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelWelcomeScreen;
        private Button btnWelcomeScreen;
        private Label labelWelcomeScreen;
    }
}
