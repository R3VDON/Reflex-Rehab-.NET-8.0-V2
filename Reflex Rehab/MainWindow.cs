using Reflex_Rehab.GamesAndMenuForms;
/// <summary>
///       Namespace Name - Reflex_Rehab.
/// </summary>
namespace Reflex_Rehab {
    /// <summary>Ekran glowny gry.</summary>
    /// <summary>Formularz Windows Forms bedacy glownym ekranem gry.</summary>
    /// \author Konrad Fornal 193083, EiT, Telekomunikacja 1A
    public partial class MainWindow : Form {
        /// <summary>
        /// Obiekt klasy Form wykorzystywany do umieszczania formularza w formularzu
        /// </summary>
        private Form activeForm = new();
        ///<summary>Zdarzenie obslugujace nacisniecie klawisza klawiatury.</summary>
        public event Action<Keys>? KeyPressed;
        /// <summary>Konstruktor formularza MainWindow.</summary>
        /// <summary>Konstruktor formularza MainWindow. Zawiera w sobie wywolanie metody obslugujacej nacisniecie klawisza z klawiatury.</summary>
        /// <returns>void.</returns>
        /// 
        public MainWindow() {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += MainWindow_KeyDown;
        }

        /// <summary>Metoda obslugujaca nacisniecie klawisza na klawiaturze.</summary>
        /// <summary>Metoda obslugujaca nacisniecie klawisza na klawiaturze. Przesyla wynik nacisniecia klawisza do zdarzenia <see cref="KeyPressed"/></summary>
        /// <returns>void.</returns> 
        private void MainWindow_KeyDown(object? sender, KeyEventArgs e) {
            KeyPressed?.Invoke(e.KeyCode);
        }

        /// <summary>Metoda otwierajaca nowy formularz.</summary>
        /// <summary>Metoda otwierajaca nowy formularz w panelu <see cref="panelWelcomeScreen"/> wraz z jego podstawowymi ustawieniami.</summary>
        /// <param name="childForm">Typem parametru childForm jest: System.Windows.Forms.Form.</param>
        /// <returns>void.</returns>
        private void OpenChildForm(Form childForm) {
            activeForm?.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelWelcomeScreen.Controls.Add(childForm);
            panelWelcomeScreen.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        /// <summary>Metoda przycisku na ekranie powitalnym.</summary>
        /// <summary>Metoda tworzy obiekt klasy <see cref="MainMenu"/>, ktory jest nastepnie otwarty w celu wyswietlenia menu glownego.</summary>
        /// <returns>void.</returns>
        private void BtnWelcomeScreen_Click(object sender, EventArgs e) {
            MainMenu mainMenu = new(this);
            OpenChildForm(mainMenu);
        }
    }
}
