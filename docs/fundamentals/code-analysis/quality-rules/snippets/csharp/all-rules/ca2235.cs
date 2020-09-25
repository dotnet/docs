using System;

namespace ca2235
{
    //<snippet1>
    public class Mouse
    {
        int buttons;
        string scanTypeValue;

        public int NumberOfButtons
        {
            get { return buttons; }
        }

        public string ScanType
        {
            get { return scanTypeValue; }
        }

        public Mouse(int numberOfButtons, string scanType)
        {
            buttons = numberOfButtons;
            scanTypeValue = scanType;
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
