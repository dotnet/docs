        ' Create a variable, Name, and give it an initial value.
        Dim Name = "Hugo Garcia"

        ' Variable anonymousCust2 will have one property, Name, with 
        ' "Hugo Garcia" as its initial value.
        Dim anonymousCust2 = New With {Key Name}

        ' The next declaration uses a property from namedCust, defined
        ' in an earlier example. After the declaration, anonymousCust3 will
        ' have one property, Name, with "Terry Adams" as its value.
        Dim anonymousCust3 = New With {Key namedCust.Name}