using System.ComponentModel;

namespace PlutoRover.Models.Enums
{
    public enum Direction
    {
        [Description("Unknown")]
        Unknown = 0,

        [Description("North")]
        N,

        [Description("South")]
        S,

        [Description("West")]
        W,

        [Description("East")]
        E
    }
}