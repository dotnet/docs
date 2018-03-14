                    var productInfos =
                        from p in products
                        select new { p.ProductName, p.UnitPrice };