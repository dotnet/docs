//<Snippet1>
using System;
using System.Management;

public class Sample 
{    
    public static void Main() 
    {

        SelectQuery query = new SelectQuery("SELECT * " +
            "FROM Win32_LogicalDisk " +
            "WHERE FreeSpace < 4000000");
        // The query is parsed so that the className property
        // is Win32_LogicalDisk and the condition property
        // is FreeSpace < 4000000

    }
}
//</Snippet1>