            var innerGroupJoinQuery =
                from category in categories
                join prod in products on category.ID equals prod.CategoryID into prodGroup
                select new { CategoryName = category.Name, Products = prodGroup };