    ' Multiple From clauses in a query.
    Dim result = From var1 In collection1, var2 In collection2

    ' Equivalent syntax with a single From clause.
    Dim result2 = From var1 In collection1
                  From var2 In collection2