//<Snippet1>
using System;
using System.Runtime.Serialization;

namespace UsageLibrary
{
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

   [SerializableAttribute]
   public class InputDevices1
   {
      // Violates MarkAllNonSerializableFields.
      Mouse opticalMouse;

      public InputDevices1()
      {
         opticalMouse = new Mouse(5, "optical"); 
      }
   }

   [SerializableAttribute]
   public class InputDevices2
   {
      // Satisfies MarkAllNonSerializableFields.
      [NonSerializedAttribute]
      Mouse opticalMouse;

      public InputDevices2()
      {
         opticalMouse = new Mouse(5, "optical"); 
      }
   }
}
//</Snippet1>
