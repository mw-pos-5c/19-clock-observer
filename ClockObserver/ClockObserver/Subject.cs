using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockObserver
{
    public class Subject
    {
        private List<IObserver> observers = new List<IObserver>();


        public void Attach(IObserver observer)
        {
            lock (observers)
            {
                observers.Add(observer);
            }
        }

        public void Detach(IObserver observer)
        {
            lock (observers)
            {
                observers.Remove(observer);
            }
        }

        public void Notify()
        {
            lock (observers)
            {
                foreach (IObserver observer in observers)
                {
                    observer.Update();
                }
            }
        }

    }
}
