            var categoryQuery =
                from cat in categories
                join prod in products on cat equals prod.Category
                select new { Category = cat, Name = prod.Name };