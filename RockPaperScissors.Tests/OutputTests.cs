using System;
using System.IO;
using Xunit;
using Figgle;
using FluentAssertions;
using static Crayon.Output;

namespace RockPaperScissors.Tests
{
    // Can't find a good way to test HorizontalLine and Clear.
    public class OutputTests
    {
        private readonly Output output;
        private readonly StringWriter stringWriter;
        public OutputTests()
        {
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            output = new Output();
        }

        [Fact]
        public void WriteTitleCallsConsolePerWord()
        {
            const string title = Constants.Title;
            var words = title.Split(' ');
            var expected = "";
            foreach (var word in words)
            {
                var formatted = (Yellow(FiggleFonts.Big.Render(word))) + Environment.NewLine; 
                expected += formatted;
            }
            output.WriteTitle(title);
            var actual = stringWriter.ToString().Trim();
            actual.Should().Be(expected.Trim());
        }

        [Fact]
        public void WriteLine()
        {
            var line = "This is what I want to say";
            output.WriteLine(line);
            var expected = Yellow(line).Trim();
            var actual = stringWriter.ToString().Trim();
            actual.Should().Be(expected);
        }
    }
}
