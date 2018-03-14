            IEnumerable<string> sortAscendingQuery =
                from vegetable in vegetables
                orderby vegetable ascending
                select vegetable;