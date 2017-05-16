
//<Snippet1>
using namespace System;
 
namespace Samples 
{
    // Violates this rule    
	[FlagsAttribute]    
	public enum class Color    
	{        
		None   = 0,        
		Red    = 1,        
		Orange = 3,        
		Yellow = 4    
	};
}
//</Snippet1>