using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Obacher.CardGame.Core.UnitTest
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void SetValues_WhenNotCalled_ShouldSetDefaults()
        {
            Deck target = new Deck();
            var cards = target.Deal(52);

            foreach (var card in cards)
            {
                switch (card.Rank)
                {
                    case RankType.Two:
                        card.Value.Should().Be(2);
                        break;
                    case RankType.Three:
                        card.Value.Should().Be(3);
                        break;
                    case RankType.Four:
                        card.Value.Should().Be(4);
                        break;
                    case RankType.Five:
                        card.Value.Should().Be(5);
                        break;
                    case RankType.Six:
                        card.Value.Should().Be(6);
                        break;
                    case RankType.Seven:
                        card.Value.Should().Be(7);
                        break;
                    case RankType.Eight:
                        card.Value.Should().Be(8);
                        break;
                    case RankType.Nine:
                        card.Value.Should().Be(9);
                        break;
                    case RankType.Ten:
                        card.Value.Should().Be(10);
                        break;
                    case RankType.Jack:
                        card.Value.Should().Be(11);
                        break;
                    case RankType.Queen:
                        card.Value.Should().Be(12);
                        break;
                    case RankType.King:
                        card.Value.Should().Be(13);
                        break;
                    case RankType.Ace:
                        card.Value.Should().Be(14);
                        break;
                }
            }
        }

        [TestMethod]
        public void SetValues_WhenFaceCardsSetTo10_ShouldBeSetTo10()
        {
            Deck target = new Deck();
            target.SetFaceCardValues(10);
            var cards = target.Deal(52);

            foreach (var card in cards)
            {
                switch (card.Rank)
                {
                    case RankType.Two:
                        card.Value.Should().Be(2);
                        break;
                    case RankType.Three:
                        card.Value.Should().Be(3);
                        break;
                    case RankType.Four:
                        card.Value.Should().Be(4);
                        break;
                    case RankType.Five:
                        card.Value.Should().Be(5);
                        break;
                    case RankType.Six:
                        card.Value.Should().Be(6);
                        break;
                    case RankType.Seven:
                        card.Value.Should().Be(7);
                        break;
                    case RankType.Eight:
                        card.Value.Should().Be(8);
                        break;
                    case RankType.Nine:
                        card.Value.Should().Be(9);
                        break;
                    case RankType.Ten:
                        card.Value.Should().Be(10);
                        break;
                    case RankType.Jack:
                        card.Value.Should().Be(10);
                        break;
                    case RankType.Queen:
                        card.Value.Should().Be(10);
                        break;
                    case RankType.King:
                        card.Value.Should().Be(10);
                        break;
                    case RankType.Ace:
                        card.Value.Should().Be(11);
                        break;
                }
            }
        }

    }
}
