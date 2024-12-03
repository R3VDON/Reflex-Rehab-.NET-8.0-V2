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
///       Namespace Name - Reflex_Rehab.GameAndMenuForms.
/// </summary>
namespace Reflex_Rehab.GameAndMenuForms {
    internal partial class LevelEasy : AbstractMainLevel {
        internal event Action<int>? WinConditionChanged;
        private readonly System.Windows.Forms.Timer gameTimer = new();
        private readonly System.Windows.Forms.Timer labyrinthTimer = new();
        private readonly Random random = new();
        private readonly List<Point> keyFragments = [];
        private int[,] labyrinthMap = null!;
        private int correctAnswer;
        private int userAnswer;
        private int score = 0;
        private int timeLeft;
        private Point playerPosition;
        private int collectedFragments;
        private int totalKeys;
        private int winCondition = 0;
        private bool stageComplete = false;
        private Label scoreLabel = null!;
        private Label questionLabel = null!;
        private Label labScoreLabel = null!;

        private readonly DoubleBufferedPanel mainPanel = new() {
            Location = new Point(0, 0),
            Size = new Size(1264, 985),
            BackgroundImage = Properties.Resources.rsz_hex_backgrounds_networking
        };

        private readonly DoubleBufferedPanel scoreTimePanel = new() {
            Location = new Point(0, 0),
            Size = new Size(1264, 160),
            BackColor = Color.Transparent
        };

        private readonly DoubleBufferedPanel gamePanel = new() {
            Location = new Point(0, 160),
            Size = new Size(1264, 825),
            BackColor = Color.Transparent
        };

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

        public LevelEasy(MainWindow mainWindow) {
            InitializeComponent();
            mainWindow.KeyPressed += MainWindow_KeyPressed;
            InitializeGame();
            GenerateQuestion();
            GenerateAnwserButtons();
        }

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

        protected override void WrongAnswer_Click(object? sender, EventArgs e) {
            MessageBox.Show("Źle! Spróbuj ponownie.");
            gamePanel.Controls.Clear();
            timeLeft -= 1;
            GenerateQuestion();
            GenerateAnwserButtons();
        }

        protected override void CloseButton_Click(object? sender, EventArgs e) {
            gameTimer.Stop();
            if (stageComplete) {
                labyrinthTimer.Stop();
            }
            this.Close();
        }

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

        protected override bool HasCollectedAllKeyFragments() {
            return collectedFragments >= totalKeys;
        }

        protected override bool IsValidMove(Point newPosition) {
            return labyrinthMap[newPosition.Y, newPosition.X] != 1;
        }
    }
}
