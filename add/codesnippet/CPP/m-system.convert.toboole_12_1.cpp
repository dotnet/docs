      array<Object^>^ objects = gcnew array<Object^> { 16.33, -24, 0, "12", "12.7", String::Empty, 
                                                      "1String", "True", "false", nullptr, 
                                                      gcnew System::Collections::ArrayList };
      
      for each (Object^ obj in objects)
      {
         Console::Write("{0,-40}  -->  ", 
                       obj == nullptr ? "null" :
                       String::Format("{0} ({1})", obj, obj->GetType()->Name));
         try {
            Console::WriteLine("{0}", Convert::ToBoolean((Object^) obj));
         }   
         catch (FormatException^) {
            Console::WriteLine("Bad Format");
         }   
         catch (InvalidCastException^) {
            Console::WriteLine("No Conversion");
         }   
      }     
      // The example displays the following output:
      //       16.33 (Double)                            -->  True
      //       -24 (Int32)                               -->  True
      //       0 (Int32)                                 -->  False
      //       12 (String)                               -->  Bad Format
      //       12.7 (String)                             -->  Bad Format
      //        (String)                                 -->  Bad Format
      //       1String (String)                          -->  Bad Format
      //       True (String)                             -->  True
      //       false (String)                            -->  False
      //       null                                      -->  False
      //       System.Collections.ArrayList (ArrayList)  -->  No Conversion