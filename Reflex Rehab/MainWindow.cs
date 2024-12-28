using Reflex_Rehab.GamesAndMenuForms;
/// <summary>
///       Namespace Name - Reflex_Rehab.
/// </summary>
namespace Reflex_Rehab {
    /// <summary>Ekran g��wny gry.</summary>
    /// <summary>Formularz Windows Forms b�d�cy g��wnym ekranem gry.</summary>
    /// \author Konrad Fornal 193083, EiT, Telekomunikacja 1A
    public partial class MainWindow : Form {
        /// <summary>
        /// Obiekt klasy Form wykorzystywany do umieszczania formularza w formularzu
        /// </summary>
        private Form activeForm = new();
        ///<summary>Zdarzenie obs�uguj�ce naci�ni�cie klawisza klawiatury.</summary>
        public event Action<Keys>? KeyPressed;
        /// <summary>Konstruktor formularza MainWindow.</summary>
        /// <summary>Konstruktor formularza MainWindow. Zawiera w sobie wywo�anie metody obs�uguj�cej naci�ni�cie klawisza z klawiatury.</summary>
        /// <returns>void.</returns>
        /// 
        public MainWindow() {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += MainWindow_KeyDown;
        }

        /// <summary>Metoda obs�uguj�ca naci�ni�cie klawisza na klawiaturze.</summary>
        /// <summary>Metoda obs�uguj�ca naci�ni�cie klawisza na klawiaturze. Przesy�a wynik naci�ni�cia klawisza do zdarzenia <see cref="KeyPressed"/></summary>
        /// <returns>void.</returns> 
        private void MainWindow_KeyDown(object? sender, KeyEventArgs e) {
            KeyPressed?.Invoke(e.KeyCode);
        }

        /// <summary>Metoda otwieraj�ca nowy formularz.</summary>
        /// <summary>Metoda otwieraj�ca nowy formularz w panelu <see cref="panelWelcomeScreen"/> wraz z jego podstawowymi ustawieniami.</summary>
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
        /// <summary>Metoda tworzy obiekt klasy <see cref="MainMenu"/>, kt�ry jest nast�pnie otwarty w celu wy�wietlenia menu g��wnego.</summary>
        /// <returns>void.</returns>
        private void BtnWelcomeScreen_Click(object sender, EventArgs e) {
            MainMenu mainMenu = new(this);
            OpenChildForm(mainMenu);
        }
    }
}
