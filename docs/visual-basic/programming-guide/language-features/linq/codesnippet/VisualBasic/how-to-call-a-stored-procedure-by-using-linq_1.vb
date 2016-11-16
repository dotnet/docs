    Dim db As New northwindDataContext

    ' Display the results of the Sales_by_Year stored procedure.
    DataGridView1.DataSource = 
        db.Sales_by_Year(#1/1/1996#, #1/1/2007#).ToList()