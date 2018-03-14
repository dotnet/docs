using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

public class Form1: Form
{
    public enum Option {First, Second};

    protected double result;
    public void Method( Option option )
    {
        try{
            // try something here
        }
        // <Snippet1>
        catch (Exception) {
            Trace.Fail("Unknown Option " + option + ", using the default.");
        }
        // </Snippet1>
        // <Snippet2>
        switch (option) {
            case Option.First:
               result = 1.0;
               break;
         
            // Insert additional cases.
            default:
               Trace.Fail("Unknown Option " + option);
               result = 1.0;
               break;
        }
        // </Snippet2>
    }
}
