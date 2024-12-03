using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reflex_Rehab.GameAndMenuForms {
    public partial class MainMenu : Form {
        private Form? activeForm = null;
        private short difficultySelect;
        private readonly MainWindow mainWindow;
        public MainMenu(MainWindow mainWindow) {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }
        private void OpenChildForm(Form childForm) {
            activeForm?.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void OnWinConditionChanged(int winCondition) {
            if (winCondition == 1) {
                MessageBox.Show("Ukończyłeś poziom łatwy!", "Gratulacje");
                difficultySelect = 1;
            }
            else if (winCondition == 2) {
                MessageBox.Show("Ukończyłeś poziom średni!", "Gratulacje");
                difficultySelect = 2;
            }
            else {
                MessageBox.Show("Ukończyłeś poziom trudny!", "Gratulacje");
                difficultySelect = 3;
        }
        }

        private void BtnSelectDifficulty_Click(object sender, EventArgs e) {
            panelMenuDifficultySelection.Show();
            btnSelectDifficulty.BackColor = Color.FromArgb(180, 33, 33, 33);
        }
        private void BtnEasy_Click(object sender, EventArgs e) {
            GC.Collect();
            LevelEasy easy = new(mainWindow);
            easy.WinConditionChanged += OnWinConditionChanged;
            OpenChildForm(easy);
        }

        private void BtnMedium_Click(object sender, EventArgs e) {
            GC.Collect();
            if (difficultySelect >= 1) {
                OpenChildForm(new LevelMedium());
            }
            else {
                MessageBox.Show("Musisz pokonać pierwszy etap!");
            }
        }

        private void BtnHard_Click(object sender, EventArgs e) {
            GC.Collect();
            if (difficultySelect >= 2) {
                OpenChildForm(new LevelHard());
            }
            else {
                MessageBox.Show("Musisz pokonać drugi etap!");
            }
        }

        private void BtnReturn_Click(object sender, EventArgs e) {
            panelMenuDifficultySelection.Hide();
            btnSelectDifficulty.BackColor = Color.Transparent;
        }

        private void BtnHelp_Click(object sender, EventArgs e) {

        }

        private void BtnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
