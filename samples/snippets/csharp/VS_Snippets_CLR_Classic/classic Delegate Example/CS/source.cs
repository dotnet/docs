// <Snippet1>
using System;
public class SamplesDelegate  {

   // Declares a delegate for a method that takes in an int and returns a String.
   public delegate String myMethodDelegate( int myInt );

   // Defines some methods to which the delegate can point.
   public class mySampleClass  {

      // Defines an instance method.
      public String myStringMethod ( int myInt )  {
         if ( myInt > 0 )
            return( "positive" );
         if ( myInt < 0 )
            return( "negative" );
         return ( "zero" );
      }

      // Defines a static method.
      public static String mySignMethod ( int myInt )  {
         if ( myInt > 0 )
            return( "+" );
         if ( myInt < 0 )
            return( "-" );
         return ( "" );
      }
   }

   public static void Main()  {

      // Creates one delegate for each method. For the instance method, an
      // instance (mySC) must be supplied. For the static method, use the
      // class name.
      mySampleClass mySC = new mySampleClass();
      myMethodDelegate myD1 = new myMethodDelegate( mySC.myStringMethod );
      myMethodDelegate myD2 = new myMethodDelegate( mySampleClass.mySignMethod );

      // Invokes the delegates.
      Console.WriteLine( "{0} is {1}; use the sign \"{2}\".", 5, myD1( 5 ), myD2( 5 ) );
      Console.WriteLine( "{0} is {1}; use the sign \"{2}\".", -3, myD1( -3 ), myD2( -3 ) );
      Console.WriteLine( "{0} is {1}; use the sign \"{2}\".", 0, myD1( 0 ), myD2( 0 ) );
   }

}


/*
This code produces the following output:
 
5 is positive; use the sign "+".
-3 is negative; use the sign "-".
0 is zero; use the sign "".
*/ 

// </Snippet1>
