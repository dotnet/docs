// Variables.
SqlMetaData column1Info;
SqlMetaData column2Info;
SqlDataRecord record;

// Create the column metadata.
column1Info = new SqlMetaData("Column1", SqlDbType.NVarChar, 12);
column2Info = new SqlMetaData("Column2", SqlDbType.Int);

// Create a new record with the column metadata.      
record = new SqlDataRecord(new SqlMetaData[] { column1Info, 
                                                  column2Info });