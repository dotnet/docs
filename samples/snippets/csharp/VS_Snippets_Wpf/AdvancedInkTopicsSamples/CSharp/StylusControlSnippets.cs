using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Input.StylusPlugIns;

namespace StylusControlSnippets
{
    //<Snippet14>
    class InkControl : Label
    {
    //</Snippet14>
    
        DynamicRenderer dr;
        
        InkPresenter ip;

        //<Snippet17>
        public InkControl()
        {
        //</Snippet17>
            
            // Add an InkPresenter for drawing.
            ip = new InkPresenter();
            this.Content = ip;

        //<Snippet18>
            // Add a dynamic renderer that 
            // draws ink as it "flows" from the stylus.
            dr = new DynamicRenderer();
            ip.AttachVisuals(dr.RootVisual, dr.DrawingAttributes);
            this.StylusPlugIns.Add(dr);

        }
        //</Snippet18>
    //<Snippet15>
    }
    //</Snippet15>
}

namespace snippets2
{
    class InkControl : Label
    {
        //<Snippet16>
        InkPresenter ip;

        public InkControl()
        {
            // Add an InkPresenter for drawing.
            ip = new InkPresenter();
            this.Content = ip;
        }
        //</Snippet16>
    }
 
}