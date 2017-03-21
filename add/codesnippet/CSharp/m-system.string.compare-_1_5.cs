using System;
using System.Text;
using System.Collections;

public class SamplesArrayList  {

	public static void Main()  {
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
		
		PrintValues ("Unsorted", myAL );
		myAL.Sort();
		PrintValues("Sorted", myAL );
		myAL.Sort(new ReverseStringComparer() );
		PrintValues ("Reverse" , myAL );


		string [] names = (string[]) myAL.ToArray (typeof(string));


	}
	public static void PrintValues(string title, IEnumerable	myList )  {
		Console.Write ("{0,10}: ", title);
		StringBuilder sb = new StringBuilder();
		foreach (string s in myList) {
			sb.AppendFormat( "{0}, ", s);
		}
		sb.Remove (sb.Length-2,2);
		Console.WriteLine(sb);
	}
}
public class ReverseStringComparer : IComparer {
   public int Compare (object x, object y) {
	   string s1 = x as string;
	   string s2 = y as string;	  
	   //negate the return value to get the reverse order
	   return - String.Compare (s1,s2);

   }
}
