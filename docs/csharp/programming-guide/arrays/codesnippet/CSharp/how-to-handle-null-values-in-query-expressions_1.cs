                    var query1 =
                        from c in categories
                        where c != null
                        join p in products on c.ID equals
                            (p == null ? null : p.CategoryID)
                        select new { Category = c.Name, Name = p.Name };