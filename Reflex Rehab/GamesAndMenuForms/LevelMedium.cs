﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reflex_Rehab.GameAndMenuForms {
    internal partial class LevelMedium : AbstractMainLevel {
        private readonly Random random = new();
        private int correctAnswer;
        private int score = 0;
        private int timeLeft = 30;
        private readonly System.Windows.Forms.Timer gameTimer = new();
        private int winCondition = 0;
        internal event Action<int>? WinConditionChanged;

        private readonly Panel mainPanel = new() {
            Location = new Point(0, 0),
            Size = new Size(1264, 985),
            BackgroundImage = Properties.Resources.rsz_hex_backgrounds_networking
        };

        private readonly Panel scoreTimePanel = new() {
            Location = new Point(0, 0),
            Size = new Size(1264, 160),
            BackColor = Color.Transparent
        };

        private readonly Panel gamePanel = new() {
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
                Location = new Point(32, 36),
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
                Location = new Point(32, 72),
                ForeColor = SystemColors.Control,
                BackColor = Color.Transparent,
                AutoSize = true
            };
        }

        protected override Label CreateQuestionLabel(string questionText) {
            return new Label {
                Text = questionText,
                Font = new Font("Arial", 36, FontStyle.Bold),
                Location = new Point(540, 44),
                ForeColor = SystemColors.Control,
                BackColor = Color.Transparent,
                AutoSize = true
            };
        }
        public LevelMedium() {
            InitializeComponent();
            InitializeGame();
            GenerateQuestion();
        }
        protected override void InitializeGame() {
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;
            this.Controls.Add(mainPanel);
            mainPanel.Controls.Add(scoreTimePanel);
            mainPanel.Controls.Add(gamePanel);

            Label timerLabel = new() {
                Name = "TimerLabel",
                Text = $"Czas: {timeLeft} s",
                Font = new Font("Arial", 12),
                Location = new Point(10, 10),
                AutoSize = true
            };
            scoreTimePanel.Controls.Add(timerLabel);
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
            }
        }

        protected override void GenerateQuestion() {
            gamePanel.Controls.Clear();
            scoreTimePanel.Controls.Clear();

            Label timerLabel = CreateTimerLabel();
            scoreTimePanel.Controls.Add(timerLabel);

            Label scoreLabel = CreateScoreLabel();
            scoreTimePanel.Controls.Add(scoreLabel);

            Button closeButton = CreateCloseButton();
            closeButton.Click += CloseButton_Click;
            scoreTimePanel.Controls.Add(closeButton);

            int difficultyMultiplier = score / 10 + 1; 
            int a = random.Next(1, 10 * difficultyMultiplier);
            int b = random.Next(1, 10 * difficultyMultiplier);
            string operation;
            string questionText;

            switch (random.Next(0, 5)) { 
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
                case 3:
                    operation = "/";
                    b = b == 0 ? 1 : b;
                    a = a - (a % b);
                    correctAnswer = a / b;
                    questionText = $"{a} {operation} {b} = ?";
                    break;
                default:
                    operation = "%";
                    correctAnswer = a % b;
                    questionText = $"{a} {operation} {b} = ?";
                    break;
            }

            Label questionLabel = CreateQuestionLabel(questionText);
            scoreTimePanel.Controls.Add(questionLabel);

            int totalAnswers = Math.Min(3 + score / 5, 7);

            int correctButtonIndex = random.Next(totalAnswers);
            List<Rectangle> placedButtons = [];

            for (int i = 0; i < totalAnswers; i++) {
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
                        wrongAnswer = correctAnswer + random.Next(-10 * difficultyMultiplier, 10 * difficultyMultiplier);
                    } while (wrongAnswer == correctAnswer || wrongAnswer < 0);

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
            score += 2;
            if (score == 30) {
                gameTimer.Stop();
                MessageBox.Show($"Gratulacje! Wygrałeś! Twój wynik to {score} punktów!");
                winCondition = 2;
                WinConditionChanged?.Invoke(winCondition);
                this.Close();
            }
            else {
                timeLeft += 1;
                GenerateQuestion();
            }
        }

        protected override void WrongAnswer_Click(object? sender, EventArgs e) {
            MessageBox.Show("Źle! Straciłeś 3 sekund.");
            timeLeft -= 3;
            if (timeLeft <= 0) {
                gameTimer.Stop();
                MessageBox.Show($"Koniec czasu! Twój wynik: {score}. Spróbuj ponownie!");
                this.Close();
            }
            else {
                GenerateQuestion();
            }
        }

        private void CloseButton_Click(object? sender, EventArgs e) {
            gameTimer.Stop();
            this.Close();
        }
    }
}
