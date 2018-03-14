// Char.IsSeparator.cpp : main project file.

// <Snippet1>
using namespace System;

int main()
{
   for (int ctr = Convert::ToInt32(Char::MinValue); ctr <= Convert::ToInt32(Char::MaxValue); ctr++)
   {
      wchar_t ch = ctr;
      if (Char::IsSeparator(ch))
         Console::WriteLine("\u{0:X4} ({1})", (int) ch, Char::GetUnicodeCategory(ch).ToString());
   }
}
// The example displays the following output:
//       0020 (SpaceSeparator)
//       u00A0 (SpaceSeparator)
//       u1680 (SpaceSeparator)
//       u180E (SpaceSeparator)
//       u2000 (SpaceSeparator)
//       u2001 (SpaceSeparator)
//       u2002 (SpaceSeparator)
//       u2003 (SpaceSeparator)
//       u2004 (SpaceSeparator)
//       u2005 (SpaceSeparator)
//       u2006 (SpaceSeparator)
//       u2007 (SpaceSeparator)
//       u2008 (SpaceSeparator)
//       u2009 (SpaceSeparator)
//       u200A (SpaceSeparator)
//       u2028 (LineSeparator)
//       u2029 (ParagraphSeparator)
//       u202F (SpaceSeparator)
//       u205F (SpaceSeparator)
//       u3000 (SpaceSeparator)
// </Snippet1>
