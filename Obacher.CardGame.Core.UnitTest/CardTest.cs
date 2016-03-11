using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Obacher.CardGame.Core.UnitTest
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void Clone_WhenCalled_ExpectedCloneToBeDifferentType()
        {
            // Arrange
            Card expected = new Card(RankType.Ace, SuitType.Club);

            // Act
            var actual = expected.Clone();

            // Assert
            Assert.AreNotSame(expected, actual);
        }

        [TestMethod]
        public void Clone_WhenCalled_ExpectedCloneToEqual()
        {
            // Arrange
            Card expected = new Card(RankType.Ace, SuitType.Club);

            // Act
            object actual = expected.Clone();

            // Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void GetHashCode_WhenCardsEqual_ExpectedHashCodesToEqual()
        {
            // Arrange
            Card cardOne = new Card(RankType.Ace, SuitType.Club);
            Card cardTwo = new Card(RankType.Ace, SuitType.Club);

            // Act
            var actual = cardOne.GetHashCode() == cardTwo.GetHashCode();

            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void GetHashCode_WhenCardsNotEqual_ExpectedHashCodesToNotEqual()
        {
            // Arrange
            Card cardOne = new Card(RankType.Ace, SuitType.Club);
            Card cardTwo = new Card(RankType.Ten, SuitType.Club);

            // Act
            var actual = cardOne.GetHashCode() == cardTwo.GetHashCode();

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void Equals_WhenTypeIsNotCard_ExpectedEqualToReturnFalse()
        {
            // Arrange
            var expected = DateTime.Now;
            Card card = new Card(RankType.Ace, SuitType.Club);

            // Act
            bool actual = card.Equals(expected);

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void Equals_WhenCardValueIsDifferent_ExpectedEqualToReturnFalse()
        {
            // Arrange
            Card cardOne = new Card(RankType.Ace, SuitType.Club);
            Card cardTwo = new Card(RankType.Ten, SuitType.Club);

            // Act
            bool actual = cardOne.Equals(cardTwo);

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void Equals_WhenSuitIsDifferent_ExpectedEqualToReturnFalse()
        {
            // Arrange
            Card cardOne = new Card(RankType.Ace, SuitType.Club);
            Card cardTwo = new Card(RankType.Ace, SuitType.Diamond);

            // Act
            bool actual = cardOne.Equals(cardTwo);

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void Card_WhenEqualsUsed_ExpectedTrue()
        {
            // Arrange
            Card cardOne = new Card(RankType.Ace, SuitType.Club);
            Card cardTwo = new Card(RankType.Ace, SuitType.Club);

            // Act
            var actual = cardOne == cardTwo;

            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void Card_WhenNotEqualsUsed_ExpectedTrue()
        {
            // Arrange
            Card cardOne = new Card(RankType.Ace, SuitType.Club);
            Card cardTwo = new Card(RankType.Ace, SuitType.Diamond);

            // Act
            var actual = cardOne != cardTwo;

            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void ToString_WhenCalled_ExpectedValidString()
        {
            // Arrange
            const string expected = "Ace:Heart";
            Card card = new Card(RankType.Ace, SuitType.Heart);

            // Act
            var actual = card.ToString();

            // Assert
            actual.Should().Be(expected);
        }
    }
}
