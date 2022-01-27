using System;
namespace RockPaperScissors.Interfaces
{
    public interface IOutput
    {
        void Clear();
        void WriteTitle(string title);
        void WriteHorizontalLine();
        void WriteLine(string line);
    }
}
