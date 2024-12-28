using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
///       Namespace Name - Reflex_Rehab.GamesAndMenuForms.
/// </summary>
namespace Reflex_Rehab.GamesAndMenuForms {
    /// <summary>Klasa będąca rozszerzeniem klasy Panel o obsługę podwójnego buforowania.</summary>
    /// <summary>Klasa będąca rozszerzeniem klasy Panel o obsługę podwójnego buforowania. Pozwala to na wyeliminowanie nieporządanego efektu migania ekranu podczas gry.</summary>
    /// \author Konrad Fornal 193083, EiT, Telekomunikacja 1A
    internal class DoubleBufferedPanel : Panel {
        /// <summary>Konstruktor klasy DoubleBufferedPanel.</summary>
        /// <summary>Konstruktor klasy DoubleBufferedPanel. Ustawiane są w nim parametry pozwalające na wykorzystanie podwójnego buforowania elementów graficznych.</summary>
        public DoubleBufferedPanel() {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint, true);
        }
    }
}
