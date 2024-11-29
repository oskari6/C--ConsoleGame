using NAudio.Wave;
using ANSIConsole;

namespace ConsoleApp1
{
    static class Program
    {
        private static readonly string _path = Directory.GetCurrentDirectory() + @"\test.mp3";//musiikki 

        static void Main(string[] args)
        {
            if (!ANSIInitializer.Init(false)) ANSIInitializer.Enabled = false;
            Console.SetOut(new Scaling(Console.Out));//skaalaus

            using (var audioFile = new AudioFileReader(_path))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    UI.GameLoop();//peli
                }
            }

        }
    }
}