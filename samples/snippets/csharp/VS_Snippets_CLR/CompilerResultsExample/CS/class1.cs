using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;

namespace CompilerResults
{
	class Class1
	{        
        Class1()
        {
        }

        //<Snippet1>
        // Displays information from a CompilerResults.
        public static void DisplayCompilerResults(System.CodeDom.Compiler.CompilerResults cr)
        {
            // If errors occurred during compilation, output the compiler output and errors.
            if( cr.Errors.Count > 0 )
            {
                for( int i=0; i<cr.Output.Count; i++ )                
                    Console.WriteLine( cr.Output[i] );
                for( int i=0; i<cr.Errors.Count; i++ )                
                    Console.WriteLine( i.ToString() + ": " + cr.Errors[i].ToString() );
                
            }
            else
            {
                // Display information about the compiler's exit code and the generated assembly.
                Console.WriteLine( "Compiler returned with result code: " + cr.NativeCompilerReturnValue.ToString() );
                Console.WriteLine( "Generated assembly name: " + cr.CompiledAssembly.FullName );
                if( cr.PathToAssembly == null )
                    Console.WriteLine( "The assembly has been generated in memory." );
                else
                    Console.WriteLine( "Path to assembly: " + cr.PathToAssembly );
                
                // Display temporary files information.
                if( !cr.TempFiles.KeepFiles )                
                    Console.WriteLine( "Temporary build files were deleted." );
                else
                {
                    Console.WriteLine( "Temporary build files were not deleted." );
                    // Display a list of the temporary build files
                    IEnumerator enu = cr.TempFiles.GetEnumerator();                                        
                    for( int i=0; enu.MoveNext(); i++ )                                          
                        Console.WriteLine( "TempFile " + i.ToString() + ": " + (string)enu.Current );                  
                }
            }
        }
        //</Snippet1>
	}
}
