using System;

namespace DesignLibrary
{
   public class AlarmEventArgs : EventArgs {}
   public delegate void AlarmEventHandler(object sender, AlarmEventArgs e);
}