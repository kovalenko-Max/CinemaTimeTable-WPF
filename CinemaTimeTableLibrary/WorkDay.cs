using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTimeTableLibrary
{
    public class WorkDay
    {
        public TimeSpan TimeOfStart { get; set; }
        public TimeSpan TimeOfEnd { get; set; }
        public TimeSpan TimeLeft
        {
            get
            {
                return TimeLeft = TimeOfEnd - TimeOfStart;
            }
            private set
            {

            }
        }

        public WorkDay(TimeSpan timeOfStart, TimeSpan timeOfEnd)
        {
            TimeOfStart = timeOfStart;
            TimeOfEnd = timeOfEnd;
            TimeLeft = timeOfEnd - timeOfStart;
        }

        public override bool Equals(object obj)
        {
            if (obj is WorkDay)
            {
                WorkDay comparedWorkDay = (WorkDay)obj;
                return TimeOfStart == comparedWorkDay.TimeOfStart
                    && TimeOfEnd == comparedWorkDay.TimeOfEnd
                    && TimeLeft == comparedWorkDay.TimeLeft;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"TimeOfStart = {TimeOfStart}, TimeOfEnd = {TimeOfEnd}, TimeLeft = {TimeLeft}";
        }
    }
}
