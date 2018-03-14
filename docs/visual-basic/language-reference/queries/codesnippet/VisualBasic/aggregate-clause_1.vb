        Dim customerList1 = Aggregate order In orders
                            Into AllOrdersOver100 = All(order.Total >= 100)