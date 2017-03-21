[ClassInterface(ClassInterfaceType::AutoDispatch)]
[ProgId("InteropSample.MyClass")]
public ref class MyClass
{
public:
   MyClass(){}

};

int main()
{
   try
   {
      AttributeCollection^ attributes;
      attributes = TypeDescriptor::GetAttributes( MyClass::typeid );
      ProgIdAttribute^ progIdAttributeObj = dynamic_cast<ProgIdAttribute^>(attributes[ ProgIdAttribute::typeid ]);
      Console::WriteLine( "ProgIdAttribute's value is set to : {0}", progIdAttributeObj->Value );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception : {0}", e->Message );
   }
}