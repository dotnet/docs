// System.Runtime.InteropServices.TypeLibVarAttribute
// System.Runtime.InteropServices.TypeLibVarFlags
// <Snippet1>

using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace D
{
	class ClassD
	{
		public static bool IsHiddenField( FieldInfo fi )
		{
			object[] FieldAttributes = fi.GetCustomAttributes( typeof( TypeLibVarAttribute ), true);
		
			if( FieldAttributes.Length > 0 )
			{
				TypeLibVarAttribute tlv = ( TypeLibVarAttribute )FieldAttributes[0];
				TypeLibVarFlags  flags = tlv.Value;
				return ( flags & TypeLibVarFlags.FHidden ) != 0; 
			}
			return false;
		}
	}
}
// </Snippet1>
