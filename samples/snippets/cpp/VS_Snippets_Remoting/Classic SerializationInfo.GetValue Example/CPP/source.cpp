using namespace System;
using namespace System::Runtime::Serialization;

// Class added so sample will compile
ref class Node
{
public:
   Node( int /*i*/ ){}
};

// <Snippet1>
// A serializable LinkedList example.  For the full LinkedList implementation
// see the Serialization sample.
[Serializable]
ref class LinkedList: public ISerializable
{
private:
   Node^ m_head;
   Node^ m_tail;

   // Serializes the object.
public:
   virtual void GetObjectData( SerializationInfo^ info, StreamingContext /*context*/ )
   {
      // Stores the m_head and m_tail references in the SerializationInfo info.
      info->AddValue( "head", m_head, m_head->GetType() );
      info->AddValue( "tail", m_tail, m_tail->GetType() );
   }

   // Constructor that is called automatically during deserialization.
private:
   // Reconstructs the object from the information in SerializationInfo info
   LinkedList( SerializationInfo^ info, StreamingContext /*context*/ )
   {
      Node^ temp = gcnew Node( 0 );
      // Retrieves the values of Type temp.GetType() from SerializationInfo info
      m_head = dynamic_cast<Node^>(info->GetValue( "head", temp->GetType() ));
      m_tail = dynamic_cast<Node^>(info->GetValue( "tail", temp->GetType() ));
   }
};
// </Snippet1>
