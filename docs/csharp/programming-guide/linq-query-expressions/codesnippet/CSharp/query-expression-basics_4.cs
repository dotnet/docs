            IEnumerable<int> highScoresQuery3 =
                from score in scores
                where score > 80
                select score;

            int scoreCount = highScoresQuery3.Count();