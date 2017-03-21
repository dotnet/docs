public ref class MyClass
{
public:

   [XmlArrayAttribute]
   array<String^>^MyStringArray;

   [XmlArrayAttribute]
   array<Int32>^MyIntegerArray;
};
