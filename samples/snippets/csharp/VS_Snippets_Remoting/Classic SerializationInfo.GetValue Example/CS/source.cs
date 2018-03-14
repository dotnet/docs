using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

// <Snippet1>
// A serializable LinkedList example.  For the full LinkedList implementation
// see the Serialization sample.
[Serializable()]
class LinkedList: ISerializable {

   public static void Main() {}

   Node m_head = null;
   Node m_tail = null;
   
   // Serializes the object.
   [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter=true)]
   public void GetObjectData(SerializationInfo info, StreamingContext context){
      // Stores the m_head and m_tail references in the SerializationInfo info.
      info.AddValue("head", m_head, m_head.GetType());
      info.AddValue("tail", m_tail, m_tail.GetType());
   }
   
   // Constructor that is called automatically during deserialization.
   // Reconstructs the object from the information in SerializationInfo info
   [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter=true)]
   private LinkedList(SerializationInfo info, StreamingContext context)
   {      
      Node temp = new Node(0);
      // Retrieves the values of Type temp.GetType() from SerializationInfo info
      m_head = (Node)info.GetValue("head", temp.GetType());
      m_tail = (Node)info.GetValue("tail", temp.GetType());
   }
}
// </Snippet1>

// Class added so sample will compile
class Node {
    public Node(int i) {
    }
}

