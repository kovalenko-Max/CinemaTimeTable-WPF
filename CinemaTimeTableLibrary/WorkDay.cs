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
                return TimeOfEnd - TimeOfStart;
            }
        }

        public WorkDay(TimeSpan timeOfStart, TimeSpan timeOfEnd)
        {
            TimeOfStart = timeOfStart;
            TimeOfEnd = timeOfEnd;
        }

        public override bool Equals(object obj)
        {
            if (obj is WorkDay)
            {
                WorkDay comparedWorkDay = (WorkDay)obj;
                return TimeOfStart == comparedWorkDay.TimeOfStart
                    && TimeOfEnd == comparedWorkDay.TimeOfEnd;
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
