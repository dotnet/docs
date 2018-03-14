            IEnumerable<string> highScoresQuery2 =
                from score in scores
                where score > 80
                orderby score descending
                select String.Format("The score is {0}", score);