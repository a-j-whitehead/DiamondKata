using DiamondKata;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DiamondKataTests
{
    public class DiamondConstructorTests
    {
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 'A', new List<string> { "A" } };
            yield return new object[] { 'B', new List<string> { "_A_", "B_B", "_A_" } };
            yield return new object[] { 'c', new List<string> { "__A__", "_B_B_", "C___C", "_B_B_", "__A__" } };
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void ShouldReturnCorrectLinesWitValidParameter(string character, IEnumerable<string> expectedLines)
        {
            var actualLines = DiamondConstructor.ConstructDiamondLines(character);
            actualLines.Should().BeEquivalentTo(expectedLines);
        }

        [Theory]
        [InlineData("")]
        [InlineData("Ab")]
        [InlineData("5")]
        [InlineData(";")]
        public void ShouldThrowArgumentExceptionWithInvalidParameter(string character)
        {
            Assert.Throws<ArgumentException>(() => DiamondConstructor.ConstructDiamondLines(character).ToList());
        }
    }
}
