using Microsoft.VisualStudio.TestPlatform.TestHost;
using Converter;
namespace Converter.Tests
{
    public class ConverterTests
    {
        [Fact]
        public void ParseToInt_ValidNumeralList_ReturnsCorrectValue()
        {
            var numerals = new List<string> { "twenty", "five" };
            int expectedValue = 25;

            int result = Converter.ParseToInt(numerals);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void ParseToInt_EmptyNumeralList_ReturnsZero()
        {
            var numerals = new List<string>();

            int result = Converter.ParseToInt(numerals);

            Assert.Equal(0, result);
        }

        [Fact]
        public void ParseToInt_NumeralListWithMultiplier_ReturnsCorrectValue()
        {
            var numerals = new List<string> { "two", "million", "three", "hundred", "four", "thousand", "five" };
            int expectedValue = 2304005;

            int result = Converter.ParseToInt(numerals);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void ParseToInt_NumeralListWithWord_ReturnsCorrectValueIgnoringWord()
        {
            var numerals = new List<string> { "invalid", "twenty", "five" };
            int expectedValue = 25;

            int result = Converter.ParseToInt(numerals);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void CheckIfNumeral_ValidNumeral_ReturnsTrue()
        {
            string validNumeral = "thousand";

            bool result = Converter.CheckIfNumeral(validNumeral);

            Assert.True(result);
        }

        [Fact]
        public void CheckIfNumeral_InvalidNumeral_ReturnsFalse()
        {
            string invalidNumeral = "invalid";

            bool result = Converter.CheckIfNumeral(invalidNumeral);

            Assert.False(result);
        }

        [Fact]
        public void CheckIfNumeral_NumeralInWordToNumberMap_ReturnsTrue()
        {
            string numeralInWordToNumberMap = "five";

            bool result = Converter.CheckIfNumeral(numeralInWordToNumberMap);

            Assert.True(result);
        }

        [Fact]
        public void CheckIfNumeral_NumeralInMultiplyersToNumberMap_ReturnsTrue()
        {
            string numeralInMultiplyersToNumberMap = "million";

            bool result = Converter.CheckIfNumeral(numeralInMultiplyersToNumberMap);

            Assert.True(result);
        }

        [Fact]
        public void CheckIfNumeral_EmptyString_ReturnsFalse()
        {
            string emptyString = string.Empty;

            bool result = Converter.CheckIfNumeral(emptyString);

            Assert.False(result);
        }

        [Fact]
        public void ConvertWordsToNumbers_ValidInputWithoutExtraWords_ReturnsCorrectOutput()
        {
            string input = "one hundred forty three thousand seven hundred twenty one";
            string expectedOutput = "143721";

            string result = Converter.ConvertWordsToNumbers(input);

            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void ConvertWordsToNumbers_WordsWithNonAlphaCharacters_ReturnsCorrectOutput()
        {
            string input = "one$ apple two? peach three^ forks";
            string expectedOutput = "1 apple 2 peach 3 forks";

            string result = Converter.ConvertWordsToNumbers(input);

            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void ConvertWordsToNumbers_InputWithUpperCase_ReturnsLowerCase()
        {
            string input = "VAlid ONe HUnDreD TweNTY ThreE Text";
            string expectedOutput = "valid 123 text";

            string result = Converter.ConvertWordsToNumbers(input);

            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void ConvertWordsToNumbers_EmptyInput_ReturnsEmptyOutput()
        {
            string input = string.Empty;
            string expectedOutput = string.Empty;

            string result = Converter.ConvertWordsToNumbers(input);

            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void ConvertWordsToNumbers_InputWithNumeralsInTheEnd_ReturnsCorrectOutput()
        {
            string input = "amount of russia population is one hundred forty four million three hundred seventy eight thousand eight hundred thirty three";
            string expectedOutput = "amount of russia population is 144378833";

            string result = Converter.ConvertWordsToNumbers(input);

            Assert.Equal(expectedOutput, result);
        }
    }
}