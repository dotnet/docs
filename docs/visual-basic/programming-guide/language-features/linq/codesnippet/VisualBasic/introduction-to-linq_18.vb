        ' Returns a list of cities with no duplicate entries.
        Dim cities = From item In customers
                     Select item.City
                     Distinct