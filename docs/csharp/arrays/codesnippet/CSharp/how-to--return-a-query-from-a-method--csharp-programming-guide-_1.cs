            class MQ
            {
                // QueryMethhod1 returns a query as its value.
                IEnumerable<string> QueryMethod1(ref int[] ints)
                {
                    var intsToStrings = from i in ints
                                        where i > 4
                                        select i.ToString();
                    return intsToStrings;
                }

                // QueryMethod2 returns a query as the value of parameter returnQ.
                void QueryMethod2(ref int[] ints, out IEnumerable<string> returnQ)
                {
                    var intsToStrings = from i in ints
                                        where i < 4
                                        select i.ToString();
                    returnQ = intsToStrings;
                }

                static void Main()
                {
                    MQ app = new MQ();

                    int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                    // QueryMethod1 returns a query as the value of the method.
                    var myQuery1 = app.QueryMethod1(ref nums);

                    // Query myQuery1 is executed in the following foreach loop.
                    Console.WriteLine("Results of executing myQuery1:");
                    // Rest the mouse pointer over myQuery1 to see its type.
                    foreach (string s in myQuery1)
                    {
                        Console.WriteLine(s);
                    }

                    // You also can execute the query returned from QueryMethod1 
                    // directly, without using myQuery1.
                    Console.WriteLine("\nResults of executing myQuery1 directly:");
                    // Rest the mouse pointer over the call to QueryMethod1 to see its
                    // return type.
                    foreach (string s in app.QueryMethod1(ref nums))
                    {
                        Console.WriteLine(s);
                    }


                    IEnumerable<string> myQuery2;
                    // QueryMethod2 returns a query as the value of its out parameter.
                    app.QueryMethod2(ref nums, out myQuery2);

                    // Execute the returned query.
                    Console.WriteLine("\nResults of executing myQuery2:");
                    foreach (string s in myQuery2)
                    {
                        Console.WriteLine(s);
                    }


                    // You can modify a query by using query composition. A saved query
                    // is nested inside a new query definition that revises the results
                    // of the first query.
                    myQuery1 = from item in myQuery1
                               orderby item descending
                               select item;

                    // Execute the modified query.
                    Console.WriteLine("\nResults of executing modified myQuery1:");
                    foreach (string s in myQuery1)
                    {
                        Console.WriteLine(s);
                    }

                    // Keep console window open in debug mode.
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                }
            } 