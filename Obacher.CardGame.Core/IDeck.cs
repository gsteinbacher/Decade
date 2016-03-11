using System.Collections.Generic;

namespace Obacher.CardGame.Core
{
    public interface IDeck
    {
        Card DealCard();
        IEnumerable<Card> Deal(int number);
        void Shuffle();

        IDeck SetFaceCardValues(int value = 10);

        IDeck SetTwoValue(int numericValue);
        IDeck SetThreeValue(int numericValue);
        IDeck SetFourValue(int numericValue);
        IDeck SetFiveValue(int numericValue);
        IDeck SetSixValue(int numericValue);
        IDeck SetSevenValue(int numericValue);
        IDeck SetEightValue(int numericValue);
        IDeck SetNineValue(int numericValue);
        IDeck SetTenValue(int numericValue);
        IDeck SetJackValue(int numericValue);
        IDeck SetQueenValue(int numericValue);
        IDeck SetKingValue(int numericValue);
        IDeck SetAceValue(int numericValue);
        IDeck SetValue(RankType rankType, int value, bool force = true);

    }
}