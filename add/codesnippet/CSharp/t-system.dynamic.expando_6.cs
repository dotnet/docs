            dynamic employee = new ExpandoObject();
            employee.Name = "John Smith";
            ((IDictionary<String, Object>)employee).Remove("Name");