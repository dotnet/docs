//<Snippet1>
using System;

namespace DesignLibrary
{
   public class CustomEventArgs : EventArgs
   {
      public string info = "data";
   }

   public class ClassThatRaisesEvent
   {
      public event EventHandler<CustomEventArgs> SomeEvent;

      protected virtual void OnSomeEvent(CustomEventArgs e)
      {
         if(SomeEvent != null)
         {
            SomeEvent(this, e);
         }
      }

      public void SimulateEvent()
      {
         OnSomeEvent(new CustomEventArgs());
      }
   }

   public class ClassThatHandlesEvent
   {
      public ClassThatHandlesEvent(ClassThatRaisesEvent eventRaiser)
      {
         eventRaiser.SomeEvent += 
            new EventHandler<CustomEventArgs>(HandleEvent);
      }

      private void HandleEvent(object sender, CustomEventArgs e)
      {
         Console.WriteLine("Event handled: {0}", e.info);
      }
   }

   class Test
   {
      static void Main()
      {
         ClassThatRaisesEvent eventRaiser = new ClassThatRaisesEvent();
         ClassThatHandlesEvent eventHandler = 
            new ClassThatHandlesEvent(eventRaiser);

         eventRaiser.SimulateEvent();
      }
   }
}
//</Snippet1>
