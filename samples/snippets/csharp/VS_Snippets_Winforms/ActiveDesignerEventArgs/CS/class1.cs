using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace ActiveDesignerEventArgsExample
{	
	class Class1
	{
		[STAThread]
		static void Main(string[] args)
		{            
		}

        //<Snippet1>
        public ActiveDesignerEventArgs CreateActiveDesignerEventArgs(IDesignerHost losingFocus, IDesignerHost gainingFocus)
        {
            ActiveDesignerEventArgs e = new ActiveDesignerEventArgs(losingFocus, gainingFocus);
	        return e;
        }
        //</Snippet1>
	}
}
