using System;
using TimerLibrary;

namespace TimerConsole
{
    public class SecondObserver
    {
        public void Subscribe(Timer timer) => timer.Event += Message;

        public void Message(object sender, TimerEventArgs e)
        {
            Console.WriteLine("First observer react " + e.Second);
        }

        public void Unsubscribe(Timer timer) => timer.Event -= Message;
    }
}