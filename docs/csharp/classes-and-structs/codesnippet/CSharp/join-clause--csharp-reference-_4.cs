            var leftOuterJoinQuery =
                from category in categories
                join prod in products on category.ID equals prod.CategoryID into prodGroup
                from item in prodGroup.DefaultIfEmpty(new Product { Name = String.Empty, CategoryID = 0 })
                select new { CatName = category.Name, ProdName = item.Name };