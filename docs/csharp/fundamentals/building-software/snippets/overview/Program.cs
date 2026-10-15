// <CombineTechniques>
var tasks = new[]
{
    new ProjectTask("Confirm venue", Priority: 3, IsBlocked: false),
    new ProjectTask("Print badges", Priority: 2, IsBlocked: true),
    new ProjectTask("Test microphones", Priority: 2, IsBlocked: false),
};

ShowDashboard("Community meetup", tasks, minimumPriority: 2);

static void ShowDashboard(
    string projectName,
    IEnumerable<ProjectTask> tasks,
    int minimumPriority)
{
    var urgentTasks = tasks.Where(
        task => task.Priority >= minimumPriority);

    foreach (ProjectTask task in ReadyTasks(urgentTasks))
    {
        Console.WriteLine(FormatTask(task));
    }

    string FormatTask(ProjectTask task) =>
        $"{projectName}: {task.Title}";
}

static IEnumerable<ProjectTask> ReadyTasks(
    IEnumerable<ProjectTask> tasks)
{
    foreach (ProjectTask task in tasks)
    {
        if (!task.IsBlocked)
        {
            yield return task;
        }
    }
}

record ProjectTask(string Title, int Priority, bool IsBlocked);
// </CombineTechniques>

