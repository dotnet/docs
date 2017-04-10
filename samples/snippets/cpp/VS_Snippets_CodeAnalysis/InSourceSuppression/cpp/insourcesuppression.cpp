#include <CodeAnalysis/SourceAnnotations.h>

//<Snippet1>
using namespace System;

CA_SUPPRESS_MESSAGE("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId="args")
int main(array<System::String ^> ^args)
{
    return 0;
}

namespace InSourceSuppression
{
public ref class Class1
{
public:
       CA_SUPPRESS_MESSAGE("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId="System.Uri")
       static bool IsValidGuid(String^ uri)
       {
              try
              {
                     gcnew Uri(uri);
                     return true;
              }
              catch (ArgumentNullException^) {}
              catch (OverflowException^) {}
              catch (FormatException^) {}
              return false;
       }
};
}
//</Snippet1>
