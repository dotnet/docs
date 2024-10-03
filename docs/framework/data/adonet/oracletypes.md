---
description: "Learn more about the structures you can use to work with Oracle data types, including OracleNumber and OracleString."
title: "OracleTypes"
ms.date: "03/30/2017"
---
# OracleTypes

The .NET Framework Data Provider for Oracle includes several structures you can use to work with Oracle data types. These include <xref:System.Data.OracleClient.OracleNumber> and <xref:System.Data.OracleClient.OracleString>.

> [!NOTE]
> For a complete list of these structures, see <xref:System.Data.OracleClient>.

## Create an Oracle table

 This example creates an Oracle table and loads it with data. You must run this example before running the next example.

```csharp
public void Setup(string connectionString)
   {
   OracleConnection conn = new OracleConnection(connectionString);
   try
      {
      conn.Open();
      OracleCommand cmd = conn.CreateCommand();
      cmd.CommandText ="CREATE TABLE OracleTypesTable " +
        "(MyVarchar2 varchar2(3000),MyNumber number(28,4) " +
        "PRIMARY KEY ,MyDate date, MyRaw raw(255))";
      cmd.ExecuteNonQuery();
      cmd.CommandText ="INSERT INTO OracleTypesTable VALUES " +
        "( 'test', 2, to_date('2000-01-11 12:54:01','yyyy-mm-dd " +
        "hh24:mi:ss'), '0001020304' )";
      cmd.ExecuteNonQuery();
      }
   catch(Exception)
   {
   }
   finally
   {
      conn.Close();
   }
}
```

## Retrieve data from the Oracle table

 This example uses an **OracleDataReader** to access the data, and uses several **OracleType** structures to display the data.

```csharp
public void ReadOracleTypesExample(string connectionString)
   {
   OracleConnection myConnection =
      new OracleConnection(connectionString);
   myConnection.Open();
   OracleCommand myCommand = myConnection.CreateCommand();

   try
      {
      myCommand.CommandText = "SELECT * from OracleTypesTable";
      OracleDataReader oracledatareader1 = myCommand.ExecuteReader();
      oracledatareader1.Read();

      //Using the oracle specific getters for each type is faster than
      //using GetOracleValue.

      //First column, MyVarchar2, is a VARCHAR2 data type in Oracle
      //Server and maps to OracleString.
      OracleString oraclestring1 =
        oracledatareader1.GetOracleString(0);
      Console.WriteLine("OracleString " + oraclestring1.ToString());

      //Second column, MyNumber, is a NUMBER data type in Oracle Server
      //and maps to OracleNumber.
      OracleNumber oraclenumber1 =
        oracledatareader1.GetOracleNumber(1);
      Console.WriteLine("OracleNumber " + oraclenumber1.ToString());

      //Third column, MyDate, is a DATA data type in Oracle Server
      //and maps to OracleDateTime.
      OracleDateTime oracledatetime1 =
        oracledatareader1.GetOracleDateTime(2);
      Console.WriteLine("OracleDateTime " + oracledatetime1.ToString());

      //Fourth column, MyRaw, is a RAW data type in Oracle Server and
      //maps to OracleBinary.
      OracleBinary oraclebinary1 =
        oracledatareader1.GetOracleBinary(3);
      //Calling value on a null OracleBinary throws
      //OracleNullValueException; therefore, check for a null value.
      if (oraclebinary1.IsNull==false)
      {
         foreach(byte b in oraclebinary1.Value)
         {
            Console.WriteLine("byte " + b.ToString());
         }
      }
      oracledatareader1.Close();
   }
   catch(Exception e)
   {
       Console.WriteLine(e.ToString());
   }
   finally
   {
       myConnection.Close();
   }
}
```

## See also

- [Oracle and ADO.NET](oracle-and-adonet.md)
- [ADO.NET Overview](ado-net-overview.md)
