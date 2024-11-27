namespace Reflex_Rehab {
    public partial class MainWindow : Form {
        private Form activeForm = new Form();
        public MainWindow() {
            InitializeComponent();
        }
        private void OpenChildForm(Form childForm, object btnSender) {
            if (activeForm != null) {
                activeForm.Close();
            }
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
            OpenChildForm(new GameAndMenuForms.MainMenu(), sender);
        }
    }
}
