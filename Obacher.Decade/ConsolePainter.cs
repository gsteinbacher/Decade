using System;
using Obacher.CardGame.Core;

namespace Obacher.Decade
{
    public class ConsolePainter : IPainter
    {
        public void Paint(Card card, bool frontSide)
        {
            string cardString;
            if (!frontSide)
            {
                cardString = "  ";
            }
            else
            {
                switch (card.Rank)
                {
                    case RankType.Two:
                        cardString = "2";
                        break;
                    case RankType.Three:
                        cardString = "3";
                        break;
                    case RankType.Four:
                        cardString = "4";
                        break;
                    case RankType.Five:
                        cardString = "5";
                        break;
                    case RankType.Six:
                        cardString = "6";
                        break;
                    case RankType.Seven:
                        cardString = "7";
                        break;
                    case RankType.Eight:
                        cardString = "8";
                        break;
                    case RankType.Nine:
                        cardString = "9";
                        break;
                    case RankType.Ten:
                        cardString = "T";
                        break;
                    case RankType.Jack:
                        cardString = "J";
                        break;
                    case RankType.Queen:
                        cardString = "Q";
                        break;
                    case RankType.King:
                        cardString = "K";
                        break;
                    case RankType.Ace:
                        cardString = "A";
                        break;
                    default:
                        cardString = "";
                        break;
                }

                switch (card.Suit)
                {
                    case SuitType.Club:
                        cardString += "♣";
                        break;
                    case SuitType.Spade:
                        cardString += "♠";
                        break;
                    case SuitType.Heart:
                        cardString += "♥";
                        break;
                    case SuitType.Diamond:
                        cardString += "♦";
                        break;
                }
            }


            System.Console.BackgroundColor = ConsoleColor.Gray;
            if (card.Suit == SuitType.Diamond || card.Suit == SuitType.Heart)
                System.Console.ForegroundColor = ConsoleColor.Red;
            else
                System.Console.ForegroundColor = ConsoleColor.Black;

            System.Console.Write(cardString + " ");
            System.Console.ResetColor();

        }
    }
}
