        ' Returns the company name for all customers for which
        ' the Country is equal to "Canada".
        Dim names = From cust In customers
                    Where cust.Country = "Canada"
                    Select cust.CompanyName