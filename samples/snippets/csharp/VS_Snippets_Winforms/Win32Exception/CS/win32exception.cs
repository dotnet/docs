using System;
using System.ComponentModel;
//using System.Diagnostics;

namespace Win32Exception_CS
{
    class Class1 {
	static void Main(string[] args)	{

 	//<snippet1>
	    try {
		System.Diagnostics.Process myProc = new System.Diagnostics.Process();
		myProc.StartInfo.FileName = "c:\nonexist.exe";  //Attempting to start a non-existing executable
		myProc.Start();    //Start the application and assign it to the process component.    
	    }
  	    catch(Win32Exception w) {
		Console.WriteLine(w.Message);
		Console.WriteLine(w.ErrorCode.ToString());
		Console.WriteLine(w.NativeErrorCode.ToString());
		Console.WriteLine(w.StackTrace);
		Console.WriteLine(w.Source);
		Exception e=w.GetBaseException();
		Console.WriteLine(e.Message);
 	    }
	//</snippet1>

	}
    }
}
