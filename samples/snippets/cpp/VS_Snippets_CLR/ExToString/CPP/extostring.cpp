
//<Snippet1>
using namespace System;

public ref class TestClass{};

int main()
{
   TestClass^ test = gcnew TestClass;
   array<Object^>^ objectsToCompare = { test, test->ToString(), 123,
                                        (123).ToString(), "some text",
                                        "Some Text" };
   String^ s = "some text";
   for each (Object^ objectToCompare in objectsToCompare) {
      try {
         Int32 i = s->CompareTo(objectToCompare);
         Console::WriteLine("Comparing '{0}' with '{1}': {2}",
                            s, objectToCompare, i);
      }
      catch (ArgumentException^ e) {
         Console::WriteLine("Bad argument: {0} (type {1})",
                            objectToCompare,
                            objectToCompare->GetType()->Name);
      }
   }
}
// The example displays the following output:
//    Bad argument: TestClass (type TestClass)
//    Comparing 'some text' with 'TestClass': -1
//    Bad argument: 123 (type Int32)
//    Comparing 'some text' with '123': 1
//    Comparing 'some text' with 'some text': 0
//    Comparing 'some text' with 'Some Text': -1
//</Snippet1>
