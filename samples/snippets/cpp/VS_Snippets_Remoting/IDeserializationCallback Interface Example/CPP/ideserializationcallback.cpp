
//<snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Collections;
using namespace System::Runtime::Serialization::Formatters::Binary;
using namespace System::Runtime::Serialization;

// This class is serializable and will have its OnDeserialization method
// called after each instance of this class is deserialized.

[Serializable]
ref class Circle: public IDeserializationCallback
{
private:
   Double m_radius;

public:

   // To reduce the size of the serialization stream, the field below is 
   // not serialized. This field is calculated when an object is constructed
   // or after an instance of this class is deserialized.

   [NonSerialized]
   Double m_area;
   Circle( Double radius )
   {
      m_radius = radius;
      m_area = Math::PI * radius * radius;
   }

   virtual void OnDeserialization( Object^ /*sender*/ )
   {
      // After being deserialized, initialize the m_area field 
      // using the deserialized m_radius value.
      m_area = Math::PI * m_radius * m_radius;
   }

   virtual String^ ToString() override
   {
      return String::Format( "radius= {0}, area= {1}", m_radius, m_area );
   }
};

void Serialize()
{
   Circle^ c = gcnew Circle( 10 );
   Console::WriteLine( "Object being serialized: {0}", c );

   // To serialize the Circle, you must first open a stream for 
   // writing. We will use a file stream here.
   FileStream^ fs = gcnew FileStream( "DataFile.dat",FileMode::Create );

   // Construct a BinaryFormatter and use it to serialize the data to the stream.
   BinaryFormatter^ formatter = gcnew BinaryFormatter;
   try
   {
      formatter->Serialize( fs, c );
   }
   catch ( SerializationException^ e ) 
   {
      Console::WriteLine( "Failed to serialize. Reason: {0}", e->Message );
      throw;
   }
   finally
   {
      fs->Close();
   }
}

void Deserialize()
{
   // Declare the Circle reference.
   Circle^ c = nullptr;

   // Open the file containing the data that we want to deserialize.
   FileStream^ fs = gcnew FileStream( "DataFile.dat",FileMode::Open );
   try
   {
      BinaryFormatter^ formatter = gcnew BinaryFormatter;

      // Deserialize the Circle from the file and 
      // assign the reference to our local variable.
      c = dynamic_cast<Circle^>(formatter->Deserialize( fs ));
   }
   catch ( SerializationException^ e ) 
   {
      Console::WriteLine( "Failed to deserialize. Reason: {0}", e->Message );
      throw;
   }
   finally
   {
      fs->Close();
   }

   // To prove that the Circle deserialized correctly, display its area.
   Console::WriteLine( "Object being deserialized: {0}", c );
}

[STAThread]
int main()
{
   Serialize();
   Deserialize();
}
//</snippet1>
