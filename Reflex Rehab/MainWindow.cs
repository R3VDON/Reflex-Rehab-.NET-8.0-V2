using Reflex_Rehab.GameAndMenuForms;

namespace Reflex_Rehab {
    public partial class MainWindow : Form {
        private Form activeForm = new();
        public event Action<Keys>? KeyPressed;
        public MainWindow() {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += MainWindow_KeyDown;
        }

        private void MainWindow_KeyDown(object? sender, KeyEventArgs e) {
            KeyPressed?.Invoke(e.KeyCode);
        }
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

        private void BtnWelcomeScreen_Click(object sender, EventArgs e) {
            MainMenu mainMenu = new(this);
            OpenChildForm(mainMenu);
        }
    }
}
