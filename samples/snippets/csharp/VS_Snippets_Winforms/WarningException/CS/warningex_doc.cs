using System;
using System.ComponentModel;

namespace WarningEx
{
    public class WarningEx_Doc {
	static void Main(string[] args) {
	    //<snippet1>
	WarningException myEx=new WarningException("This is a warning");		
	Console.WriteLine(myEx.Message);
	Console.WriteLine(myEx.ToString());
	    //</snippet1>
	}
    }
}

