// <Snippet1>
using System;

public class Temperature
{ 
	internal ushort n_value;
   internal string s_value;
   
	// Parses a string in the form [ws][sign]digits['F|'C][ws]
	public static Temperature Parse(string s)
	{
		Temperature temp = new Temperature();
      
      if (s == null) 
         throw new ArgumentNullException("s");
         
      s = s.TrimEnd();
		temp.s_value = s;
      if (s.EndsWith("'F") | s.EndsWith("'C")) 
      {  
			temp.Value = UInt16.Parse(s.Remove(s.LastIndexOf("'"), 2) );
		}
      else 
      { 
         try {
			  temp.Value = UInt16.Parse(s);
			}
         catch (FormatException e) {
            throw new FormatException(String.Format("{0} is an invalid temperature.", s), e);
         }
         catch (OverflowException e) {
            throw new OverflowException(String.Format("{0} is out of range.", s), e);
         }
		}

		return temp;
	}

	public ushort Value
	{
		get { return n_value; } 
		set { this.n_value = value; } 
	}
}
// </Snippet1>

// <Snippet2>
public class Example
{
   public static void Main()
   {
      string[] values = { "32'F", "32'C", "16", "-0", "-12", "", null };
      foreach (string value in values)
      {
         try {
            Temperature tmp = Temperature.Parse(value);
            Console.WriteLine(tmp.Value);
         }
         catch (FormatException) {
            Console.WriteLine("'{0}': Invalid Format", value.Trim());
         }   
         catch (OverflowException) {
            Console.WriteLine("{0}: Overflow", value.Trim());
         }   
         catch (ArgumentNullException e) {
            Console.WriteLine("The {0} parameter is null.", e.ParamName);            
         }
      }   
   }
}
// The example displays the following output:
//       32
//       32
//       16
//       0
//       -12: Overflow
//       '': Invalid Format
//       The s parameter is null.
// </Snippet2>
