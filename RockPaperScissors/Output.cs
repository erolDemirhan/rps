using System;
using System.Linq;
using Figgle;
using RockPaperScissors.Interfaces;
using static Crayon.Output;

namespace RockPaperScissors
{
    public class Output : IOutput
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void WriteTitle(string title)
        {
            var words = title.Split(' ');
            foreach (var word in words)
            {
                Console.WriteLine(Yellow(FiggleFonts.Big.Render(word)));
            }
        }

        public void WriteHorizontalLine()
        {
            var chars = Enumerable.Repeat('-', Console.BufferWidth);
            var line = new string(chars.ToArray());
            Console.Write(Yellow(line + Environment.NewLine));
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(Yellow(line));
        }
    }
}
