using System;

namespace ca2235
{
    //<snippet1>
    public record class Mouse(int NumberOfButtons, string ScanType);

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
