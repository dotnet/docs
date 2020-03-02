using System;

namespace NullableIntroduction
{
    class Program
    {
        static void Main(string[] args)
        {
            // <SnippetAddQuestions>
            var surveyRun = new SurveyRun();
            surveyRun.AddQuestion(QuestionType.YesNo, "Has your code ever thrown a NullReferenceException?");
            surveyRun.AddQuestion(new SurveyQuestion(QuestionType.Number, "How many times (to the nearest 100) has that happened?"));
            surveyRun.AddQuestion(QuestionType.Text, "What is your favorite color?");
            // </SnippetAddQuestions>

            // <SnippetRunSurvey>
            surveyRun.PerformSurvey(50);
            // </SnippetRunSurvey>

            // <SnippetWriteAnswers>
            foreach (var participant in surveyRun.AllParticipants)
            {
                Console.WriteLine($"Participant: {participant.Id}:");
                if (participant.AnsweredSurvey)
                {
                    for (int i = 0; i < surveyRun.Questions.Count; i++)
                    {
                        var answer = participant.Answer(i);
                        Console.WriteLine($"\t{surveyRun.GetQuestion(i).QuestionText} : {answer}");
                    }
                }
                else
                {
                    Console.WriteLine("\tNo responses");
                }
            }
            // </SnippetWriteAnswers>
        }
    }
}
