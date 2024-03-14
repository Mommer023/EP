using System;

namespace PigGame.Models
{
    public class Game
    {
        public Game()
        {
            NewGame();
        }

        public const int WinnerScore = 20;

        public Player Player1{get; set;}
        public Player Player2{get; set;}

        public string CurrentPlayer {get; set;}
        public int TurnScore { get; set; }
        public int GameRoll { get; set; }
        public bool GameOver { get; set; }
        public void NewGame()
        {
            Player1 = new Player { Name = "Player 1"};
            Player2 = new Player { Name = "Player 2" };
            CurrentPlayer = Player1.Name;

            TurnScore = 0;
            GameRoll = 0;   
            GameOver = false;

        }
        public void Roll()
        {
            Random random = new Random();
            GameRoll = random.Next(1,7);

            TurnScore = 0;
            GameOver = false;
            if (GameRoll == 1)
            {
                TurnScore = 0;
                ChangePlayers();
            }
            else
            {
                TurnScore += GameRoll;
            
            }

        }

        public void Hold()
        {
            Player current = (CurrentPlayer == Player1.Name) ? Player1 : Player2;
            current.Score += WinnerScore;
            if (current.Score >= WinnerScore)
            {
                GameOver = true;

            } else 
            {
                current.Score = 0;
                TurnScore = 0;
                ChangePlayers();
                
            }
        }

        public void ChangePlayers()
        {
            Player current = (CurrentPlayer == Player1.Name) ? Player1 : Player2;
        } 
    }
}
