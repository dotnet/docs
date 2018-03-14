            int highScoreCount =
                (from score in scores
                 where score > 80
                 select score)
                 .Count();