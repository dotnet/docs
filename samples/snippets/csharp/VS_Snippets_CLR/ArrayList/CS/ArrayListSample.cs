//<snippet7>
using System;
using System.Text;
using System.Collections;

public class SamplesArrayList  {

	public static void Main()  {
		//<snippet1> 
		// Creates and initializes a new ArrayList.
		ArrayList myAL = new ArrayList();
		myAL.Add("Eric");
		myAL.Add("Mark");
		myAL.Add("Lance");
		myAL.Add("Rob");
		myAL.Add("Kris");
		myAL.Add("Brad");
		myAL.Add("Kit");
		myAL.Add("Bradley");
		myAL.Add("Keith");
		myAL.Add("Susan");
	
		// Displays the properties and values of	the	ArrayList.
		Console.WriteLine( "Count: {0}", myAL.Count );
		//</snippet1>
		
		PrintValues ("Unsorted", myAL );
		//<snippet3> 
		myAL.Sort();
		PrintValues("Sorted", myAL );
		//</snippet3>
		//<snippet4> 
		myAL.Sort(new ReverseStringComparer() );
		PrintValues ("Reverse" , myAL );
		//</snippet4>


		//<snippet5> 
		string [] names = (string[]) myAL.ToArray (typeof(string));
		//</snippet5>


	}
	//<snippet2> 
	public static void PrintValues(string title, IEnumerable	myList )  {
		Console.Write ("{0,10}: ", title);
		StringBuilder sb = new StringBuilder();
		foreach (string s in myList) {
			sb.AppendFormat( "{0}, ", s);
		}
		sb.Remove (sb.Length-2,2);
		Console.WriteLine(sb);
	}
	//</snippet2>
}
//<snippet6> 
public class ReverseStringComparer : IComparer {
   public int Compare (object x, object y) {
	   string s1 = x as string;
	   string s2 = y as string;	  
	   //negate the return value to get the reverse order
	   return - String.Compare (s1,s2);

   }
}
//</snippet6>

//</snippet7>

