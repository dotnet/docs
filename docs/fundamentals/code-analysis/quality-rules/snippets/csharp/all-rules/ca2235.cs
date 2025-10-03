using System;

namespace ca2235
{
    //<snippet1>
    public class Mouse(int numberOfButtons, string scanType)
    {
        public int NumberOfButtons { get; } = numberOfButtons;
        public string ScanType { get; } = scanType;
    }

    [Serializable]
    public class InputDevices1
    {
        // Violates MarkAllNonSerializableFields.
        readonly Mouse _opticalMouse;

        public InputDevices1()
        {
            _opticalMouse = new Mouse(5, "optical");
        }
    }

    [Serializable]
    public class InputDevices2
    {
        // Satisfies MarkAllNonSerializableFields.
        [NonSerialized]
        readonly Mouse _opticalMouse;

        public InputDevices2()
        {
            _opticalMouse = new Mouse(5, "optical");
        }
    }
    //</snippet1>
}
