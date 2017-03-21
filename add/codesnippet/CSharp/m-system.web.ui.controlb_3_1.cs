     // Override the AppendLiteralString method so that literal
     // text between rows of controls are ignored.  
     public override void AppendLiteralString(string s) 
     {
       // Ignores literals between rows.
     }