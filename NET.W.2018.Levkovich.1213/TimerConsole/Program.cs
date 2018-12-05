using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  TimerLibrary;

namespace TimerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer seconds = new Timer();
            FirstObserver first = new FirstObserver();
            SecondObserver second=new SecondObserver();
            
            first.Subscribe(seconds);
            second.Subscribe(seconds);
            seconds.Count(5);

            first.Unsubscribe(seconds);
            seconds.Count(3);

            Console.ReadKey();
        }
    }
}
