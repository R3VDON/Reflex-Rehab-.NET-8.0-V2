﻿using Reflex_Rehab.GamesAndMenuForms;
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
    /// <summary>Łatwy poziom gry.</summary>
    /// <summary>Formularz Windows Forms stanowiący poziom łatwy gry Reflex Rehab. Formularz ten dziedziczy po klasie <see cref="AbstractMainLevel"/></summary>
    /// \author Konrad Fornal 193083, EiT, Telekomunikacja 1A
    internal partial class LevelEasy : AbstractMainLevel {
        /// <summary>Zdarzenie obsługujące zmianę parametru winCondition w celu odblokowania kolejnego poziomu trudności. </summary>
        internal event Action<int>? WinConditionChanged;
        /// <summary>Obiekt klasy Timer służący jako zegar dla pierwszego etapu gry.</summary>
        private readonly System.Windows.Forms.Timer gameTimer = new();
        /// <summary>Obiekt klasy Timer służący jako zegar dla drugiego etapu gry.</summary>
        private readonly System.Windows.Forms.Timer labyrinthTimer = new();
        /// <summary>Obiekt klasy Random stosowany do tworzenia pseudolosowych pytań matematycznych oraz błędnych odpowiedzi do tych pytań.</summary>
        private readonly Random random = new();
        /// <summary>Lista pozycji fragmentów klucza w labiryncie</summary>
        private readonly List<Point> keyFragments = [];
        /// <summary>Tablica służąca do przechowywania układu labiryntu dla danego poziomu gry.</summary>
        private int[,] labyrinthMap = null!;
        /// <summary>Zmienna przechowująca liczbę będącą poprawną odpowiedzią na pytanie.</summary>
        private int correctAnswer;
        /// <summary>Zmienna przechowująca odpowiedź gracza na pytanie. Wykorzystywana przy pytaniach w labiryncie.</summary>
        private int userAnswer;
        /// <summary>Zmienna przechowująca wynik uzyskany w pierwszym etapie gry.</summary>
        private int score = 0;
        /// <summary>Zmienna przechowująca pozostały czas gry.</summary>
        private int timeLeft;
        /// <summary>Obiekt przechowujący pozycję gracza w labiryncie.</summary>
        private Point playerPosition;
        /// <summary>Zmienna przechowująca ilość zebranych przez gracza fragmentów klucza.</summary>
        private int collectedFragments;
        /// <summary>Zmienna przechowująca liczbę fragmentów klucza występujących w labiryncie.</summary>
        private int totalKeys;
        /// <summary>Zmienna przechowująca informację o tym który poziom gry został wygrany.</summary>
        private int winCondition = 0;
        /// <summary>Zmienna przechowująca informacje czy gracz przeszedł pierwszy etap poziomu.</summary>
        private bool stageComplete = false;
        /// <summary>Obiekt wyświetlający wynik uzyskany przez gracza w trakcie rozgrywki.</summary>
        private Label scoreLabel = null!;
        /// <summary>Obiekt wyświetlający pytanie, na które ma odpowiedzieć gracz.</summary>
        private Label questionLabel = null!;
        /// <summary>Obiekt wyświetlający postępy w zbieraniu fragmentów klucza w trakcie etapu drugiego danego poziomu.</summary>
        private Label labScoreLabel = null!;
        /// <summary>Kontenerem na wszystkie pozostałe obiekty w formularzu.</summary>
        private readonly DoubleBufferedPanel mainPanel = new() {
            Location = new Point(0, 0),
            Size = new Size(1264, 985),
            BackgroundImage = Properties.Resources.rsz_hex_backgrounds_networking
        };
        /// <summary>Kontener, w którym zawarte są elementy stanowiące ekran podsumowania postępów w grze. Zawarty jest w nim także przycisk wyjścia z poziomu do menu głównego.</summary>
        private readonly DoubleBufferedPanel scoreTimePanel = new() {
            Location = new Point(0, 0),
            Size = new Size(1264, 160),
            BackColor = Color.Transparent
        };
        /// <summary>Kontener, w którym znajdują się wsłaściwe elementy gry, to jest odpowiedzi do pytań oraz labirynt.</summary>
        private readonly DoubleBufferedPanel gamePanel = new() {
            Location = new Point(0, 160),
            Size = new Size(1264, 825),
            BackColor = Color.Transparent
        };

        /// <summary>Metoda tworząca przycisk zamykający ekran gry.</summary> 
        /// <summary>Metoda tworząca przycisk zamykający obecnie wyświetlany ekran gry. W tej klasie zawarta jest implementacja metody.</summary>
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

        /// <summary>Metoda tworząca obiekt wyświetlający pozostały czas gry.</summary>
        /// <summary>Metoda tworząca obiekt typu label służący do wyświetlania pozostałego czasu gry. W tej klasie zawarta jest implementacja metody.</summary>
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

        /// <summary>Metoda tworząca obiekt wyświetlający wynik pierwszego etapu danego poziomu gry.</summary> 
        /// <summary>Metoda tworząca obiekt typu label służący do wyświetlania wyniku podczas pierwszego etapu gry na danym poziomie trudności. W tej klasie zawarta jest implementacja metody.</summary>
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

        /// <summary>Metoda tworząca obiekt wyświetlający postępy w drugim etapie danego poziomu gry.</summary>  
        /// <summary>Metoda tworząca obiekt typu Label służący do wyświetlania podsumowania postępów gracza podczas drugiego etapu gry na danym poziomie trudności. W tej klasie zawarta jest implementacja metody.</summary>
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


        /// <summary>Metoda tworząca obiekt wyświetlający pytanie matematyczne.</summary> 
        /// <summary>
        /// Metoda tworząca obiekt typu Label służący do wyświetlania pytania matematycznego, na które gracz musi znaleść odpowiedź.
        /// Metoda ta przyjmuje parametr questionText typu string przechowujący pytanie, które jest wyświetlane na ekranie. W tej klasie zawarta jest implementacja metody.
        /// </summary>
        /// <param name="questionText"> Przechowuje pytanie generowane przez metodę <see cref="LevelEasy.GenerateQuestion"/>. Typem danych parametru questionTest jest: string.</param>
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
        /// <summary>Konstruktor klasy LevelEasy. Pryjmuje on parametr w postaci obiektu klasy głównej MainWindows do obsługi klawiatury. Wywoływane są w nim metody inicjalizujące poziom gry.</summary>
        /// <param name="mainWindow">Jest to obiekt klasy <see cref="MainWindow"/>. Typem danych parametru mainWindow jest: Reflex_Rehab.MainWindow.</param>
        /// <returns>void.</returns>
        public LevelEasy(MainWindow mainWindow) {
            InitializeComponent();
            mainWindow.KeyPressed += MainWindow_KeyPressed;
            InitializeGame();
            GenerateQuestion();
            GenerateAnwserButtons();
        }


        /// <summary>Metoda odpowiadająca za inicjalizację ekranu gry.</summary> 
        /// <summary>Metoda odpowiadająca za inicjalizację ekranu gry. W metodzie ustawiane są parametry zegara oraz tworzone są obiekty zawarte w panelu <see cref="scoreTimePanel"/>.</summary>
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


        /// <summary>Metoda odświerzająca pozostały czas pierwszego etapu gry.</summary> 
        /// <summary>Metoda odświerzająca pozostały czas gry wyświetlany w <see cref="scoreTimePanel"/> co sekundę. W przypadku gdy czas osiąga zero wyświetlany jest komunikat o zakończeniu gry.</summary>
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


        /// <summary>Metoda generująca pytania matematyczne.</summary> 
        /// <summary>
        /// Metoda generująca pytania matematyczne o określonym poziomie trudności z określonego zakresu operacji arytmetycznych. 
        /// W tej klasie zawarta jest implementacja metody z czterema podstawowymi operacjami matematycznymi: dodawaniem, odejmowaniem, mnożeniem i dzieleniem. 
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


        /// <summary>Metoda tworząca przyciski z odpowiedziami.</summary> 
        /// <summary>Metoda tworząca przyciski z odpowiedziami na wyświetlne pytania. Tworzona jest jedna odpowiedź poprawna i trzy błędne. Położenie jest ustalane w sposób pseudolosowy.</summary>
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

        /// <summary>Metoda obsługująca naciśnięcie prawidłowej odpowiedzi.</summary> 
        /// <summary>
        /// Metoda obsługująca naciśnięcie prawidłowej odpowiedzi na wyświetlane pytanie oraz uzyskanie wymaganego wyniku. 
        /// Dla klasy <see cref="LevelEasy"/> próg wygranej ustawiony jest na 10 punktów, za każdą poprawną odpowiedź przyznawany punkt, a ilość czasu doliczonego za poprawną odpowiedź wynosi 1 sekundę.
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

        /// <summary>Metoda obsługująca naciśnięcie złej odpowiedzi.</summary> 
        /// <summary>Metoda obsługująca naciśnięcie złej odpowiedzi na wyświetlane pytanie. W klasie <see cref="LevelEasy"> za błędną odpowiedź odejmowana jest jedna sekunda.</summary>
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

        /// <summary>Metoda obsługująca naciśnięcie przycisku zamknięcia danego ekranu gry.</summary> 
        /// <summary>Metoda obsługująca naciśnięcie przycisku zamknięcia danego ekranu gry. W tej klasie zawarta jest implementacja metody.</summary>
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

        /// <summary>Metoda inicjalizująca labirynt.</summary> 
        /// <summary>
        /// Metoda inicjalizująca labirynt po uzyskaniu wymaganego wyniku w etapie pierwszym danego poziomu. 
        /// Inicjalizacja polega na wygenerowaniu labiryntu na bazie tablicy, ustawieniu czasu gry na określoną wartość oraz wyznaczeniu liczby fragmentów klucza potrzebnych do ukończenia labiryntu.
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

        /// <summary>Metoda odświerzająca pozostały czas drugiego etapu gry.</summary> 
        /// <summary>Metoda odświerzająca pozostały czas gry drugiego etapu wyświetlany w <see cref="scoreTimePanel"/> co sekundę. W przypadku gdy czas osiąga zero wyświetlany jest komunikat o zakończeniu gry.</summary>
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
                MessageBox.Show("Nie zdążyłeś zebrać wszystkich fragmentów klucza przed upływem czasu. Koniec Gry");
                this.Close();
                GC.Collect();
            }
        }

        /// <summary>Metoda wyśiwetlająca labirynt.</summary> 
        /// <summary>
        /// Metoda wyśiwetlająca labirynt oraz odświerzająca go po każdym ruchu gracza. 
        /// Rysowanie labiryntu polega na rysowaniu kwadratów o stałym rozmiarze z wypełni9eniem zależnym od wartości wpisanej w tablicy na bazie której generowany jest labirynt.
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

        /// <summary>Metoda obsługująca naciśnięcie przycisku ruchu.</summary> 
        /// <summary>
        /// Metoda obsługująca naciśnięcie przycisku ruchu. Naciśnięcie odpowiedniego klawisza powoduje ruch gracza w odpowiednią stronę po uprzednim sprawdzeniu czy ruch jest możliwy do wykonania.
        /// W metodzie sprawdzany jest także warunek ukończenia labiryntu.
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

            if (IsValidMove(newPosition)) {
                if (labyrinthMap[newPosition.Y, newPosition.X] == 2) {
                    GenerateQuestion();
                    if (userAnswer == correctAnswer) {
                        keyFragments.Remove(newPosition);
                        collectedFragments++;
                        labyrinthMap[newPosition.Y, newPosition.X] = 0;
                    }
                    else {
                        MessageBox.Show("Mimo złej odpowiedzi strażnik fragmentu pozwolił ci przejść przez jego pole!");
                    }
                }
                if (labyrinthMap[newPosition.Y, newPosition.X] == 3) {
                    if (HasCollectedAllKeyFragments()) {
                        MessageBox.Show("Udało ci się zebrać wszystkie fragmentu klucza. Możesz wyjść z labiryntu");
                        labyrinthTimer.Stop();
                        winCondition = 1;
                        WinConditionChanged?.Invoke(winCondition);
                        GC.Collect();
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

        /// <summary>Metoda sprawdzająca czy gracz może wyjść z labiryntu.</summary> 
        /// <summary>Metoda sprawdzająca czy gracz zebrał wszystkie fragmenty klucza potrzebnego do wyjścia z labiryntu. W klasie <see cref="LevelEasy"/> zaimplementowano metodę.</summary>
        /// <returns>bool.</returns>
        /// \see Deklaracja w klasie abstrakcyjnej - <see cref="AbstractMainLevel.HasCollectedAllKeyFragments"/>
        protected override bool HasCollectedAllKeyFragments() {
            return collectedFragments >= totalKeys;
        }


        /// <summary>Metoda sprawdzająca czy gracz może wykonać ruch.</summary> 
        /// <summary>Metoda sprawdzająca czy gracz może wykonać ruch. W klasie <see cref="LevelEasy"/> zaimplementowano metodę.</summary>
        /// <param name="newPosition">Typem danych parametru newPosition jest: System.Drawing.Point.</param>
        /// <returns>bool.</returns>
        /// \see Deklaracja w klasie abstrakcyjnej - <see cref="AbstractMainLevel.IsValidMove"/>
        protected override bool IsValidMove(Point newPosition) {
            return labyrinthMap[newPosition.Y, newPosition.X] != 1;
        }
    }
}
