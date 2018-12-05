using System;

namespace TimerLibrary
{
    public class TimerEventArgs:EventArgs
    {
        public int Second { get; set; }
    }
}