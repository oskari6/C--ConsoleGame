
namespace ConsoleApp1
{
    class Users
    {   //käyttäjän attibuutit
        private string _name;
        private string _abbreviation;
        //time stamp
        private static DateTime _timeStamp = DateTime.Now;
        private static string  _formattedTimeStamp = _timeStamp.ToString("yyyy-MM-dd");

        private static List<Users> _userList = new List<Users>();//toiminnallisuus ja käyttäjän ominaisuuksien haulle
        private static readonly string _path = Directory.GetCurrentDirectory() + @"\usernames.txt";//käyttäjät 

        internal string Name
        {
            get => _name;
            set => _name = value;
        }
        internal string Abbreviation
        {
            get => _abbreviation;
            set => _abbreviation = value;
        }
        internal static DateTime TimeStamp => _timeStamp;
        internal static string FormattedTimeStamp => _formattedTimeStamp;
        internal static List<Users> UserList
        {
            get => _userList;
            set => _userList = value;
        }

        internal Users(string name, string abbreviation)
        {
            this.Name = name;
            this.Abbreviation = abbreviation;
        }//käyttäjä
        internal void UserToFile(string abbreviation, string user)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(_path))
                {
                    writer.WriteLine($"{abbreviation} | {user} | {FormattedTimeStamp}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ongelma tiedostoon kirjoituksessa: {ex.Message}");
            }
        }//pelaajat tiedosto w
        internal static void GetUser()
        {
            Console.WriteLine("PELAAJAT\n");
            try
            {
                string[] lines = File.ReadAllLines(_path);

                int startIndex = Math.Max(0, lines.Length - 10);

                for (int i = lines.Length - 1; i >= startIndex; i--)
                {
                    Console.WriteLine(lines[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Virhe tiedostoa lukiessa: {ex.Message}");
            }
            UI.EnterCheck();
            UI.GameStart();
        }//pelaajat tiedosto r
        internal static Users UserNames()
        {
            string name;
            string abbreviation;
            do
            {
                Console.Write("Anna pelaajan nimi: ");
                name = Console.ReadLine() ?? "0";
                if (string.IsNullOrEmpty(name) || name.Length > 10)
                {
                    Console.WriteLine(Color.Apply("Sopimaton nimi, yritä uudestaan", Color.Red));
                }
                else
                {
                    Console.Clear();
                    break;
                }
            } while (true);
            do
            {
                Console.Write("Anna nimen lyhenne tuloksia varten (3-kirjainta): ");
                abbreviation = Console.ReadLine() ?? "0";
                if (string.IsNullOrEmpty(abbreviation) || abbreviation.Length > 3)
                {
                    Console.WriteLine(Color.Apply("Sopimaton lyhenne, yritä uudestaan", Color.Red));
                }
                else
                {
                    Console.Clear();
                    break;
                }
            } while (true);

            Users user = new Users(name, abbreviation);

            user.Abbreviation = abbreviation;
            user.UserToFile(abbreviation, name);

            Console.Clear();
            return user;
        }//käyttäjä luonti
    }
}
