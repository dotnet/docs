// The following code example creates instances of the UTF32Encoding class using different parameter values and then checks them for equality.

// <Snippet1>
using System;
using System.Text;

public class SamplesUTF32Encoding  {

   public static void Main()  {

      // Create different instances of UTF32Encoding.
      UTF32Encoding u32   = new UTF32Encoding();
      UTF32Encoding u32tt = new UTF32Encoding( true, true );
      UTF32Encoding u32tf = new UTF32Encoding( true, false );
      UTF32Encoding u32ft = new UTF32Encoding( false, true );
      UTF32Encoding u32ff = new UTF32Encoding( false, false );

      // Compare these instances with instances created using the ctor with three parameters.
      CompareEncodings( u32,   "u32  " );
      CompareEncodings( u32tt, "u32tt" );
      CompareEncodings( u32tf, "u32tf" );
      CompareEncodings( u32ft, "u32ft" );
      CompareEncodings( u32ff, "u32ff" );

   }


   public static void CompareEncodings( UTF32Encoding a, String name )  {

      // Create different instances of UTF32Encoding using the ctor with three parameters.
      UTF32Encoding u32ttt = new UTF32Encoding( true, true, true );
      UTF32Encoding u32ttf = new UTF32Encoding( true, true, false );
      UTF32Encoding u32tft = new UTF32Encoding( true, false, true );
      UTF32Encoding u32tff = new UTF32Encoding( true, false, false );
      UTF32Encoding u32ftt = new UTF32Encoding( false, true, true );
      UTF32Encoding u32ftf = new UTF32Encoding( false, true, false );
      UTF32Encoding u32fft = new UTF32Encoding( false, false, true );
      UTF32Encoding u32fff = new UTF32Encoding( false, false, false );

      // Compare the specified instance with each of the instances that were just created.
      Console.WriteLine( "{0} and u32ttt : {1}", name, a.Equals( u32ttt ) );
      Console.WriteLine( "{0} and u32ttf : {1}", name, a.Equals( u32ttf ) );
      Console.WriteLine( "{0} and u32tft : {1}", name, a.Equals( u32tft ) );
      Console.WriteLine( "{0} and u32tff : {1}", name, a.Equals( u32tff ) );
      Console.WriteLine( "{0} and u32ftt : {1}", name, a.Equals( u32ftt ) );
      Console.WriteLine( "{0} and u32ftf : {1}", name, a.Equals( u32ftf ) );
      Console.WriteLine( "{0} and u32fft : {1}", name, a.Equals( u32fft ) );
      Console.WriteLine( "{0} and u32fff : {1}", name, a.Equals( u32fff ) );

   }

}


/* 
This code produces the following output.

u32   vs u32ttt : False
u32   vs u32ttf : False
u32   vs u32tft : False
u32   vs u32tff : False
u32   vs u32ftt : False
u32   vs u32ftf : False
u32   vs u32fft : False
u32   vs u32fff : True
u32tt vs u32ttt : False
u32tt vs u32ttf : True
u32tt vs u32tft : False
u32tt vs u32tff : False
u32tt vs u32ftt : False
u32tt vs u32ftf : False
u32tt vs u32fft : False
u32tt vs u32fff : False
u32tf vs u32ttt : False
u32tf vs u32ttf : False
u32tf vs u32tft : False
u32tf vs u32tff : True
u32tf vs u32ftt : False
u32tf vs u32ftf : False
u32tf vs u32fft : False
u32tf vs u32fff : False
u32ft vs u32ttt : False
u32ft vs u32ttf : False
u32ft vs u32tft : False
u32ft vs u32tff : False
u32ft vs u32ftt : False
u32ft vs u32ftf : True
u32ft vs u32fft : False
u32ft vs u32fff : False
u32ff vs u32ttt : False
u32ff vs u32ttf : False
u32ff vs u32tft : False
u32ff vs u32tff : False
u32ff vs u32ftt : False
u32ff vs u32ftf : False
u32ff vs u32fft : False
u32ff vs u32fff : True

*/

// </Snippet1>

