// <Snippet1>
using namespace System;
using namespace System::Globalization;

public ref class Example
{
public:
   static void Main()
   {
      String^ string1 = "brother";
      String^ string2 = "Brother";
      String^ relation;
      int result;

      // Cultural (linguistic) comparison.
      result = String::Compare(string1, string2, gcnew CultureInfo("en-US"),
                              CompareOptions::None);
      if (result > 0)
         relation = "comes after";
      else if (result == 0)
         relation = "is the same as";
      else
         relation = "comes before";

      Console::WriteLine("'{0}' {1} '{2}'.",
                        string1, relation, string2);

      // Cultural (linguistic) case-insensitive comparison.
      result = String::Compare(string1, string2, gcnew CultureInfo("en-US"),
                              CompareOptions::IgnoreCase);
      if (result > 0)
         relation = "comes after";
      else if (result == 0)
         relation = "is the same as";
      else
         relation = "comes before";

      Console::WriteLine("'{0}' {1} '{2}'.",
                        string1, relation, string2);

       // Culture-insensitive ordinal comparison.
      result = String::CompareOrdinal(string1, string2);
      if (result > 0)
         relation = "comes after";
      else if (result == 0)
         relation = "is the same as";
      else
         relation = "comes before";

      Console::WriteLine("'{0}' {1} '{2}'.",
                        string1, relation, string2);
   }
};

int main()
{
    Example::Main();
}


// The example produces the following output:
//    'brother' comes before 'Brother'.
//    'brother' is the same as 'Brother'.
//    'brother' comes after 'Brother'.
// </Snippet1>
