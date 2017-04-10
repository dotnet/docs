// <Snippet5>
using namespace System;

int CountLetters(String^ value);
int CountWhitespace(String^ value);

void main()
{
   String^ value = "This is a test string.";
   
   
   Console::WriteLine("The string '{0}' consists of:" +
                      "{4}{1} characters{4}{2} letters{4}" +
                      "{3} whitespace characters", 
                      value, value->Length, CountLetters(value), 
                      CountWhitespace(value), Environment::NewLine);
}

int CountLetters(String^ value)
{
   int nLetters = 0;
   for each (Char ch in value) {
      if (Char::IsLetter(ch))
         nLetters++;
   }
   return nLetters;
}

int CountWhitespace(String^ value)
{
   int nWhitespace = 0;
   for each (Char ch in value) {
      if (Char::IsWhiteSpace(ch))
         nWhitespace++;
   }
   return nWhitespace;
}
// The example displays the following output:
//    The string 'This is a test string.' consists of:
//    22 characters
//    17 letters
//    4 whitespace characters
// </Snippet5>
