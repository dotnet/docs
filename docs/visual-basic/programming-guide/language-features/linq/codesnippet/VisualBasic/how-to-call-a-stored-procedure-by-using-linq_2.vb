    ' Display the results of the Ten_Most_Expensive_Products
    ' stored procedure.

    DataGridView1.DataSource = 
        db.Ten_Most_Expensive_Products.ToList()