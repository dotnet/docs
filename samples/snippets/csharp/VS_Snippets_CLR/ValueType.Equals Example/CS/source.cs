using System;

namespace Snippets
{
	//<snippet1>
	public struct Complex 
	{
		public double m_Re;
		public double m_Im;

		public override bool Equals( object ob ){
			if( ob is Complex ) {
				Complex c = (Complex) ob;
				return m_Re==c.m_Re && m_Im==c.m_Im;
			}
			else {
				return false;
			}
		}

		public override int GetHashCode(){
			return m_Re.GetHashCode() ^ m_Im.GetHashCode();
		}
	}
	//</snippet1>
}