using System;

namespace Assets.Scripts.Definitions
{
    public class TimeBasedEvent
    {
        public DateTime StartTime { get; set; }

        public Action Event { get; set; }
    }
}
