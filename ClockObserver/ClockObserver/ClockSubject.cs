using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockObserver
{
    public class ClockSubject : Subject
    {
        private string? time;

        public string Time
        {
            get { return time ?? "unknown"; }
            set {
                time = value;
                Notify();
            }
        }
    }
}
