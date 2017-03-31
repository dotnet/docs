// <Snippet6>
#using <UtilityLib.dll> as_friend

using namespace System;
using namespace Utilities::StringUtilities;

void main()
{
   String^ s = "The Sign of the Four";
   Console::WriteLine(StringLib::IsFirstLetterUpperCase(s));
}
// </Snippet6>