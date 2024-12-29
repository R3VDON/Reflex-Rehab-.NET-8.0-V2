using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
///       Namespace Name - Reflex_Rehab.GamesAndMenuForms.
/// </summary>
namespace Reflex_Rehab.GamesAndMenuForms {
    /// <summary>Menu glowne</summary>
    /// <summary>Formularz Windows Forms stanowiacy menu glowne gry Reflex Rehab.</summary>
    /// \author Konrad Fornal 193083, EiT, Telekomunikacja 1A
    public partial class MainMenu : Form {
        /// <summary>
        /// Obiekt klasy Form wykorzystywany do umieszczania formularza w formularzu
        /// </summary>
        private Form? activeForm = null;
        /// <summary>
        /// Zmienna przechowujaca informacje o odblokowanych poziomach trudnosci.
        /// </summary>
        private short difficultySelect;
        /// <summary>
        /// Obiekt klasy <see cref="MainWindow"/> wykorzystywany w celu obslugi klawiatury.
        /// </summary>
        private readonly MainWindow mainWindow;

        /// <summary>Konstruktor klasy <see cref="MainMenu"/></summary>
        /// <summary>Konstruktor klasy <see cref="MainMenu"/> przyjmujacy parametr w postaci obiektu formularza <see cref="MainWindow"/></summary>
        /// <param name="mainWindow">Typem parametru mainWindow jest: Reflex_Rehab.MainWindow.</param>
        /// <returns>void.</returns>
        public MainMenu(MainWindow mainWindow) {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        /// <summary>Metoda otwierajaca nowy formularz.</summary>
        /// <summary>Metoda otwierajaca nowy formularz w panelu <see cref="panelMain"/> wraz z jego podstawowymi ustawieniami.</summary>
        /// <param name="childForm">Typem parametru childForm jest: System.Windows.Forms.Form.</param>
        /// <returns>void.</returns>
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


        /// <summary>Metoda sprawdzajaca, ktore poziomy przeszedl gracz.</summary>
        /// <summary>
        /// Metoda ta sprawdza, ktory poziom przeszedl gracz i wyswietla stosowny komunikat. 
        /// W przypadku pierwszego przejscia ustawiana jest flaga odblokowania kolejnego poziomu.
        /// </summary>
        /// <param name="winCondition">Typem parametru winCondition jest: int.</param>
        /// <returns>void.</returns>
        private void OnWinConditionChanged(int winCondition) {
            if (winCondition == 1) {
                MessageBox.Show("Ukonczyłeś poziom łatwy!", "Gratulacje");
                if (difficultySelect == 0)
                    difficultySelect = 1;
            }
            else if (winCondition == 2) {
                MessageBox.Show("Ukonczyłeś poziom średni!", "Gratulacje");
                if (difficultySelect <= 1)
                    difficultySelect = 2;
            }
            else {
                MessageBox.Show("Ukonczyłeś poziom trudny!", "Gratulacje");
                if (difficultySelect <= 2)
                    difficultySelect = 3;
            }
        }

        /// <summary>Metoda obslugujaca nacisniecie przycisku wyboru poziomu trudnosci.</summary>
        /// <summary>
        /// Metoda obslugujaca nacisniecie przycisku wyboru poziomu trudnosci. 
        /// Akcja wynikowa jest wyswietlenie panelu z przyciskami poziomow trudnosci.
        /// </summary>
        /// <param name="sender"> Typem danych parametru sender jest: object.</param>
        /// <param name="e"> Typem danych parametru e jest: System.EventArgs.</param>
        /// <returns>void.</returns>
        private void BtnSelectDifficulty_Click(object sender, EventArgs e) {
            panelMenuDifficultySelection.Show();
            btnSelectDifficulty.BackColor = Color.FromArgb(180, 33, 33, 33);
        }

        /// <summary>Metoda obslugujaca nacisniecie przycisku uruchamiajacego poziom latwy.</summary>
        /// <summary>
        /// Metoda obslugujaca nacisniecie przycisku uruchamiajacego poziom sredni. 
        /// Akcja wynikowa jest uruchomienie latwego poziomu trudnosci.
        /// </summary>
        /// <param name="sender"> Typem danych parametru sender jest: object.</param>
        /// <param name="e"> Typem danych parametru e jest: System.EventArgs.</param>
        /// <returns>void.</returns>
        private void BtnEasy_Click(object sender, EventArgs e) {
            GC.Collect();
            LevelEasy easy = new(mainWindow);
            easy.WinConditionChanged += OnWinConditionChanged;
            OpenChildForm(easy);
        }


        /// <summary>Metoda obslugujaca nacisniecie przycisku uruchamiajacego poziom sredni.</summary>
        /// <summary>
        /// Metoda obslugujaca nacisniecie przycisku uruchamiajacego poziom sredni. 
        /// Akcja wynikowa jest uruchomienie sredniego poziomu trudnosci.
        /// </summary>
        /// <param name="sender"> Typem danych parametru sender jest: object.</param>
        /// <param name="e"> Typem danych parametru e jest: System.EventArgs.</param>
        /// <returns>void.</returns>
        private void BtnMedium_Click(object sender, EventArgs e) {
            GC.Collect();
            if (difficultySelect >= 1) {
                LevelMedium medium = new(mainWindow);
                medium.WinConditionChanged += OnWinConditionChanged;
                OpenChildForm(medium);
            }
            else {
                MessageBox.Show("Musisz pokonać pierwszy poziom!");
            }
        }


        /// <summary>Metoda obslugujaca nacisniecie przycisku uruchamiajacego poziom trudny.</summary>
        /// <summary>
        /// Metoda obslugujaca nacisniecie przycisku uruchamiajacego poziom trudny. 
        /// Akcja wynikowa jest uruchomienie sredniego poziomu trudnosci.
        /// </summary>
        /// <param name="sender"> Typem danych parametru sender jest: object.</param>
        /// <param name="e"> Typem danych parametru e jest: System.EventArgs.</param>
        /// <returns>void.</returns>
        private void BtnHard_Click(object sender, EventArgs e) {
            GC.Collect();
            if (difficultySelect >= 2) {
                LevelHard hard = new(mainWindow);
                hard.WinConditionChanged += OnWinConditionChanged;
                OpenChildForm(hard);
            }
            else {
                MessageBox.Show("Musisz pokonać drugi poziom!");
            }
        }


        /// <summary>Metoda obslugujaca nacisniecie przycisku zamykajacego wybor poziomu.</summary>
        /// <summary>
        /// Metoda obslugujaca nacisniecie przycisku zamykajacego wybor poziomu. 
        /// Akcja wynikowa jest zamkniecie panelu z przyciskami poziomow trudnosci.
        /// </summary>
        /// <param name="sender"> Typem danych parametru sender jest: object.</param>
        /// <param name="e"> Typem danych parametru e jest: System.EventArgs.</param>
        /// <returns>void.</returns>
        private void BtnReturn_Click(object sender, EventArgs e) {
            panelMenuDifficultySelection.Hide();
            btnSelectDifficulty.BackColor = Color.Transparent;
        }


        /// <summary>Metoda obslugujaca nacisniecie przycisku pomocy.</summary>
        /// <summary>
        /// Metoda obslugujaca nacisniecie przycisku pomocy. 
        /// Akcja wynikowa jest wyswietlenie panelu z krotkim opisem i pomoca.
        /// </summary>
        /// <param name="sender"> Typem danych parametru sender jest: object.</param>
        /// <param name="e"> Typem danych parametru e jest: System.EventArgs.</param>
        /// <returns>void.</returns>
        private void BtnHelp_Click(object sender, EventArgs e) {
            panelMenu.Hide();
            panelHelp.Show();
            labelHelp.Show();
            btnBackToMenu.Show();
        }


        /// <summary>Metoda obslugujaca nacisniecie przycisku wyjscia z programu.</summary>
        /// <summary>
        /// Metoda obslugujaca nacisniecie przycisku wyjscia z programu. 
        /// Akcja wynikowa jest zamkniecie programu.
        /// </summary>
        /// <param name="sender"> Typem danych parametru sender jest: object.</param>
        /// <param name="e"> Typem danych parametru e jest: System.EventArgs.</param>
        /// <returns>void.</returns>
        private void BtnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        /// <summary>Metoda obslugujaca nacisniecie przycisku powrotu do menu z okna pomocy.</summary>
        /// <summary>
        /// Metoda obslugujaca nacisniecie przycisku powrotu do menu z okna pomocy. 
        /// Akcja wynikowa jest wyswietlenie ekranu menu.
        /// </summary>
        /// <param name="sender"> Typem danych parametru sender jest: object.</param>
        /// <param name="e"> Typem danych parametru e jest: System.EventArgs.</param>
        /// <returns>void.</returns>
        private void btnBackToMenu_Click(object sender, EventArgs e) {
            panelHelp.Hide();
            labelHelp.Hide();
            btnBackToMenu.Hide();
            panelMenu.Show();
        }
    }
}
