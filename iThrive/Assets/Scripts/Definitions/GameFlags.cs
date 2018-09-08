using System;

namespace Assets.Scripts.Definitions
{
    [Flags]
    public enum GameFlags
    {
        None = 0,
        Coffee = 1 << 0,
        WalkDog = 1 << 1,
        CleanRoom = 1 << 2,
    }
}
