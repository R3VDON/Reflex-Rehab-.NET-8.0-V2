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
    /// <summary>Klasa abstrakcyjna stanowiaca wzorzec dla formularzy poszczegolnych poziomow.</summary>
    /// <summary>Klasa abstrakcyjna stanowiaca wzorzec dla formularzy poszczegolnych poziomow. W klasie zawarte sa deklaracje wszystkich metod, ktore sa wspolne dla klas poziomow.</summary>
    /// \author Konrad Fornal 193083, EiT, Telekomunikacja 1A
    internal abstract partial class AbstractMainLevel : Form {


        /// <summary>Metoda tworzaca przycisk zamykajacy ekran gry.</summary> 
        /// <summary>Metoda tworzaca przycisk zamykajacy obecnie wyswietlany ekran gry. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <returns>System.Windows.Forms.Button.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.CreateCloseButton()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.CreateCloseButton()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.CreateCloseButton()"/>.</li>
        /// </ul>
        protected abstract Button CreateCloseButton();


        /// <summary>Metoda tworzaca obiekt wyswietlajacy pozostaly czas gry.</summary>
        /// <summary>Metoda tworzaca obiekt typu label sluzacy do wyswietlania pozostalego czasu gry. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <returns>System.Windows.Forms.Label.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.CreateTimerLabel()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.CreateTimerLabel()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.CreateTimerLabel()"/>.</li>
        /// </ul>
        protected abstract Label CreateTimerLabel();


        /// <summary>Metoda tworzaca obiekt wyswietlajacy wynik pierwszego etapu danego poziomu gry.</summary> 
        /// <summary>Metoda tworzaca obiekt typu label sluzacy do wyswietlania wyniku podczas pierwszego etapu gry na danym poziomie trudnosci. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <returns>System.Windows.Forms.Label.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.CreateScoreLabel()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.CreateScoreLabel()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.CreateScoreLabel()"/>.</li>
        /// </ul>
        protected abstract Label CreateScoreLabel();

        /// <summary>Metoda tworzaca obiekt wyswietlajacy postepy w drugim etapie danego poziomu gry.</summary>  
        /// <summary>Metoda tworzaca obiekt typu Label sluzacy do wyswietlania podsumowania postepow gracza podczas drugiego etapu gry na danym poziomie trudnosci. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <returns>System.Windows.Forms.Label.</returns> 
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.CreateLabyrinthScoreLabel()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.CreateLabyrinthScoreLabel()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.CreateLabyrinthScoreLabel()"/>.</li>
        /// </ul>
        protected abstract Label CreateLabyrinthScoreLabel();

        /// <summary>Metoda tworzaca obiekt wyswietlajacy pytanie matematyczne.</summary> 
        /// <summary>
        /// Metoda tworzaca obiekt typu Label sluzacy do wyswietlania pytania matematycznego, na ktore gracz musi znalesc odpowiedz.
        /// Metoda ta przyjmuje parametr questionText typu string przechowujacy pytanie, ktore jest wyswietlane na ekranie. W tej klasie jest zawarty tylko wzorzec metody.
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

        /// <summary>Metoda odpowiadajaca za inicjalizacje ekranu gry.</summary> 
        /// <summary>Metoda odpowiadajaca za inicjalizacje ekranu gry. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <returns>void.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.InitializeGame()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.InitializeGame()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.InitializeGame()"/>.</li>
        /// </ul>
        protected abstract void InitializeGame();

        /// <summary>Metoda odswierzajaca pozostaly czas pierwszego etapu gry.</summary> 
        /// <summary>Metoda odswierzajaca pozostaly czas pierwszego etapu gry. W przypadku gdy czas osiaga zero wyswietlany jest komunikat o zakonczeniu gry. W tej klasie jest zawarty tylko wzorzec metody.</summary>
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

        /// <summary>Metoda generujaca pytania matematyczne.</summary> 
        /// <summary>Metoda generujaca pytania matematyczne o okreslonym poziomie trudnosci z okreslonego zakresu operacji arytmetycznych. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <returns>void.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.GenerateQuestion()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.GenerateQuestion()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.GenerateQuestion()"/>.</li>
        /// </ul>
        protected abstract void GenerateQuestion();

        /// <summary>Metoda tworzaca przyciski z odpowiedziami.</summary> 
        /// <summary>Metoda tworzaca przyciski z odpowiedziami na wysiwetlne pytania. Tworzona jest jedna odpowiedz poprawna i kilka blednych. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <returns>void.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.GenerateAnwserButtons()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.GenerateAnwserButtons()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.GenerateAnwserButtons()"/>.</li>
        /// </ul>
        protected abstract void GenerateAnwserButtons();

        /// <summary>Metoda obslugujaca nacisniecie prawidlowej odpowiedzi.</summary> 
        /// <summary>Metoda obslugujaca nacisniecie prawidlowej odpowiedzi na wyswietlane pytanie. W tej klasie jest zawarty tylko wzorzec metody.</summary>
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

        /// <summary>Metoda obslugujaca nacisniecie zlej odpowiedzi.</summary> 
        /// <summary>Metoda obslugujaca nacisniecie zlej odpowiedzi na wyswietlane pytanie. W tej klasie jest zawarty tylko wzorzec metody.</summary>
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

        /// <summary>Metoda obslugujaca nacisniecie przycisku zamkniecia danego ekranu gry.</summary> 
        /// <summary>Metoda obslugujaca nacisniecie przycisku zamkniecia danego ekranu gry. W tej klasie jest zawarty tylko wzorzec metody.</summary>
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

        /// <summary>Metoda inicjalizujaca labirynt.</summary> 
        /// <summary>Metoda inicjalizujaca labirynt po uzyskaniu wymaganego wyniku w etapie pierwszym danego poziomu. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <returns>void.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.InitializeLabyrinth()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.InitializeLabyrinth()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.InitializeLabyrinth()"/>.</li>
        /// </ul>
        protected abstract void InitializeLabyrinth();

        /// <summary>Metoda odswierzajaca zegar drugiego etapu gry.</summary> 
        /// <summary>Metoda odswierzajaca zegar drugiego etapu gry. W przypadku gdy czas osiaga zero wyswietlany jest komunikat o zakonczeniu gry. W tej klasie jest zawarty tylko wzorzec metody.</summary>
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

        /// <summary>Metoda wysiwetlajaca labirynt.</summary> 
        /// <summary>Metoda wysiwetlajaca labirynt oraz odswierzajaca go po kazdym ruchu gracza. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <returns>void.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.DrawLabyrinth()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.DrawLabyrinth()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.DrawLabyrinth()"/>.</li>
        /// </ul>
        protected abstract void DrawLabyrinth();

        /// <summary>Metoda obslugujaca nacisniecie przycisku ruchu.</summary> 
        /// <summary>Metoda obslugujaca nacisniecie przycisku ruchu. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <param name="keyCode">Typem danych parametru keyCode jest: System.Windows.Forms.Keys.</param>
        /// <returns>void.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.MainWindow_KeyPressed()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.MainWindow_KeyPressed()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.MainWindow_KeyPressed()"/>.</li>
        /// </ul>
        protected abstract void MainWindow_KeyPressed(Keys keyCode);

        /// <summary>Metoda sprawdzajaca czy gracz moze wyjsc z labiryntu.</summary> 
        /// <summary>Metoda sprawdzajaca czy gracz zebral wszystkie fragmenty klucza potrzebnego do wyjscia z labiryntu. W tej klasie jest zawarty tylko wzorzec metody.</summary>
        /// <returns>bool.</returns>
        /// \see
        /// <ul>
        /// <li>Implementacja metody w klasie LavelEasy <see cref="LevelEasy.HasCollectedAllKeyFragments()"/>.</li>
        /// <li>Implementacja metody w klasie LavelMedium <see cref="LevelMedium.HasCollectedAllKeyFragments()"/>.</li>
        /// <li>Implementacja metody w klasie LavelHard <see cref="LevelHard.HasCollectedAllKeyFragments()"/>.</li>
        /// </ul>
        protected abstract bool HasCollectedAllKeyFragments();

        /// <summary>Metoda sprawdzajaca czy gracz moze wykonac ruch.</summary> 
        /// <summary>Metoda sprawdzajaca czy gracz moze wykonac ruch. W tej klasie jest zawarty tylko wzorzec metody.</summary>
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
