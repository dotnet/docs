            var innerJoinQuery =
                from category in categories
                join prod in products on category.ID equals prod.CategoryID
                select new { ProductName = prod.Name, Category = category.Name };