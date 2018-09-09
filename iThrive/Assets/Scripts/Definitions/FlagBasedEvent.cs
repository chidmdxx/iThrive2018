using System;

namespace Assets.Scripts.Definitions
{
    public class FlagBasedEvent
    {
        public GameFlags requiredFlags { get; set; }
        public Action Event { get; set; }
    }
}
