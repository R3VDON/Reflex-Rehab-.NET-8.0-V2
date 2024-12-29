using Reflex_Rehab.GamesAndMenuForms;
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
    /// <summary>latwy poziom gry.</summary>
    /// <summary>Formularz Windows Forms stanowiacy poziom latwy gry Reflex Rehab. Formularz ten dziedziczy po klasie <see cref="AbstractMainLevel"/></summary>
    /// \author Konrad Fornal 193083, EiT, Telekomunikacja 1A
    internal partial class LevelEasy : AbstractMainLevel {
        /// <summary>Zdarzenie obslugujace zmiane parametru winCondition w celu odblokowania kolejnego poziomu trudnosci. </summary>
        internal event Action<int>? WinConditionChanged;
        /// <summary>Obiekt klasy Timer sluzacy jako zegar dla pierwszego etapu gry.</summary>
        private readonly System.Windows.Forms.Timer gameTimer = new();
        /// <summary>Obiekt klasy Timer sluzacy jako zegar dla drugiego etapu gry.</summary>
        private readonly System.Windows.Forms.Timer labyrinthTimer = new();
        /// <summary>Obiekt klasy Random stosowany do tworzenia pseudolosowych pytan matematycznych oraz blednych odpowiedzi do tych pytan.</summary>
        private readonly Random random = new();
        /// <summary>Lista pozycji fragmentow klucza w labiryncie</summary>
        private readonly List<Point> keyFragments = [];
        /// <summary>Tablica sluzaca do przechowywania ukladu labiryntu dla danego poziomu gry.</summary>
        private int[,] labyrinthMap = null!;
        /// <summary>Zmienna przechowujaca liczbe bedaca poprawna odpowiedzia na pytanie.</summary>
        private int correctAnswer;
        /// <summary>Zmienna przechowujaca odpowiedz gracza na pytanie. Wykorzystywana przy pytaniach w labiryncie.</summary>
        private int userAnswer;
        /// <summary>Zmienna przechowujaca wynik uzyskany w pierwszym etapie gry.</summary>
        private int score = 0;
        /// <summary>Zmienna przechowujaca pozostaly czas gry.</summary>
        private int timeLeft;
        /// <summary>Obiekt przechowujacy pozycje gracza w labiryncie.</summary>
        private Point playerPosition;
        /// <summary>Zmienna przechowujaca ilosc zebranych przez gracza fragmentow klucza.</summary>
        private int collectedFragments;
        /// <summary>Zmienna przechowujaca liczbe fragmentow klucza wystepujacych w labiryncie.</summary>
        private int totalKeys;
        /// <summary>Zmienna przechowujaca informacje o tym ktory poziom gry zostal wygrany.</summary>
        private int winCondition = 0;
        /// <summary>Zmienna przechowujaca informacje czy gracz przeszedl pierwszy etap poziomu.</summary>
        private bool stageComplete = false;
        /// <summary>Obiekt wyswietlajacy wynik uzyskany przez gracza w trakcie rozgrywki.</summary>
        private Label scoreLabel = null!;
        /// <summary>Obiekt wyswietlajacy pytanie, na ktore ma odpowiedziec gracz.</summary>
        private Label questionLabel = null!;
        /// <summary>Obiekt wyswietlajacy postepy w zbieraniu fragmentow klucza w trakcie etapu drugiego danego poziomu.</summary>
        private Label labScoreLabel = null!;
        /// <summary>Kontenerem na wszystkie pozostale obiekty w formularzu.</summary>
        private readonly DoubleBufferedPanel mainPanel = new() {
            Location = new Point(0, 0),
            Size = new Size(1264, 985),
            BackgroundImage = Properties.Resources.rsz_hex_backgrounds_networking
        };
        /// <summary>Kontener, w ktorym zawarte sa elementy stanowiace ekran podsumowania postepow w grze. Zawarty jest w nim takze przycisk wyjscia z poziomu do menu glownego.</summary>
        private readonly DoubleBufferedPanel scoreTimePanel = new() {
            Location = new Point(0, 0),
            Size = new Size(1264, 160),
            BackColor = Color.Transparent
        };
        /// <summary>Kontener, w ktorym znajduja sie wslasciwe elementy gry, to jest odpowiedzi do pytan oraz labirynt.</summary>
        private readonly DoubleBufferedPanel gamePanel = new() {
            Location = new Point(0, 160),
            Size = new Size(1264, 825),
            BackColor = Color.Transparent
        };

        /// <summary>Metoda tworzaca przycisk zamykajacy ekran gry.</summary> 
        /// <summary>Metoda tworzaca przycisk zamykajacy obecnie wyswietlany ekran gry. W tej klasie zawarta jest implementacja metody.</summary>
        /// <returns>System.Windows.Forms.Button.</returns>
        /// \see Deklaracja w klasie abstracyjnej - <see cref="AbstractMainLevel.CreateCloseButton"/>
        protected override Button CreateCloseButton() {
            return new Button {
                Name = "CloseButton",
                Text = "Powrót do menu",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Size = new Size(200, 80),
                Location = new Point(1050, 30),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = {
                    BorderSize = 0,
                    MouseOverBackColor = Color.FromArgb(180, 33, 33, 33),
                },
                BackColor = Color.Transparent,
                ForeColor = SystemColors.Control,
                Cursor = Cursors.Hand
            };
        }

        /// <summary>Metoda tworzaca obiekt wyswietlajacy pozostaly czas gry.</summary>
        /// <summary>Metoda tworzaca obiekt typu label sluzacy do wyswietlania pozostalego czasu gry. W tej klasie zawarta jest implementacja metody.</summary>
        /// <returns>System.Windows.Forms.Label.</returns>
        /// \see Deklaracja w klasie abstracyjnej - <see cref="AbstractMainLevel.CreateTimerLabel"/>
        protected override Label CreateTimerLabel() {
            return new Label {
                Name = "TimerLabel",
                Text = $"Czas: {timeLeft} s",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                Location = new Point(32, 18),
                ForeColor = SystemColors.Control,
                BackColor = Color.Transparent,
                AutoSize = true
            };
        }

        /// <summary>Metoda tworzaca obiekt wyswietlajacy wynik pierwszego etapu danego poziomu gry.</summary> 
        /// <summary>Metoda tworzaca obiekt typu label sluzacy do wyswietlania wyniku podczas pierwszego etapu gry na danym poziomie trudnosci. W tej klasie zawarta jest implementacja metody.</summary>
        /// <returns>System.Windows.Forms.Label.</returns>
        /// \see Deklaracja w klasie abstracyjnej - <see cref="AbstractMainLevel.CreateScoreLabel"/>
        protected override Label CreateScoreLabel() {
            return new Label {
                Name = "ScoreLabel",
                Text = $"Wynik: {score}",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                Location = new Point(32, 54),
                ForeColor = SystemColors.Control,
                BackColor = Color.Transparent,
                AutoSize = true
            };
        }

        /// <summary>Metoda tworzaca obiekt wyswietlajacy postepy w drugim etapie danego poziomu gry.</summary>  
        /// <summary>Metoda tworzaca obiekt typu Label sluzacy do wyswietlania podsumowania postepow gracza podczas drugiego etapu gry na danym poziomie trudnosci. W tej klasie zawarta jest implementacja metody.</summary>
        /// <returns>System.Windows.Forms.Label.</returns> 
        /// \see Deklaracja w klasie abstracyjnej - <see cref="AbstractMainLevel.CreateLabyrinthScoreLabel"/>
        protected override Label CreateLabyrinthScoreLabel() {
            return new Label {
                Name = "LabyrinthScoreLabel",
                Text = $"Zebrano {collectedFragments} na {totalKeys} fragmentów klucza",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                Location = new Point(32, 54),
                ForeColor = SystemColors.Control,
                BackColor = Color.Transparent,
                AutoSize = true
            };
        }


        /// <summary>Metoda tworzaca obiekt wyswietlajacy pytanie matematyczne.</summary> 
        /// <summary>
        /// Metoda tworzaca obiekt typu Label sluzacy do wyswietlania pytania matematycznego, na ktore gracz musi znalesc odpowiedz.
        /// Metoda ta przyjmuje parametr questionText typu string przechowujacy pytanie, ktore jest wyswietlane na ekranie. W tej klasie zawarta jest implementacja metody.
        /// </summary>
        /// <param name="questionText"> Przechowuje pytanie generowane przez metode <see cref="LevelEasy.GenerateQuestion"/>. Typem danych parametru questionTest jest: string.</param>
        /// <returns>System.Windows.Forms.Label.</returns>
        /// \see Deklaracja w klasie abstracyjnej - <see cref="AbstractMainLevel.CreateQuestionLabel"/>
        protected override Label CreateQuestionLabel(string questionText) {
            return new Label {
                Text = questionText,
                Font = new Font("Arial", 36, FontStyle.Bold),
                Location = new Point(540, 40),
                ForeColor = SystemColors.Control,
                BackColor = Color.Transparent,
                AutoSize = true
            };
        }


        /// <summary>Konstruktor klasy LevelEasy</summary>
        /// <summary>Konstruktor klasy LevelEasy. Pryjmuje on parametr w postaci obiektu klasy glownej MainWindows do obslugi klawiatury. Wywolywane sa w nim metody inicjalizujace poziom gry.</summary>
        /// <param name="mainWindow">Jest to obiekt klasy <see cref="MainWindow"/>. Typem danych parametru mainWindow jest: Reflex_Rehab.MainWindow.</param>
        /// <returns>void.</returns>
        public LevelEasy(MainWindow mainWindow) {
            InitializeComponent();
            mainWindow.KeyPressed += MainWindow_KeyPressed;
            InitializeGame();
            GenerateQuestion();
            GenerateAnwserButtons();
        }


        /// <summary>Metoda odpowiadajaca za inicjalizacje ekranu gry.</summary> 
        /// <summary>Metoda odpowiadajaca za inicjalizacje ekranu gry. W metodzie ustawiane sa parametry zegara oraz tworzone sa obiekty zawarte w panelu <see cref="scoreTimePanel"/>.</summary>
        /// <returns>void.</returns>
        /// \see Deklaracja w klasie abstracyjnej - <see cref="AbstractMainLevel.InitializeGame"/>
        protected override void InitializeGame() {
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;
            timeLeft = 30;
            this.Controls.Add(mainPanel);
            mainPanel.Controls.Add(scoreTimePanel);
            mainPanel.Controls.Add(gamePanel);

            Label timerLabel = CreateTimerLabel();
            scoreTimePanel.Controls.Add(timerLabel);

            scoreTimePanel.Controls.Add(scoreLabel);
            Button closeButton = CreateCloseButton();
            closeButton.Click += CloseButton_Click;
            scoreTimePanel.Controls.Add(closeButton);
            gameTimer.Start();
        }


        /// <summary>Metoda odswierzajaca pozostaly czas pierwszego etapu gry.</summary> 
        /// <summary>Metoda odswierzajaca pozostaly czas gry wyswietlany w <see cref="scoreTimePanel"/> co sekunde. W przypadku gdy czas osiaga zero wyswietlany jest komunikat o zakonczeniu gry.</summary>
        /// <param name="sender"> Typem danych parametru sender jest: object.</param>
        /// <param name="e"> Typem danych parametru e jest: System.EventArgs.</param>
        /// <returns>void.</returns>
        /// \see Deklaracja w klasie abstracyjnej - <see cref="AbstractMainLevel.GameTimer_Tick"/>
        protected override void GameTimer_Tick(object? sender, EventArgs e) {
            timeLeft--;
            if (scoreTimePanel.Controls["TimerLabel"] is Label timerLabel) {
                timerLabel.Text = $"Czas: {timeLeft} s";
            }

            if (timeLeft <= 0) {
                gameTimer.Stop();
                MessageBox.Show($"Koniec czasu! Twój wynik: {score}. Spróbuj ponownie!");
                this.Close();
                GC.Collect();
            }
        }


        /// <summary>Metoda generujaca pytania matematyczne.</summary> 
        /// <summary>
        /// Metoda generujaca pytania matematyczne o okreslonym poziomie trudnosci z okreslonego zakresu operacji arytmetycznych. 
        /// W tej klasie zawarta jest implementacja metody z czterema podstawowymi operacjami matematycznymi: dodawaniem, odejmowaniem, mnozeniem i dzieleniem. 
        /// </summary>
        /// <returns>void.</returns>
        /// \see Deklaracja w klasie abstracyjnej - <see cref="AbstractMainLevel.GenerateQuestion"/>
        protected override void GenerateQuestion() {
            if (!stageComplete) {
                scoreTimePanel.Controls.Remove(scoreLabel);
                scoreLabel = CreateScoreLabel();
                scoreTimePanel.Controls.Add(scoreLabel);
            }
            int a = random.Next(1, 10), b = random.Next(1, 10);
            string operation, questionText;
            switch (random.Next(0, 4)) {
                case 0:
                    operation = "+";
                    correctAnswer = a + b;
                    questionText = $"{a} {operation} {b} = ?";
                    break;
                case 1:
                    operation = "-";
                    correctAnswer = a - b;
                    questionText = $"{a} {operation} {b} = ?";
                    break;
                case 2:
                    operation = "*";
                    correctAnswer = a * b;
                    questionText = $"{a} {operation} {b} = ?";
                    break;
                default:
                    operation = "/";
                    b = b == 0 ? 1 : b;
                    a = a - (a % b);
                    correctAnswer = a / b;
                    questionText = $"{a} {operation} {b} = ?";
                    break;
            }
            if (!stageComplete) {
                scoreTimePanel.Controls.Remove(questionLabel);
                questionLabel = CreateQuestionLabel(questionText);
                scoreTimePanel.Controls.Add(questionLabel);
            }
            else {
                string answer = Microsoft.VisualBasic.Interaction.InputBox(questionText, "Pytanie strażnika", "");

                if (int.TryParse(answer, out userAnswer) && userAnswer == correctAnswer) {
                    MessageBox.Show("Dobrze! Odpowiedziałeś na moje pytanie.");
                }
                else {
                    MessageBox.Show($"Źle! Poprawna odpowiedź to {correctAnswer}.");
                }
            }
        }


        /// <summary>Metoda tworzaca przyciski z odpowiedziami.</summary> 
        /// <summary>Metoda tworzaca przyciski z odpowiedziami na wyswietlne pytania. Tworzona jest jedna odpowiedz poprawna i trzy bledne. Polozenie jest ustalane w sposob pseudolosowy.</summary>
        /// <returns>void.</returns>
        /// \see Deklaracja w klasie abstracyjnej - <see cref="AbstractMainLevel.GenerateAnwserButtons"/>
        protected override void GenerateAnwserButtons() {
            int correctButtonIndex = random.Next(4);
            List<Rectangle> placedButtons = [];

            for (int i = 0; i < 4; i++) {
                Button answerButton = new() {
                    Size = new Size(80, 40),
                    Font = new Font("Arial", 12)
                };

                if (i == correctButtonIndex) {
                    answerButton.Text = correctAnswer.ToString();
                    answerButton.Click += CorrectAnswer_Click;
                }
                else {
                    int wrongAnswer;
                    do {
                        wrongAnswer = correctAnswer + random.Next(-10, 10);
                    } while (wrongAnswer == correctAnswer);

                    answerButton.Text = wrongAnswer.ToString();
                    answerButton.Click += WrongAnswer_Click;
                }

                Point location;
                Rectangle newButtonArea;
                do {
                    location = new Point(
                        random.Next(20, this.gamePanel.Width - answerButton.Width),
                        random.Next(100, this.gamePanel.Height - answerButton.Height)
                    );
                    newButtonArea = new Rectangle(location, answerButton.Size);
                } while (placedButtons.Any(rect => rect.IntersectsWith(newButtonArea)));

                placedButtons.Add(newButtonArea);
                answerButton.Location = location;
                gamePanel.Controls.Add(answerButton);
            }
        }

        /// <summary>Metoda obslugujaca nacisniecie prawidlowej odpowiedzi.</summary> 
        /// <summary>
        /// Metoda obslugujaca nacisniecie prawidlowej odpowiedzi na wyswietlane pytanie oraz uzyskanie wymaganego wyniku. 
        /// Dla klasy <see cref="LevelEasy"/> prog wygranej ustawiony jest na 10 punktow, za kazda poprawna odpowiedz przyznawany punkt, a ilosc czasu doliczonego za poprawna odpowiedz wynosi 1 sekunde.
        /// </summary>
        /// <param name="sender"> Typem danych parametru sender jest: object.</param>
        /// <param name="e"> Typem danych parametru e jest: System.EventArgs.</param>
        /// <returns>void.</returns>
        /// \see Deklaracja w klasie abstracyjnej - <see cref="AbstractMainLevel.CorrectAnswer_Click"/>
        protected override void CorrectAnswer_Click(object? sender, EventArgs e) {
            score++;
            if (score == 10) {
                gameTimer.Stop();
                gamePanel.Controls.Clear();
                scoreTimePanel.Controls.Clear();
                GC.Collect();
                stageComplete = true;
                InitializeLabyrinth();
            }
            else {
                timeLeft += 1;
                gamePanel.Controls.Clear();
                GenerateQuestion();
                GenerateAnwserButtons();
            }
        }

        /// <summary>Metoda obslugujaca nacisniecie zlej odpowiedzi.</summary> 
        /// <summary>Metoda obslugujaca nacisniecie zlej odpowiedzi na wyswietlane pytanie. W klasie <see cref="LevelEasy"> za bledna odpowiedz odejmowana jest jedna sekunda.</summary>
        /// <param name="sender"> Typem danych parametru sender jest: object.</param>
        /// <param name="e"> Typem danych parametru e jest: System.EventArgs.</param>
        /// <returns>void.</returns>
        /// \see Deklaracja w klasie abstrakcyjne - <see cref="AbstractMainLevel.WrongAnswer_Click"/>
        protected override void WrongAnswer_Click(object? sender, EventArgs e) {
            MessageBox.Show("Źle! Spróbuj ponownie.");
            gamePanel.Controls.Clear();
            timeLeft -= 1;
            GenerateQuestion();
            GenerateAnwserButtons();
        }

        /// <summary>Metoda obslugujaca nacisniecie przycisku zamkniecia danego ekranu gry.</summary> 
        /// <summary>Metoda obslugujaca nacisniecie przycisku zamkniecia danego ekranu gry. W tej klasie zawarta jest implementacja metody.</summary>
        /// <param name="sender"> Typem danych parametru sender jest: object.</param>
        /// <param name="e"> Typem danych parametru e jest: System.EventArgs.</param>
        /// <returns>void.</returns>
        /// \see Deklaracja w klasie abstrakcyjne - <see cref="AbstractMainLevel.CloseButton_Click"/>
        protected override void CloseButton_Click(object? sender, EventArgs e) {
            gameTimer.Stop();
            if (stageComplete) {
                labyrinthTimer.Stop();
            }
            this.Close();
        }

        /// <summary>Metoda inicjalizujaca labirynt.</summary> 
        /// <summary>
        /// Metoda inicjalizujaca labirynt po uzyskaniu wymaganego wyniku w etapie pierwszym danego poziomu. 
        /// Inicjalizacja polega na wygenerowaniu labiryntu na bazie tablicy, ustawieniu czasu gry na okreslona wartosc oraz wyznaczeniu liczby fragmentow klucza potrzebnych do ukonczenia labiryntu.
        /// </summary>
        /// <returns>void.</returns>
        /// \see Deklaracja w klasie abstrakcyjne - <see cref="AbstractMainLevel.InitializeLabyrinth"/>
        protected override void InitializeLabyrinth() {
            keyFragments.Clear();
            collectedFragments = 0;
            timeLeft = 60;
            labyrinthTimer.Interval = 1000;
            labyrinthTimer.Tick += LabyrinthTimer_Tick;

            labyrinthMap = new int[,] {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 1, 0, 0, 2, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 0, 0, 1 },
                { 1, 0, 1, 0, 0, 0, 1, 0, 1, 1 },
                { 1, 0, 0, 0, 1, 0, 0, 0, 2, 1 },
                { 1, 1, 1, 0, 1, 1, 1, 0, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 1, 1, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 3, 1, 1 }
            };

            for (int y = 0; y < labyrinthMap.GetLength(0); y++) {
                for (int x = 0; x < labyrinthMap.GetLength(1); x++) {
                    if (labyrinthMap[y, x] == 2) {
                        keyFragments.Add(new Point(x, y));
                    }
                }
            }
            totalKeys = keyFragments.Count;
            playerPosition = new Point(1, 1);

            Label timerLabel = CreateTimerLabel();
            scoreTimePanel.Controls.Add(timerLabel);
            labScoreLabel = CreateLabyrinthScoreLabel();
            scoreTimePanel.Controls.Add(labScoreLabel);
            Button backButton = CreateCloseButton();
            scoreTimePanel.Controls.Add(backButton);
            backButton.Click += CloseButton_Click;
            DrawLabyrinth();
            labyrinthTimer.Start();
        }

        /// <summary>Metoda odswierzajaca pozostaly czas drugiego etapu gry.</summary> 
        /// <summary>Metoda odswierzajaca pozostaly czas gry drugiego etapu wyswietlany w <see cref="scoreTimePanel"/> co sekunde. W przypadku gdy czas osiaga zero wyswietlany jest komunikat o zakonczeniu gry.</summary>
        /// <param name="sender"> Typem danych parametru sender jest: object.</param>
        /// <param name="e"> Typem danych parametru e jest: System.EventArgs.</param>
        /// <returns>void.</returns>
        /// \see Deklaracja w klasie abstracyjnej - <see cref="AbstractMainLevel.LabyrinthTimer_Tick"/>
        protected override void LabyrinthTimer_Tick(object? sender, EventArgs e) {
            timeLeft--;
            if (scoreTimePanel.Controls["TimerLabel"] is Label timerLabel) {
                timerLabel.Text = $"Czas: {timeLeft} s";
            }

            if (timeLeft <= 0) {
                labyrinthTimer.Stop();
                MessageBox.Show("Nie zdążyles zebrać wszystkich fragmentów klucza przed upływem czasu. Koniec Gry");
                this.Close();
                GC.Collect();
            }
        }

        /// <summary>Metoda wysiwetlajaca labirynt.</summary> 
        /// <summary>
        /// Metoda wysiwetlajaca labirynt oraz odswierzajaca go po kazdym ruchu gracza. 
        /// Rysowanie labiryntu polega na rysowaniu kwadratow o stalym rozmiarze z wypelni9eniem zaleznym od wartosci wpisanej w tablicy na bazie ktorej generowany jest labirynt.
        /// </summary>
        /// <returns>void.</returns>
        /// \see Deklaracja w klasie abstrakcyjnej - <see cref="AbstractMainLevel.DrawLabyrinth"/>
        protected override void DrawLabyrinth() {
            gamePanel.Invalidate();
            scoreTimePanel.Controls.Remove(labScoreLabel);
            labScoreLabel = CreateLabyrinthScoreLabel();
            scoreTimePanel.Controls.Add(labScoreLabel);


            int tileSize = 60;

            int startX = (gamePanel.Width - (labyrinthMap.GetLength(1) * tileSize)) / 2;
            int startY = (gamePanel.Height - (labyrinthMap.GetLength(0) * tileSize)) / 2;

            gamePanel.Paint += (sender, e) => {
                Graphics g = e.Graphics;

                for (int y = 0; y < labyrinthMap.GetLength(0); y++) {
                    for (int x = 0; x < labyrinthMap.GetLength(1); x++) {
                        var color = labyrinthMap[y, x] switch {
                            1 => Color.Black,
                            0 => Color.White,
                            2 => Color.Gold,
                            3 => Color.Blue,
                            _ => Color.Transparent,
                        };
                        g.FillRectangle(new SolidBrush(color), startX + x * tileSize, startY + y * tileSize, tileSize, tileSize);
                        g.DrawRectangle(Pens.Gray, startX + x * tileSize, startY + y * tileSize, tileSize, tileSize);
                    }
                }

                g.FillRectangle(Brushes.Red, startX + playerPosition.X * tileSize, startY + playerPosition.Y * tileSize, tileSize, tileSize);
            };
        }

        /// <summary>Metoda obslugujaca nacisniecie przycisku ruchu.</summary> 
        /// <summary>
        /// Metoda obslugujaca nacisniecie przycisku ruchu. Nacisniecie odpowiedniego klawisza powoduje ruch gracza w odpowiednia strone po uprzednim sprawdzeniu czy ruch jest mozliwy do wykonania.
        /// W metodzie sprawdzany jest takze warunek ukonczenia labiryntu.
        /// </summary>
        /// <param name="keyCode">Typem danych parametru keyCode jest: System.Windows.Forms.Keys.</param>
        /// <returns>void.</returns>
        /// \see Deklaracja w klasie abstrakcyjnej - <see cref="AbstractMainLevel.MainWindow_KeyPressed"/>
        protected override void MainWindow_KeyPressed(Keys keyCode) {
            if (keyCode != Keys.W && keyCode != Keys.A && keyCode != Keys.S && keyCode != Keys.D) {
                return;
            }

            Point newPosition = playerPosition;

            switch (keyCode) {
                case Keys.W:
                    newPosition.Y -= 1;
                    break;
                case Keys.A:
                    newPosition.X -= 1;
                    break;
                case Keys.S:
                    newPosition.Y += 1;
                    break;
                case Keys.D:
                    newPosition.X += 1;
                    break;
            }

            if (winCondition == 1) {
                playerPosition = new Point(1, 1);
                newPosition = playerPosition;
            }

            if (IsValidMove(newPosition)) {
                if (labyrinthMap[newPosition.Y, newPosition.X] == 2) {
                    GenerateQuestion();
                    if (userAnswer == correctAnswer) {
                        keyFragments.Remove(newPosition);
                        collectedFragments++;
                        labyrinthMap[newPosition.Y, newPosition.X] = 0;
                    }
                    else {
                        MessageBox.Show("Mimo złej odpowiedzi strażnik fragmentu pozwolil ci przejść przez jego pole!");
                    }
                }
                if (labyrinthMap[newPosition.Y, newPosition.X] == 3) {
                    if (HasCollectedAllKeyFragments()) {
                        MessageBox.Show("Udało ci sie zebrac wszystkie fragmenty klucza. Możesz wyjść z labiryntu");
                        labyrinthTimer.Stop();
                        winCondition = 1;
                        WinConditionChanged?.Invoke(winCondition);
                        //newPosition.Y = 0;
                        //newPosition.X = 0;
                        this.Close();
                    }
                    else {
                        MessageBox.Show("Przed wyjściem z labiryntu musisz zebrać drużynę, to znaczy wszystkie fragmenty klucza!");
                        return;
                    }
                }
                playerPosition = newPosition;
                DrawLabyrinth();
            }
        }

        /// <summary>Metoda sprawdzajaca czy gracz moze wyjsc z labiryntu.</summary> 
        /// <summary>Metoda sprawdzajaca czy gracz zebral wszystkie fragmenty klucza potrzebnego do wyjscia z labiryntu. W klasie <see cref="LevelEasy"/> zaimplementowano metode.</summary>
        /// <returns>bool.</returns>
        /// \see Deklaracja w klasie abstrakcyjnej - <see cref="AbstractMainLevel.HasCollectedAllKeyFragments"/>
        protected override bool HasCollectedAllKeyFragments() {
            return collectedFragments >= totalKeys;
        }


        /// <summary>Metoda sprawdzajaca czy gracz moze wykonac ruch.</summary> 
        /// <summary>Metoda sprawdzajaca czy gracz moze wykonac ruch. W klasie <see cref="LevelEasy"/> zaimplementowano metode.</summary>
        /// <param name="newPosition">Typem danych parametru newPosition jest: System.Drawing.Point.</param>
        /// <returns>bool.</returns>
        /// \see Deklaracja w klasie abstrakcyjnej - <see cref="AbstractMainLevel.IsValidMove"/>
        protected override bool IsValidMove(Point newPosition) {
            if (winCondition == 1) {
                newPosition = new Point(1, 1);
            }
            return labyrinthMap[newPosition.Y, newPosition.X] != 1;
        }
    }
}
