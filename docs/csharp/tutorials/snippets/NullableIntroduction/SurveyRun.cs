namespace NullableIntroduction;

public class SurveyRun
{
    private List<SurveyQuestion> surveyQuestions = new List<SurveyQuestion>();

    // <SnippetRunReport>
    public IEnumerable<SurveyResponse> AllParticipants => (respondents ?? Enumerable.Empty<SurveyResponse>());
    public ICollection<SurveyQuestion> Questions => surveyQuestions;
    public SurveyQuestion GetQuestion(int index) => surveyQuestions[index];
    // </SnippetRunReport>

    public void AddQuestion(QuestionType type, string question) =>
        AddQuestion(new SurveyQuestion(type, question));
    public void AddQuestion(SurveyQuestion surveyQuestion) => surveyQuestions.Add(surveyQuestion);

    // <SnippetPerformSurvey>
    private List<SurveyResponse>? respondents;
    public void PerformSurvey(int numberOfRespondents)
    {
        int respondentsConsenting = 0;
        respondents = new List<SurveyResponse>();
        while (respondentsConsenting < numberOfRespondents)
        {
            var respondent = SurveyResponse.GetRandomId();
            if (respondent.AnswerSurvey(surveyQuestions))
                respondentsConsenting++;
            respondents.Add(respondent);
        }
    }
    // </SnippetPerformSurvey>
}
