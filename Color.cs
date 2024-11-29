
namespace ConsoleApp1
{
    static class Color  
    {
        private static string _def = "\u001b[37m"; //perusväri, tulostus
        private const string _red = "\u001b[31m"; // Punainen
        private const string _green = "\u001b[32m"; // Vihreä
        private const string _blue = "\u001b[36m"; // Sinivihreä
        private const string _purple = "\u001b[35m"; // Violetti
        private const string _yellow = "\u001b[33m"; // Keltainen

        internal static string Red { get { return _red; } }
        internal static string Green { get { return _green; } }
        internal static string Blue { get { return _blue; } }
        internal static string Purple { get { return _purple; } }
        internal static string Yellow { get { return _yellow; } }
        internal static string Def
        {
            get => _def;
            set => _def = value;
        }

        internal static string Apply(string? text, string color)
        {
            return $"{color}{text}{Def}";
        }//tekstiin
        internal static string Apply(int text, string color)
        {
            return $"{color}{text}{Def}";
        }//numeroon
        internal static string Apply(int? text, string color)
        {
            return $"{color}{text}{Def}";
        }//mahdollinen null numeroon
    }
}
