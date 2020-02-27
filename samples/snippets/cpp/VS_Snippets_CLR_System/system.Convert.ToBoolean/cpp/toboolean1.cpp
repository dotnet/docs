// Convert.ToBoolean2.cpp : main project file.

// <Snippet1>
using namespace System;

void main()
{
   array<String^>^ values = gcnew array<String^> { nullptr, String::Empty,
                                                   "true", "TrueString",
                                                   "False", "    false    ",
                                                   "-1", "0" };
   for each (String^ value in values) {
      try
      {
         Console::WriteLine("Converted '{0}' to {1}.", value,  
                           Convert::ToBoolean(value));
      }
      catch (FormatException^ e)
      {
         Console::WriteLine("Unable to convert '{0}' to a Boolean.", value);
      }
   }
}
// The example displays the following output:
//       Converted '' to False.
//       Unable to convert '' to a Boolean.
//       Converted 'true' to True.
//       Unable to convert 'TrueString' to a Boolean.
//       Converted 'False' to False.
//       Converted '    false    ' to False.
//       Unable to convert '-1' to a Boolean.
//       Unable to convert '0' to a Boolean.
// </Snippet1>




