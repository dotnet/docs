using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCRandomAnswerGenerator
{
    public class AnswerGenerator
    {
        private static readonly string[] Answers = new string[]
            {
                "It is certain",
                "It is decidedly so",
                "Without a doubt",
                "Yes, definitely",
                "You may rely on it",
                "As I see it, yes",
                "Most likely",
                "Outlook good",
                "Yes",
                "Signs point to yes",
                "Reply hazy try again",
                "Ask again later",
                "Better not tell you now",
                "Cannot predict now",
                "Concentrate and ask again",
                "Don't count on it",
                "My reply is no",
                "My sources say no",
                "Outlook not so good",
                "Very doubtful"
            };

        public static string GenerateAnswer(string question)
        {
            var r = new Random(question.GetHashCode());
            var index = r.Next(Answers.Length - 1);
            return Answers[index];
        }
    }
}