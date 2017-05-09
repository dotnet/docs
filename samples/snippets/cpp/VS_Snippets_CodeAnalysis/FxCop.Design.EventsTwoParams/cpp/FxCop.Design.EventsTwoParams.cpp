//<Snippet1>
using namespace System;

namespace DesignLibrary
{
   public ref class AlarmEventArgs : public EventArgs {};
   public delegate void AlarmEventHandler(
      Object^ sender, AlarmEventArgs^ e);
}
//</Snippet1>
