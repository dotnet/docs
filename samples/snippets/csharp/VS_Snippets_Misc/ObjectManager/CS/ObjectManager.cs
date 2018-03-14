//Types:System.Runtime.Serialization.ObjectManager Vendor: Richter
//<snippet1>
using System;
using System.Text;
using System.Collections;
using System.Runtime.Serialization;
using System.Reflection;

// This class walks through all the objects once in an object graph.
public sealed class ObjectWalker : IEnumerable, IEnumerator {
   private Object m_current;

   // This stack contains the set of objects that will be enumerated.
   private Stack m_toWalk = new Stack();

   // The ObjectIDGenerator ensures that each object is enumerated just once.
   private ObjectIDGenerator m_idGen = new ObjectIDGenerator();

   // Construct an ObjectWalker passing the root of the object graph.
   public ObjectWalker(Object root) {
      Schedule(root);
   }

   // Return an enumerator so this class can be used with foreach.
   public IEnumerator GetEnumerator() {
      return this;
   }

   // Resetting the enumerator is not supported.
   public void Reset() {
      throw new NotSupportedException("Resetting the enumerator is not supported.");
   }

   // Return the enumeration's current object.
   public Object Current { get { return m_current; } }
   
   // Walk the reference of the passed-in object.
   private void Schedule(Object toSchedule) {
      if (toSchedule == null) return;

      // Ask the ObjectIDManager if this object has been examined before.
      Boolean firstOccurrence;
      m_idGen.GetId(toSchedule, out firstOccurrence);

      // If this object has been examined before, do not look at it again just return.
      if (!firstOccurrence) return;

      if (toSchedule.GetType().IsArray) {
         // The object is an array, schedule each element of the array to be looked at.
         foreach (Object item in ((Array)toSchedule)) Schedule(item);
      } else {
         // The object is not an array, schedule this object to be looked at.
         m_toWalk.Push(toSchedule);
      }
   }

   // Advance to the next item in the enumeration.
   public Boolean MoveNext() {
      // If there are no more items to enumerate, return false.
      if (m_toWalk.Count == 0) return false;

      // Check if the object is a terminal object (has no fields that refer to other objects).
      if (!IsTerminalObject(m_current = m_toWalk.Pop())) {
         // The object does have field, schedule the object's instance fields to be enumerated.
         foreach (FieldInfo fi in m_current.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)) {
            Schedule(fi.GetValue(m_current));
         }
      }
      return true;
   }

   // Returns true if the object has no data fields with information of interest.
   private Boolean IsTerminalObject(Object data) {
      Type t = data.GetType();
      return t.IsPrimitive || t.IsEnum || t.IsPointer || data is String;
   }
}


public sealed class App {
   // Define some fields in the class to test the ObjectWalker.
   public String name = "Fred";
   public Int32 Age = 40;

   static void Main() {
      // Build an object graph using an array that refers to various objects.
      Object[] data = new Object[] { "Jeff", 123, 555L, (Byte) 35, new App() };

      // Construct an ObjectWalker and pass it the root of the object graph.
      ObjectWalker ow = new ObjectWalker(data);

      // Enumerate all of the objects in the graph and count the number of objects.
      Int64 num = 0;
      foreach (Object o in ow) {
         // Display each object's type and value as a string.
         Console.WriteLine("Object #{0}: Type={1}, Value's string={2}", 
            num++, o.GetType(), o.ToString());
      }
   }
}

// This code produces the following output.
//
// Object #0: Type=App, Value's string=App
// Object #1: Type=System.Int32, Value's string=40
// Object #2: Type=System.String, Value's string=Fred
// Object #3: Type=System.Byte, Value's string=35
// Object #4: Type=System.Int64, Value's string=555
// Object #5: Type=System.Int32, Value's string=123
// Object #6: Type=System.String, Value's string=Jeff
//</snippet1>
