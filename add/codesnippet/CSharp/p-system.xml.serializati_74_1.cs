public class MyClass
{
   [XmlArray (IsNullable = true)]
   public string [] IsNullableIsTrueArray;

   [XmlArray (IsNullable = false)]
   public string [] IsNullableIsFalseArray;
}
   