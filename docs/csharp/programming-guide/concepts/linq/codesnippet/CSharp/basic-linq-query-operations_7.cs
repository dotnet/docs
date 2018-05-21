                // custQuery is an IEnumerable<IGrouping<string, Customer>>
                var custQuery =
                    from cust in customers
                    group cust by cust.City into custGroup
                    where custGroup.Count() > 2
                    orderby custGroup.Key
                    select custGroup;