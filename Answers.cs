namespace ConsoleApp1
{
    class Answers            
    {
        private readonly static List<string> _correctAnswers = new List<string>() {
            "B", "C", "A", "A", "A", "A", "B", "B", "A", "A", "B", "C", "D", "A", "D", "D", "A", "A", "A", "D", "C", "A", "A", "D", "C", "B", "B", "D", "D", "A", "A", "B", "A", "A", "D" };//oikeat
        private readonly static Dictionary<int, Dictionary<string, string>> _allAnswers = new Dictionary<int, Dictionary<string, string>>
        {
            {1, new Dictionary<string, string>
                {
                    { "A:", "J.A.R.V.I.S" },
                    { "B:", "T.A.R.D.I.S"},
                    { "C:", "S.I.C.A.I" },
                    { "D:", "E.D.I" }
                }
            },
            {2, new Dictionary<string, string>
                {
                    { "A:", "Interstellar" },
                    { "B:", "Independence Day"},
                    { "C:", "Alien" },
                    { "D:", "Total Recall" }
                }
            },
            {3, new Dictionary<string, string>
                {
                    { "A:", "J.A.R.V.I.S" },
                    { "B:", "E.D.I"},
                    { "C:", "I.A.I" },
                    { "D:", "Iron A.I." }
                }
            },
            {4, new Dictionary<string, string>
                {
                    { "A:", "Jabba the Hutt" },
                    { "B:", "Ziro the Hutt"},
                    { "C:", "Rotta the Huttlet" },
                    { "D:", "Gorga the Hutt" }
                }
            },
            {5, new Dictionary<string, string>
                {
                    { "A:", "Commander Shepard" },
                    { "B:", "Private Jenkins"},
                    { "C:", "Engineer Adams" },
                    { "D:", "Gunnery Chief Williams" }
                }
            },
            {6, new Dictionary<string, string> 
                {
                    {"A:", "Vihreä" },
                    {"B:", "Vihreä"  },
                    {"C:", "Punainen"  },
                    {"D:", "Sininen"  }
                }
            },
            {7, new Dictionary<string, string>
                {
                    { "A:", "Judy Garland" },
                    { "B:", "Lana Wachowski" },
                    { "C:", "Paul Newman"   },
                    { "D:", "James Cagney"   }
                }
            },

            {8, new Dictionary<string, string>
                {
                    { "A:","Dwayne Johnson" },
                    { "B:", "Keanu Reeves"},
                    { "C:", "Tauno Palo" },
                    { "D:", "Vin Diesel" }
                }
            },
            {9, new Dictionary<string, string>
                {
                    { "A:","Ray Bradbury" },
                    { "B:", "Isaac Asimov"},
                    { "C:", "Frank Herbert" },
                    { "D:", "William Gibson" }
                }
            },
            {10, new Dictionary<string, string>
                {
                    { "A:","Harvesters" },
                    { "B:", "Sovereigns"},
                    { "C:", "Harbingers" },
                    { "D:", "Little green men" }
                }
            },
            {11, new Dictionary<string, string>
                {
                    { "A:","Lalilulelo" },
                    { "B:", "Leeloo"},
                    { "C:", "Leela" },
                    { "D:", "115" }
                }
            },
            {12, new Dictionary<string, string>
                {
                    { "A:","Vihreän" },
                    { "B:", "Oranssin"},
                    { "C:", "RPunaisen" },
                    { "D:", "Sinisen" }
                }
            },
            {13, new Dictionary<string, string>
                {
                    {"A:", "Henry & Markus" },
                    {"B:", "Jack & Jones" },
                    {"C:", "Musti & Mirri" },
                    {"D:", "Rick ja Morty" }
                }
            },
            {14, new Dictionary<string, string>
                {
                    {"A:", "James Cameron" },
                    {"B:", "Al Pacino" },
                    {"C:", "Natalie Wood"  },
                    {"D:", "Julianne Moore"  }
                }
            },
            {15, new Dictionary<string, string>
                {
                    { "A:","Saturnus" },
                    { "B:", "Uranus"},
                    { "C:", "Neptunus" },
                    { "D:", "Jupiter" }
                }
            },
            {16, new Dictionary<string, string>
                {
                    { "A:","Ei yhtään" },
                    { "B:", "4"},
                    { "C:", "6" },
                    { "D:", "Kaikki" }
                }
            },
            {17, new Dictionary<string, string>
                {
                    { "A:","Kreikassa" },
                    { "B:", "Britanniassa"},
                    { "C:", "Amerikassa" },
                    { "D:", "Kiinassa" }
                }
            },
            {18, new Dictionary<string, string>
                {
                    { "A:","Seitsemän" },
                    { "B:", "Sata"},
                    { "C:", "Kahdeksan" },
                    { "D:", "Neljätoista" }
                }
            },
            {19, new Dictionary<string, string>
                {
                    { "A:","9,5 triljoonaa" },
                    { "B:", "10 miljardia"},
                    { "C:", "20 miljoonaa" },
                    { "D:", "20,5 triljoonaa" }
                }
            },
            {20, new Dictionary<string, string>
                {
                    {"A:", "Daggorath" },
                    {"B:", "Joust" },
                    {"C:", "Dig Dug" },
                    {"D:", "Parzival" }
                }
            },
            {21, new Dictionary<string, string>
                {
                    { "A:", "Albert Einstein" },
                    { "B:", "Madamy Eve" },
                    { "C:", "Victor Frankenstein" },
                    { "D:", "Dracula" }
                }
            },
            {22, new Dictionary<string, string>
                {
                    { "A:", "Tuhat" },
                    { "B:", "Miljardi"},
                    { "C:", "Triljoona" },
                    { "D:", "Sata" }
                }
            },
            {23, new Dictionary<string, string>
                {
                    { "A:","2001: A Space Odysseyt" },
                    { "B:", "Interstellar"},
                    { "C:", "Dune" },
                    { "D:", "Martian" }
                }
            },
            {24, new Dictionary<string, string>
                {
                    { "A:","6 vuotta" },
                    { "B:", "1 vuoden"},
                    { "C:", "20 vuotta" },
                    { "D:", "yli 40 vuotta" }
                }
            },
            {25, new Dictionary<string, string>
                {
                    { "A:","Buzz Aldrin" },
                    { "B:", "Neil Armstrong"},
                    { "C:", "Pete Conrad" },
                    { "D:", "Christina Koch" }
                }
            },

            {26, new Dictionary<string, string>
                {
                    { "A:","Kun se palaa ilmakehässä" },
                    { "B:", "Kun se putoaa Maahan asti"},
                    { "C:", "Kun se räjähtää juuri ennen maahan syöksymistä" },
                    { "D:", "Kun se hohtaa sinisenä" }
                }
            },
            {27, new Dictionary<string, string>
                {
                    { "A:", "Expendables"  },
                    { "B:", "Terminaattori" },
                    { "C:", "Aftermath" },
                    { "D:", "The Last Stand"  }
                }
            },
            {28, new Dictionary<string, string>
                {
                    { "A:", "Godfather" },
                    { "B:", "Wild Cards"},
                    { "C:", "Total Recall"}, 
                    { "D:", "Star Wars" } 
                }
            },
            {29, new Dictionary<string, string>
                {
                    { "A:","Punainen" },
                    { "B:", "Keltainen"},
                    { "C:", "Vihreä" },
                    { "D:", "Valkoinen" }
                }
            },
            {30, new Dictionary<string, string>
                {
                    { "A:","Sininen" },
                    { "B:", "Punainen"},
                    { "C:", "Violetti" },
                    { "D:", "Purppura" }
                }
            },
            {31, new Dictionary<string, string>
                {
                    { "A:","13,7 mrd. vuotta" },
                    { "B:", "20,5 triljoonaa vuotta"},
                    { "C:", "24,9 miljoonaa vuotta" },
                    { "D:", "2024 vuotta" }
                }
            },
            {32, new Dictionary<string, string>
                {
                    { "A:","The Claw" },
                    { "B:", "The Prawn "},
                    { "C:", "The Brawn" },
                    { "D:", "The Clan" }
                }
            },
            {33, new Dictionary<string, string>
                {
                    { "A:","Frank Herbert" },
                    { "B:", "Neil deGrasse Tyson"},
                    { "C:", "Isaac Asimov" },
                    { "D:", "Fjodor Dostojevski" }
                }
            },
            {34, new Dictionary<string, string>
                {
                    { "A:", "Aikakone"},
                    { "B:", "Matkakone" },
                    { "C:", "Tulevakone" },
                    { "D:", "Meneväkone" }
                }
            },
            {35, new Dictionary<string, string>
                {
                    { "A:", "Godfather"  },
                    { "B:", "Lord of the Rings"  },
                    { "C:", "Fight Club"  },
                    { "D:", "Men in Black" }
                }
            },
        };//kaikki

        internal static List<string> CorrectAnswers => _correctAnswers;
        internal static Dictionary<int, Dictionary<string, string>> AllAnswers => _allAnswers;
    }                          
}
