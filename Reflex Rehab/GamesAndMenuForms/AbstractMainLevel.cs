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
        protected abstract void InitializeGame();
        protected abstract void GameTimer_Tick(object sender, EventArgs e);
        protected abstract void GenerateQuestion();
        protected abstract void CorrectAnswer_Click(object sender, EventArgs e);
        protected abstract void WrongAnswer_Click(object sender, EventArgs e);
    }
}
