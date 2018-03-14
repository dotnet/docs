            var innerGroupJoinQuery2 =
                from category in categories
                join prod in products on category.ID equals prod.CategoryID into prodGroup
                from prod2 in prodGroup
                where prod2.UnitPrice > 2.50M
                select prod2;