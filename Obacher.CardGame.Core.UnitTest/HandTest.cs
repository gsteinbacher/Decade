using System;
using System.Collections;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obacher.UnitTest.Tools;

namespace Obacher.CardGame.Core.UnitTest
{
    [TestClass]
    public class HandTest
    {
        [TestMethod, ExceptionExpected(typeof(ArgumentOutOfRangeException), "Hand must contain")]
        public void GetEnumerator_WhenHandEmpty_ExpectNull()
        {
            // Arrange
            new Hand();

            // Act

            // Arrange
        }

        [TestMethod]
        public void GetEnumerator_WhenCalled_ExpectEnumerator()
        {
            // Arrange
            var expected = new Card(RankType.Ace, SuitType.Club);
            Hand hand = new Hand(
                expected
             );

            // Act
            var actual = hand.FirstOrDefault();

            // Arrange
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void GetEnumerator_WhenIEnumerabled_ExpectedExpectEnumerator()
        {
            // Arrange
            var expected = new Card(RankType.Ace, SuitType.Club);
            var hand = new Hand(
                expected
             ).As<IEnumerable>();

            // Act
            var target = hand.GetEnumerator();
            target.MoveNext();
            var actual = target.Current;

            // Arrange
            actual.Should().Be(expected);
        }
    }
}
