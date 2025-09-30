using System;

namespace ca2235
{
    //<snippet1>
    public class Mouse
    {
        public int NumberOfButtons { get; }

        public string ScanType { get; }

        public Mouse(int numberOfButtons, string scanType)
        {
            NumberOfButtons = numberOfButtons;
            ScanType = scanType;
        }
    }

    [Serializable]
    public class InputDevices1
    {
        // Violates MarkAllNonSerializableFields.
        Mouse opticalMouse;

        public InputDevices1()
        {
            opticalMouse = new Mouse(5, "optical");
        }
    }

    [Serializable]
    public class InputDevices2
    {
        // Satisfies MarkAllNonSerializableFields.
        [NonSerialized]
        Mouse opticalMouse;

        public InputDevices2()
        {
            opticalMouse = new Mouse(5, "optical");
        }
    }
    //</snippet1>
}
