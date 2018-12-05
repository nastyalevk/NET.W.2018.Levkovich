using System;
using System.Runtime.InteropServices;
using System.Threading;


namespace TimerLibrary
{
    public class Timer
    {
        public event EventHandler<TimerEventArgs> Event = delegate { };

        public void Count(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.WriteLine("{0} sec", i);
                Thread.Sleep(1000);
            }

            OnEvent(this, new TimerEventArgs() {Second = seconds});
        }

        protected virtual void OnEvent(object sender, TimerEventArgs e)
        {
            this.Event?.Invoke(sender, e);
        }
    }
}
