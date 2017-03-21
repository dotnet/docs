   String^ string1 = "Today is " + DateTime::Now.ToString("D") + ".";
   Console::WriteLine(string1);

   String^ string2 = "This is one sentence. " + "This is a second. ";
   string2 += "This is a third sentence.";
   Console::WriteLine(string2);
   // The example displays output like the following: 
   //    Today is Tuesday, July 06, 2011. 
   //    This is one sentence. This is a second. This is a third sentence.