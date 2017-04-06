using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {

        private readonly Dictionary<int, string> _categories = new Dictionary<int, string>() { { 0, "Pop" }, { 1, "Science" }, { 2, "Sports" }, { 3, "Rock" } };
        private readonly Players _players;

        LinkedList<string> popQuestions = new LinkedList<string>();
        LinkedList<string> scienceQuestions = new LinkedList<string>();
        LinkedList<string> sportsQuestions = new LinkedList<string>();
        LinkedList<string> rockQuestions = new LinkedList<string>();
        bool isGettingOutOfPenaltyBox;


        public Game(Players players)
        {
            _players = players;
            for (int i = 0; i < 50; i++)
            {
                popQuestions.AddLast("Pop Question " + i);
                scienceQuestions.AddLast(("Science Question " + i));
                sportsQuestions.AddLast(("Sports Question " + i));
                rockQuestions.AddLast(CreateRockQuestion(i));
            }
        }

        public void Roll(int roll)
        {
            Console.WriteLine(_players.Current.Nom + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (_players.Current.InPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(_players.Current.Nom + " is getting out of the penalty box");
                    _players.Current.Move(roll);

                    Console.WriteLine(_players.Current.Nom
                            + "'s new location is "
                            + _players.Current.Place);
                    Console.WriteLine("The category is " + CurrentCategory());
                    AskQuestion();
                }
                else
                {
                    Console.WriteLine(_players.Current.Nom + " is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {
                _players.Current.Move(roll);

                Console.WriteLine(_players.Current.Nom
                        + "'s new location is "
                        + _players.Current.Place);
                Console.WriteLine("The category is " + CurrentCategory());
                AskQuestion();
            }

        }

        private void AskQuestion()
        {
            if (CurrentCategory() == "Pop")
            {
                Console.WriteLine(popQuestions.First());
                popQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Science")
            {
                Console.WriteLine(scienceQuestions.First());
                scienceQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Sports")
            {
                Console.WriteLine(sportsQuestions.First());
                sportsQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Rock")
            {
                Console.WriteLine(rockQuestions.First());
                rockQuestions.RemoveFirst();
            }
        }

        private String CurrentCategory()
        {

            return _categories[_players.Current.Place % 4];
        }

        public bool WasCorrectlyAnswered()
        {
            bool winner;
            if (_players.Current.InPenaltyBox)
            {
                if (isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    _players.Current.WinAGoldCoin();

                    winner = _players.Current.IsWinner();
                    _players.NextPlayer();

                    return winner;
                }
                _players.NextPlayer();
                return false;
            }
            Console.WriteLine("Answer was corrent!!!!");
            _players.Current.WinAGoldCoin();

            winner = _players.Current.IsWinner();
            _players.NextPlayer();

            return winner;
        }



        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(_players.Current.Nom + " was sent to the penalty box");
            _players.Current.GoToPenaltyBox();

            _players.NextPlayer();
            return false;
        }

        public String CreateRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

    }

}