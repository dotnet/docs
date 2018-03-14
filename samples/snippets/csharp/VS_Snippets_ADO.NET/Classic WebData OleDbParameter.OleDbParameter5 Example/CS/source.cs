using System;
using System.Data;
using System.Data.OleDb;

public class Sample
{

  public static void Main()
  {
    CreateOleDbParameter();
  }

// <Snippet1>

 public static void CreateOleDbParameter() 
 {
    OleDbParameter myParameter = new OleDbParameter("Description", "Beverages");
 }
// </Snippet1>

}
