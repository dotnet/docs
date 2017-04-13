//<Snippet1>
using System;

namespace DesignLibrary
{
   // This delegate violates the rule.
   public delegate void CustomEventHandler(
      object sender, CustomEventArgs e);

   public class CustomEventArgs : EventArgs
   {
      public string info = "data";
   }

   public class ClassThatRaisesEvent
   {
      public event CustomEventHandler SomeEvent;

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
            new CustomEventHandler(HandleEvent);
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
