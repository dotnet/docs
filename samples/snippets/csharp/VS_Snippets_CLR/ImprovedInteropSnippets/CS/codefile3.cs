// System.Assembly.GetCustomAttributes
// System.Runtime.InteropServices.ImportedFromTypeLibAttribute
// <Snippet3>
using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace A
{
	class ClassA
	{
		public static bool IsCOMAssembly( Assembly a )
		{
			object[] AsmAttributes = a.GetCustomAttributes( typeof( ImportedFromTypeLibAttribute ), true );
			if( AsmAttributes.Length > 0 )
			{
				ImportedFromTypeLibAttribute imptlb = ( ImportedFromTypeLibAttribute )AsmAttributes[0];
				string strImportedFrom  = imptlb.Value;
				    
				// Print out the the name of the DLL from which the assembly is imported.
				Console.WriteLine( "Assembly " + a.FullName + " is imported from " + strImportedFrom );
			
				return true;
			}  
			// This is not a COM assembly.
			Console.WriteLine( "Assembly " + a.FullName + " is not imported from COM" );
			return false;
		}
	}
}
// </Snippet3>