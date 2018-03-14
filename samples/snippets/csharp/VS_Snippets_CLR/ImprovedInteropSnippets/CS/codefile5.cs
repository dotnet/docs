// System.Runtime.InteropServices.TypeLibFuncAttribute
// System.Runtime.InteropServices.TypeLibFuncFlags
// <Snippet5>

using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace C
{
	class ClassC	
	{
		public static bool IsHiddenMethod( MethodInfo mi )
		{
			object[] MethodAttributes = mi.GetCustomAttributes( typeof( TypeLibFuncAttribute ), true);
		
			if( MethodAttributes.Length > 0 )
			{
				TypeLibFuncAttribute tlf = ( TypeLibFuncAttribute )MethodAttributes[0];
				TypeLibFuncFlags  flags = tlf.Value;
				return ( flags & TypeLibFuncFlags.FHidden ) != 0; 
			}
			return false;
		}
	}
}
// </Snippet5>
