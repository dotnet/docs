        // Override the BeginRender method to write a
        // message and call the WriteBreak method
        // before a control is rendered.
        override public void BeginRender()
        {
           this.Write("A control is about to render.");
           this.WriteBreak();
        }
        
        // Override the EndRender method to
        // write a string immediately after 
        // a control has rendered. 
        override public void EndRender()
        {
           this.Write("A control just rendered.");
        }  