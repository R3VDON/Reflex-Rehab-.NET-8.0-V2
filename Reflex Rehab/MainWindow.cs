using Reflex_Rehab.GamesAndMenuForms;
/// <summary>
///       Namespace Name - Reflex_Rehab.
/// </summary>
namespace Reflex_Rehab {
    /// <summary>Ekran g³ówny gry.</summary>
    /// <summary>Formularz Windows Forms bêd¹cy g³ównym ekranem gry.</summary>
    /// \author Konrad Fornal 193083, EiT, Telekomunikacja 1A
    public partial class MainWindow : Form {
        /// <summary>
        /// Obiekt klasy Form wykorzystywany do umieszczania formularza w formularzu
        /// </summary>
        private Form activeForm = new();
        ///<summary>Zdarzenie obs³uguj¹ce naciœniêcie klawisza klawiatury.</summary>
        public event Action<Keys>? KeyPressed;
        /// <summary>Konstruktor formularza MainWindow.</summary>
        /// <summary>Konstruktor formularza MainWindow. Zawiera w sobie wywo³anie metody obs³uguj¹cej naciœniêcie klawisza z klawiatury.</summary>
        /// <returns>void.</returns>
        /// 
        public MainWindow() {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += MainWindow_KeyDown;
        }

        /// <summary>Metoda obs³uguj¹ca naciœniêcie klawisza na klawiaturze.</summary>
        /// <summary>Metoda obs³uguj¹ca naciœniêcie klawisza na klawiaturze. Przesy³a wynik naciœniêcia klawisza do zdarzenia <see cref="KeyPressed"/></summary>
        /// <returns>void.</returns> 
        private void MainWindow_KeyDown(object? sender, KeyEventArgs e) {
            KeyPressed?.Invoke(e.KeyCode);
        }

        /// <summary>Metoda otwieraj¹ca nowy formularz.</summary>
        /// <summary>Metoda otwieraj¹ca nowy formularz w panelu <see cref="panelWelcomeScreen"/> wraz z jego podstawowymi ustawieniami.</summary>
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
        /// <summary>Metoda tworzy obiekt klasy <see cref="MainMenu"/>, który jest nastêpnie otwarty w celu wyœwietlenia menu g³ównego.</summary>
        /// <returns>void.</returns>
        private void BtnWelcomeScreen_Click(object sender, EventArgs e) {
            MainMenu mainMenu = new(this);
            OpenChildForm(mainMenu);
        }
    }
}
