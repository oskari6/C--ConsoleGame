using System.Timers;

namespace ConsoleApp1
{
    static class Timer
    {   //game time
        private static System.Timers.Timer? _timer;
        private static int _remainingTimeInSeconds;
        private static TimeSpan _timeSpan;
        private static TimeSpan _timeSpanGame;

        //win screen
        private static int _totalTime;
        private static int _remainingTime;
        private static string? _formattedTime;
        private static int _playingTimeSeconds;
        private static TimeSpan _playingTime = TimeSpan.FromSeconds(PlayingTimeSeconds);
        private static string? _formattedPlayingTime;

        public static System.Timers.Timer? MyTimer
        {
            get => _timer;
            set => _timer = value;
        }
        public static int RemainingTimeInSeconds
        {
            get => _remainingTimeInSeconds;
            set => _remainingTimeInSeconds = value;
        }
        public static TimeSpan TimeSpan
        {
            get => _timeSpan;
            set => _timeSpan = value;
        }
        public static TimeSpan TimeSpanGame
        {
            get => _timeSpanGame;
            set => _timeSpanGame = value;
        }

        internal static int TotalTime
        {
            get => _totalTime;
            set => _totalTime = value;
        }
        internal static int RemainingTime
        {
            get => _remainingTime;
            set => _remainingTime = value;
        }
        internal static string? FormattedTime
        {
            get => _formattedTime;
            set => _formattedTime = value;
        }
        internal static int PlayingTimeSeconds
        {
            get => _playingTimeSeconds;
            set => _playingTimeSeconds = value;
        }
        internal static TimeSpan PlayingTime
        {
            get => _playingTime;
            set => _playingTime = value;
        }
        internal static string FormattedPlayingTime
        {
            get => _formattedPlayingTime;
            set => _formattedPlayingTime = value;
        }

        //ajastimelle
        internal static void SetTimer(int difficulty)
        {
            switch (difficulty)
            {
                case 1:
                    RemainingTimeInSeconds = 600; // 10 min
                    break;
                case 2:
                    RemainingTimeInSeconds = 480; // 8 min
                    break;
                case 3:
                    RemainingTimeInSeconds = 420; // 7 min
                    break;
                case 4:
                    RemainingTimeInSeconds = 360; // 6 min
                    break;
                case 5:
                    RemainingTimeInSeconds = 300; // 5 min
                    break;
                default:
                    RemainingTimeInSeconds = 5; // 1 min
                    break;
            }
            TotalTime = RemainingTimeInSeconds;
            MyTimer = new System.Timers.Timer(1000); // 1s intervalli
            MyTimer.Elapsed += TimerElapsed;
            MyTimer.Start();
        }//aloitus
        private static void TimerElapsed(object? sender, ElapsedEventArgs e)
        {
            RemainingTimeInSeconds--;
            if (RemainingTimeInSeconds <= 0)
            {
                StopTimer();
            }
        }//kulunut aika
        internal static void PrintRemainingTime()
        {
            TimeSpan = TimeSpan.FromSeconds(RemainingTimeInSeconds);
            Console.WriteLine($"Aikaa jäljellä: {Color.Apply($"{TimeSpan.Minutes}:{TimeSpan.Seconds:00}", Color.Red)}\n");
        }//tulostus
        internal static void StopTimer()
        {
            if (MyTimer != null)
            {
                MyTimer.Stop();
                MyTimer.Dispose();
            }
        }//pysäytys
        internal static int GetRemainingTimeInSeconds()
        {
            return RemainingTimeInSeconds;
        }//jäljellä oleva aika
    }
}