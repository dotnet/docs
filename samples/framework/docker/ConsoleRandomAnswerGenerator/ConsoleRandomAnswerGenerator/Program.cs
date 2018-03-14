using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRandomAnswerGenerator
{
    public class Program
    {
        static Random _r = new Random();
        public static void Main(string[] question)
        {
            RandomAnswers answers = new RandomAnswers();
            int rInt = _r.Next(0, answers.Count() - 1);
            string response;
            if (question.Length == 0)
            {
                response = "You must ask a question to be provided an answer.";
            }
            else
            {
                response = string.Format("The answer to your question: '{0}' is {1} on ({2})", question[0], answers[rInt], Environment.MachineName);
            }
            Console.WriteLine(response);
            Debug.WriteLine(response);
        }
    }
}
