using System;
using System.Collections.Generic;

namespace NullableIntroduction
{
    public class SurveyResponse
    {
        // <SnippetRandom>
        private static readonly Random randomGenerator = new Random();
        public static SurveyResponse GetRandomId() => new SurveyResponse(randomGenerator.Next());
        // </SnippetRandom>

        public int Id { get; }

        // <SnippetSurveyStatus>
        public bool AnsweredSurvey => surveyResponses != null;
        public string Answer(int index) => surveyResponses?.GetValueOrDefault(index) ?? "No answer";
        // </SnippetSurveyStatus>

        public SurveyResponse(int id) => Id = id;

        // <SnippetAnswerSurvey>
        private Dictionary<int, string>? surveyResponses;
        public bool AnswerSurvey(IEnumerable<SurveyQuestion> questions)
        {
            if (ConsentToSurvey())
            {
                surveyResponses = new Dictionary<int, string>();
                int index = 0;
                foreach (var question in questions)
                {
                    var answer = GenerateAnswer(question);
                    if (answer != null)
                    {
                        surveyResponses.Add(index, answer);
                    }
                    index++;
                }
            }
            return surveyResponses != null;
        }

        private bool ConsentToSurvey() => randomGenerator.Next(0, 2) == 1;

        private string? GenerateAnswer(SurveyQuestion question)
        {
            switch (question.TypeOfQuestion)
            {
                case QuestionType.YesNo:
                    int n = randomGenerator.Next(-1, 2);
                    return (n == -1) ? default : (n == 0) ? "No" : "Yes";
                case QuestionType.Number:
                    n = randomGenerator.Next(-30, 101);
                    return (n < 0) ? default : n.ToString();
                case QuestionType.Text:
                default:
                    switch (randomGenerator.Next(0, 5))
                    {
                        case 0:
                            return default;
                        case 1:
                            return "Red";
                        case 2:
                            return "Green";
                        case 3:
                            return "Blue";
                    }
                    return "Red. No, Green. Wait.. Blue... AAARGGGGGHHH!";
            }
        }
        // </SnippetAnswerSurvey>
    }
}
