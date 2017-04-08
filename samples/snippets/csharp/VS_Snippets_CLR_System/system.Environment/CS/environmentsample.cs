using System;
using System.Xml;
using System.IO;
using System.Collections;
using System.Reflection;

//<Snippet1>
public class EnvironmentSample {

	public static void Main() {
		
        	//<Snippet2>
		OuterMethod();
		//</Snippet2>
		
		//<Snippet6>
		
		Console.WriteLine("Initial WS:"+Environment.WorkingSet);	  
		int[] i1,i2,i3;
		i1 = new int[10000];
		Console.WriteLine("WS 1:"+Environment.WorkingSet);	  
		i2 = new int[10000];
		Console.WriteLine("WS 2:"+Environment.WorkingSet);	  
		i3 = new int[10000];
		Console.WriteLine("WS 3:"+Environment.WorkingSet);	  
			
		//</Snippet6>											 			
		
	}   
	
	//<Snippet3>		
	static void OuterMethod() {
		InnerMethod();		
	}
	
	static void InnerMethod() {
		Console.WriteLine("StackTrace after calling Main()->OuterMethod()->InnerMethod():" + Environment.StackTrace);		
	}
	//</Snippet3>		
	
	
}
//</Snippet1>
