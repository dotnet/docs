
// System.Runtime.InteropServices.TypeLibTypeAttribute
// System.Runtime.InteropServices.TypeLibTypeFlags
// <Snippet4>
using System;
using System.Runtime.InteropServices;

namespace B
{
	class ClassB	
	{
		public static bool IsHiddenInterface( Type InterfaceType )
		{
			object[] InterfaceAttributes = InterfaceType.GetCustomAttributes( typeof( TypeLibTypeAttribute ), false );
			if( InterfaceAttributes.Length > 0 )
			{
				TypeLibTypeAttribute tlt = ( TypeLibTypeAttribute ) InterfaceAttributes[0];
				TypeLibTypeFlags  flags = tlt.Value;
				return ( flags & TypeLibTypeFlags.FHidden ) != 0; 
			}
			return false;
		}
	}
}
// </Snippet4>