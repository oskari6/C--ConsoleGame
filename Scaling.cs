using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Scaling : TextWriter
    {
        private readonly TextWriter _originalOut;
        private readonly int _consoleWidth;
        public override Encoding Encoding => _originalOut.Encoding;
        public Scaling(TextWriter originalOut)
        {
            _originalOut = originalOut;
            _consoleWidth = Console.WindowWidth;
        }//tulostus
        public override void Write(string? value)
        {
            if (value == null)
            {
                value = string.Empty;
            }

            string colorPattern = @"\x1B\[[0-9;]*m";

            string valueWithoutColors = Regex.Replace(value, colorPattern, "");

            int totalLength = valueWithoutColors.Length;

            int centerX = (_consoleWidth - totalLength) / 2;
            if (centerX < 0) centerX = 0;

            for (int i = 0; i < centerX; i++)
            {
                _originalOut.Write(" ");
            }

            _originalOut.Write(value);

            int cursorLeft = centerX + valueWithoutColors.Length;

            Console.SetCursorPosition(cursorLeft, Console.CursorTop);
        }//console.writeille, regexejä ansi värien takia
        public override void WriteLine(string? value)
        {
            if (value == null)
            {
                value = string.Empty;
            }
            string colorPattern = @"\x1B\[[0-9;]*m";

            string valueWithoutColors = Regex.Replace(value, colorPattern, "");

            int totalLength = valueWithoutColors.Length;

            int centerX = (_consoleWidth - totalLength) / 2;
            if (centerX < 0) centerX = 0;

            for (int i = 0; i < centerX; i++)
            {
                _originalOut.Write(" ");
            }

            _originalOut.Write(value);

            _originalOut.WriteLine();
        }//console.writelineille sama homma
    }//skaalaus
}
