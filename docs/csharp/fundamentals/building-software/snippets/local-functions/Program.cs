// <NearbyHelper>
IReadOnlyList<ReadingWeek> plan =
    CreateReadingPlan("The Long Way Home", chapterCount: 10, chaptersPerWeek: 3);

foreach (ReadingWeek week in plan)
{
    Console.WriteLine(
        $"Week {week.Number}: {week.BookTitle}, chapters {week.FirstChapter}-{week.LastChapter}");
}

static IReadOnlyList<ReadingWeek> CreateReadingPlan(
    string bookTitle,
    int chapterCount,
    int chaptersPerWeek)
{
    var plan = new List<ReadingWeek>();
    AddWeek(firstChapter: 1);
    return plan;

    void AddWeek(int firstChapter)
    {
        if (firstChapter > chapterCount)
        {
            return;
        }

        int lastChapter = Math.Min(
            firstChapter + chaptersPerWeek - 1,
            chapterCount);

        plan.Add(new ReadingWeek(
            plan.Count + 1,
            bookTitle,
            firstChapter,
            lastChapter));

        AddWeek(lastChapter + 1);
    }
}
// </NearbyHelper>

// <LocalAndLambda>
static IEnumerable<string> DescribeShortWeeks(
    IEnumerable<ReadingWeek> plan,
    int maximumChapters)
{
    return plan
        .Where(IsShortWeek)
        .Select(week => $"Week {week.Number}: {week.FirstChapter}-{week.LastChapter}");

    bool IsShortWeek(ReadingWeek week) =>
        week.LastChapter - week.FirstChapter + 1 <= maximumChapters;
}

Console.WriteLine("Short weeks:");
foreach (string description in DescribeShortWeeks(plan, maximumChapters: 2))
{
    Console.WriteLine(description);
}
// </LocalAndLambda>

record ReadingWeek(
    int Number,
    string BookTitle,
    int FirstChapter,
    int LastChapter);

