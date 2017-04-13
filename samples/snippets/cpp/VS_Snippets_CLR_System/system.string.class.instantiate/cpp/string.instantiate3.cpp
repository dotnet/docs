// String.Instantiate3.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

using namespace System;

void main()
{
   // <Snippet3>
   String^ string1 = "Today is " + DateTime::Now.ToString("D") + ".";
   Console::WriteLine(string1);

   String^ string2 = "This is one sentence. " + "This is a second. ";
   string2 += "This is a third sentence.";
   Console::WriteLine(string2);
   // The example displays output like the following: 
   //    Today is Tuesday, July 06, 2011. 
   //    This is one sentence. This is a second. This is a third sentence.
   // </Snippet3>
   Console::WriteLine();

   // <Snippet4>
   String^ sentence = "This sentence has five words.";
   // Extract the second word.
   int startPosition = sentence->IndexOf(" ") + 1;
   String^ word2 = sentence->Substring(startPosition, 
                                       sentence->IndexOf(" ", startPosition) - startPosition);
   Console::WriteLine("Second word: " + word2);
   // </Snippet4>
    Console::WriteLine();

   // <Snippet5>
   DateTime^ dateAndTime = gcnew DateTime(2011, 7, 6, 7, 32, 0);
   Double temperature = 68.3;
   String^ result = String::Format("At {0:t} on {0:D}, the temperature was {1:F1} degrees Fahrenheit.",
                                  dateAndTime, temperature);
   Console::WriteLine(result);
   // The example displays the following output: 
   //       At 7:32 AM on Wednesday, July 06, 2011, the temperature was 68.3 degrees Fahrenheit.      
   // </Snippet5>
   Console::ReadLine();
}

