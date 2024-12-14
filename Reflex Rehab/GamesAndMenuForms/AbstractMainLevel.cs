using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reflex_Rehab.GameAndMenuForms {
    internal abstract partial class AbstractMainLevel : Form {
        protected abstract Button CreateCloseButton();
        protected abstract Label CreateTimerLabel();
        protected abstract Label CreateScoreLabel();
        protected abstract Label CreateLabyrinthScoreLabel();
        protected abstract Label CreateQuestionLabel(string questionText);
        protected abstract void InitializeGame();
        protected abstract void GameTimer_Tick(object sender, EventArgs e);
        protected abstract void GenerateQuestion();
        protected abstract void GenerateAnwserButtons();
        protected abstract void CorrectAnswer_Click(object sender, EventArgs e);
        protected abstract void WrongAnswer_Click(object sender, EventArgs e);
        protected abstract void CloseButton_Click(object? sender, EventArgs e);
        protected abstract void InitializeLabyrinth();
        protected abstract void LabyrinthTimer_Tick(object? sender, EventArgs e);
        protected abstract void DrawLabyrinth();
        protected abstract void MainWindow_KeyPressed(Keys keyCode);
        protected abstract bool HasCollectedAllKeyFragments();
        protected abstract bool IsValidMove(Point newPosition);
    }
}
