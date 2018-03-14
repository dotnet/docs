                void TestMethod(Northwind db)
                {
                    var query =
                        from o in db.Orders
                        join e in db.Employees
                            on o.EmployeeID equals (int?)e.EmployeeID
                        select new { o.OrderID, e.FirstName };
                }