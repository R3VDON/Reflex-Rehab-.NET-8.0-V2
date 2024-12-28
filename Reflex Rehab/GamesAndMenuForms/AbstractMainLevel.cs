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
    /// <summary>Klasa abstrakcyjna stanowiąca wzorzec dla formularzy poszczególnych poziomów.</summary>
    /// <summary>Klasa abstrakcyjna stanowiąca wzorzec dla formularzy poszczególnych poziomów. W klasie zawarte są deklaracje wszystkich metod, które są wspólne dla klas poziomów.</summary>
    /// \author Konrad Fornal 193083, EiT, Telekomunikacja 1A
    internal abstract partial class AbstractMainLevel : Form {


        /// <summary>Metoda tworząca przycisk zamykający ekran gry.</summary> 
        /// <summary>Metoda tworząca przycisk zamykający obecnie wyświetlany ekran gry. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <returns>System.Windows.Forms.Button.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.CreateCloseButton()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.CreateCloseButton()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.CreateCloseButton()"/>.</li>
        /// </ul>
        protected abstract Button CreateCloseButton();


        /// <summary>Metoda tworząca obiekt wyświetlający pozostały czas gry.</summary>
        /// <summary>Metoda tworząca obiekt typu label służący do wyświetlania pozostałego czasu gry. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <returns>System.Windows.Forms.Label.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.CreateTimerLabel()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.CreateTimerLabel()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.CreateTimerLabel()"/>.</li>
        /// </ul>
        protected abstract Label CreateTimerLabel();


        /// <summary>Metoda tworząca obiekt wyświetlający wynik pierwszego etapu danego poziomu gry.</summary> 
        /// <summary>Metoda tworząca obiekt typu label służący do wyświetlania wyniku podczas pierwszego etapu gry na danym poziomie trudności. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <returns>System.Windows.Forms.Label.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.CreateScoreLabel()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.CreateScoreLabel()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.CreateScoreLabel()"/>.</li>
        /// </ul>
        protected abstract Label CreateScoreLabel();

        /// <summary>Metoda tworząca obiekt wyświetlający postępy w drugim etapie danego poziomu gry.</summary>  
        /// <summary>Metoda tworząca obiekt typu Label służący do wyświetlania podsumowania postępów gracza podczas drugiego etapu gry na danym poziomie trudności. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <returns>System.Windows.Forms.Label.</returns> 
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.CreateLabyrinthScoreLabel()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.CreateLabyrinthScoreLabel()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.CreateLabyrinthScoreLabel()"/>.</li>
        /// </ul>
        protected abstract Label CreateLabyrinthScoreLabel();

        /// <summary>Metoda tworząca obiekt wyświetlający pytanie matematyczne.</summary> 
        /// <summary>
        /// Metoda tworząca obiekt typu Label służący do wyświetlania pytania matematycznego, na które gracz musi znaleść odpowiedź.
        /// Metoda ta przyjmuje parametr questionText typu string przechowujący pytanie, które jest wyświetlane na ekranie. W tej klasie jest zawarty tylko wzorzec metody.
        /// </summary>
        /// <param name="questionText"> Typem danych parametru questionTest jest: string.</param>
        /// <returns>System.Windows.Forms.Label.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.CreateQuestionLabel()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.CreateQuestionLabel()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.CreateQuestionLabel()"/>.</li>
        /// </ul>
        protected abstract Label CreateQuestionLabel(string questionText);

        /// <summary>Metoda odpowiadająca za inicjalizację ekranu gry.</summary> 
        /// <summary>Metoda odpowiadająca za inicjalizację ekranu gry. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <returns>void.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.InitializeGame()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.InitializeGame()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.InitializeGame()"/>.</li>
        /// </ul>
        protected abstract void InitializeGame();

        /// <summary>Metoda odświerzająca pozostały czas pierwszego etapu gry.</summary> 
        /// <summary>Metoda odświerzająca pozostały czas pierwszego etapu gry. W przypadku gdy czas osiąga zero wyświetlany jest komunikat o zakończeniu gry. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <param name="sender"> Typem danych parametru sender jest: object.</param>
        /// <param name="e"> Typem danych parametru e jest: System.EventArgs.</param>
        /// <returns>void.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.GameTimer_Tick()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.GameTimer_Tick()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.GameTimer_Tick()"/>.</li>
        /// </ul>
        protected abstract void GameTimer_Tick(object sender, EventArgs e);

        /// <summary>Metoda generująca pytania matematyczne.</summary> 
        /// <summary>Metoda generująca pytania matematyczne o określonym poziomie trudności z określonego zakresu operacji arytmetycznych. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <returns>void.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.GenerateQuestion()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.GenerateQuestion()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.GenerateQuestion()"/>.</li>
        /// </ul>
        protected abstract void GenerateQuestion();

        /// <summary>Metoda tworząca przyciski z odpowiedziami.</summary> 
        /// <summary>Metoda tworząca przyciski z odpowiedziami na wyśiwetlne pytania. Tworzona jest jedna odpowiedź poprawna i kilka błędnych. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <returns>void.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.GenerateAnwserButtons()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.GenerateAnwserButtons()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.GenerateAnwserButtons()"/>.</li>
        /// </ul>
        protected abstract void GenerateAnwserButtons();

        /// <summary>Metoda obsługująca naciśnięcie prawidłowej odpowiedzi.</summary> 
        /// <summary>Metoda obsługująca naciśnięcie prawidłowej odpowiedzi na wyświetlane pytanie. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <param name="sender"> Typem danych parametru sender jest: object.</param>
        /// <param name="e"> Typem danych parametru e jest: System.EventArgs.</param>
        /// <returns>void.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.CorrectAnswer_Click()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.CorrectAnswer_Click()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.CorrectAnswer_Click()"/>.</li>
        /// </ul>
        protected abstract void CorrectAnswer_Click(object sender, EventArgs e);

        /// <summary>Metoda obsługująca naciśnięcie złej odpowiedzi.</summary> 
        /// <summary>Metoda obsługująca naciśnięcie złej odpowiedzi na wyświetlane pytanie. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <param name="sender"> Typem danych parametru sender jest: object.</param>
        /// <param name="e"> Typem danych parametru e jest: System.EventArgs.</param>
        /// <returns>void.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.WrongAnswer_Click()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.WrongAnswer_Click()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.WrongAnswer_Click()"/>.</li>
        /// </ul>
        protected abstract void WrongAnswer_Click(object sender, EventArgs e);

        /// <summary>Metoda obsługująca naciśnięcie przycisku zamknięcia danego ekranu gry.</summary> 
        /// <summary>Metoda obsługująca naciśnięcie przycisku zamknięcia danego ekranu gry. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <param name="sender"> Typem danych parametru sender jest: object.</param>
        /// <param name="e"> Typem danych parametru e jest: System.EventArgs.</param>
        /// <returns>void.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.CloseButton_Click()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.CloseButton_Click()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.CloseButton_Click()"/>.</li>
        /// </ul>
        protected abstract void CloseButton_Click(object? sender, EventArgs e);

        /// <summary>Metoda inicjalizująca labirynt.</summary> 
        /// <summary>Metoda inicjalizująca labirynt po uzyskaniu wymaganego wyniku w etapie pierwszym danego poziomu. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <returns>void.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.InitializeLabyrinth()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.InitializeLabyrinth()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.InitializeLabyrinth()"/>.</li>
        /// </ul>
        protected abstract void InitializeLabyrinth();

        /// <summary>Metoda odświerzająca zegar drugiego etapu gry.</summary> 
        /// <summary>Metoda odświerzająca zegar drugiego etapu gry. W przypadku gdy czas osiąga zero wyświetlany jest komunikat o zakończeniu gry. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <param name="sender"> Typem danych parametru sender jest: object.</param>
        /// <param name="e"> Typem danych parametru e jest: System.EventArgs.</param>
        /// <returns>void.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.LabyrinthTimer_Tick()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.LabyrinthTimer_Tick()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.LabyrinthTimer_Tick()"/>.</li>
        /// </ul>
        protected abstract void LabyrinthTimer_Tick(object? sender, EventArgs e);

        /// <summary>Metoda wyśiwetlająca labirynt.</summary> 
        /// <summary>Metoda wyśiwetlająca labirynt oraz odświerzająca go po każdym ruchu gracza. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <returns>void.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.DrawLabyrinth()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.DrawLabyrinth()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.DrawLabyrinth()"/>.</li>
        /// </ul>
        protected abstract void DrawLabyrinth();

        /// <summary>Metoda obsługująca naciśnięcie przycisku ruchu.</summary> 
        /// <summary>Metoda obsługująca naciśnięcie przycisku ruchu. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <param name="keyCode">Typem danych parametru keyCode jest: System.Windows.Forms.Keys.</param>
        /// <returns>void.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.MainWindow_KeyPressed()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.MainWindow_KeyPressed()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.MainWindow_KeyPressed()"/>.</li>
        /// </ul>
        protected abstract void MainWindow_KeyPressed(Keys keyCode);

        /// <summary>Metoda sprawdzająca czy gracz może wyjść z labiryntu.</summary> 
        /// <summary>Metoda sprawdzająca czy gracz zebrał wszystkie fragmenty klucza potrzebnego do wyjścia z labiryntu. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <returns>bool.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.HasCollectedAllKeyFragments()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.HasCollectedAllKeyFragments()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.HasCollectedAllKeyFragments()"/>.</li>
        /// </ul>
        protected abstract bool HasCollectedAllKeyFragments();

        /// <summary>Metoda sprawdzająca czy gracz może wykonać ruch.</summary> 
        /// <summary>Metoda sprawdzająca czy gracz może wykonać ruch. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <param name="newPosition">Typem danych parametru newPosition jest: System.Drawing.Point.</param>
        /// <returns>bool.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.IsValidMove()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.IsValidMove()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.IsValidMove()"/>.</li>
        /// </ul>
        protected abstract bool IsValidMove(Point newPosition);
    }
}
