using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
///       Namespace Name - Reflex_Rehab.GamesAndMenuForms.
/// </summary>
namespace Reflex_Rehab.GamesAndMenuForms {
    /// <summary>Klasa bedaca rozszerzeniem klasy Panel o obsluge podwojnego buforowania.</summary>
    /// <summary>Klasa bedaca rozszerzeniem klasy Panel o obsluge podwojnego buforowania. Pozwala to na wyeliminowanie nieporzadanego efektu migania ekranu podczas gry.</summary>
    /// \author Konrad Fornal 193083, EiT, Telekomunikacja 1A
    internal class DoubleBufferedPanel : Panel {
        /// <summary>Konstruktor klasy DoubleBufferedPanel.</summary>
        /// <summary>Konstruktor klasy DoubleBufferedPanel. Ustawiane sa w nim parametry pozwalajace na wykorzystanie podwojnego buforowania elementow graficznych.</summary>
        public DoubleBufferedPanel() {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint, true);
        }
    }
}
