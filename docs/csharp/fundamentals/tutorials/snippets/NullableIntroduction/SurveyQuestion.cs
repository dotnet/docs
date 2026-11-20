namespace NullableIntroduction;

public enum QuestionType
{
    YesNo,
    Number,
    Text
}

public class SurveyQuestion(QuestionType typeOfQuestion, string text)
{
    public string QuestionText { get; } = text;
    public QuestionType TypeOfQuestion { get; } = typeOfQuestion;
}
