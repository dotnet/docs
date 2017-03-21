   // MyMath is a proxy class.
   test::MyMath^ objMyMath = gcnew test::MyMath;
   
   // Get the default user agent.
   Console::WriteLine( "Default user agent is: {0}", objMyMath->UserAgent );
   objMyMath->UserAgent = "My Agent";
   Console::WriteLine( "Modified user agent is: {0}", objMyMath->UserAgent );