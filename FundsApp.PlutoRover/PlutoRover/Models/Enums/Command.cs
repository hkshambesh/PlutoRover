using System.ComponentModel;

namespace PlutoRover.Models.Enums
{
    public enum Command
    {
        [Description("Forward")]
        F,

        [Description("Backward")]
        B,

        [Description("Right")]
        R,

        [Description("L")]
        L
    }
}