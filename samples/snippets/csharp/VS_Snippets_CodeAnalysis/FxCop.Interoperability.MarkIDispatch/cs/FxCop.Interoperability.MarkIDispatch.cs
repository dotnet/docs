//<Snippet1>
using System;
using System.Runtime.InteropServices;

[assembly: ComVisible(true)]
namespace InteroperabilityLibrary
{
   // This violates the rule for type EventSource.
   [InterfaceType(ComInterfaceType.InterfaceIsDual)]
   public interface IEventsInterface
   {
      void EventOne();
      void EventTwo();
   }

   // This satisfies the rule.
   [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
   public interface IMoreEventsInterface
   {
      void EventThree();
      void EventFour();
   }

   [ComSourceInterfaces(
      "InteroperabilityLibrary.IEventsInterface\0" + 
      "InteroperabilityLibrary.IMoreEventsInterface")]
   public class EventSource
   {
      // Event and method declarations.
   }
}
//</Snippet1>
