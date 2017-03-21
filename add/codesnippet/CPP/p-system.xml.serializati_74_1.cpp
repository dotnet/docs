public ref class MyClass
{
public:

   [XmlArray(IsNullable=true)]
   array<String^>^IsNullableIsTrueArray;

   [XmlArray(IsNullable=false)]
   array<String^>^IsNullableIsFalseArray;
};
