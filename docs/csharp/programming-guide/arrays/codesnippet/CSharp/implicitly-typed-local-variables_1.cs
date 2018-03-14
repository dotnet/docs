                    // i is compiled as an int
                    var i = 5;

                    // s is compiled as a string
                    var s = "Hello";

                    // a is compiled as int[]
                    var a = new[] { 0, 1, 2 };

                    // expr is compiled as IEnumerable<Customer>
                    // or perhaps IQueryable<Customer>
                    var expr =
                        from c in customers
                        where c.City == "London"
                        select c;

                    // anon is compiled as an anonymous type
                    var anon = new { Name = "Terry", Age = 34 };

                    // list is compiled as List<int>                             
                    var list = new List<int>();