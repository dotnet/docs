#!/usr/bin/env dotnet

// <Package>
#:package System.CommandLine@2.0.0
// </Package>

// <Usings>
using System.CommandLine;
using System.CommandLine.Parsing;
using System.Text.Json;
// </Usings>

// <EnumDefinition>
public enum Priority { Low, Medium, High }
// </EnumDefinition>

// <RecordDefinition>
public record TaskItem(int Id, string Description, Priority Priority, DateOnly? Due, bool IsComplete);
// </RecordDefinition>

// <JsonContext>
[System.Text.Json.Serialization.JsonSourceGenerationOptions(WriteIndented = true)]
[System.Text.Json.Serialization.JsonSerializable(typeof(List<TaskItem>))]
internal partial class TaskJsonContext : System.Text.Json.Serialization.JsonSerializerContext;
// </JsonContext>

// <Options>
var verboseOption = new Option<bool>("--verbose", "Show detailed output")
{
    Recursive = true
};

var priorityOption = new Option<Priority>("--priority", "Task priority level")
{
    DefaultValueFactory = _ => Priority.Medium
};

var dueOption = new Option<DateOnly?>("--due", "Due date in yyyy-MM-dd format");

var allOption = new Option<bool>("--all", "Include completed tasks");
// </Options>

// <Arguments>
var descriptionArgument = new Argument<string>("description", "Task description");

var taskIdArgument = new Argument<int>("id", "Task ID");
// </Arguments>

// <AddCommand>
var addCommand = new Command("add", "Add a new task")
{
    descriptionArgument,
    priorityOption,
    dueOption
};
// </AddCommand>

// <ListCommand>
var listCommand = new Command("list", "List all tasks")
{
    allOption
};
// </ListCommand>

// <CompleteCommand>
var completeCommand = new Command("complete", "Mark a task as complete")
{
    taskIdArgument
};
// </CompleteCommand>

// <RemoveCommand>
var removeCommand = new Command("remove", "Remove a task")
{
    taskIdArgument
};
// </RemoveCommand>

// <RootCommand>
var rootCommand = new RootCommand("A simple task tracker CLI")
{
    verboseOption,
    addCommand,
    listCommand,
    completeCommand,
    removeCommand
};
// </RootCommand>

// <SetActions>
addCommand.SetAction(parseResult =>
{
    var description = parseResult.GetValue(descriptionArgument);
    var priority = parseResult.GetValue(priorityOption);
    var due = parseResult.GetValue(dueOption);
    var verbose = parseResult.GetValue(verboseOption);

    var tasks = LoadTasks();
    var id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
    var task = new TaskItem(id, description, priority, due, false);
    tasks.Add(task);
    SaveTasks(tasks);

    Console.WriteLine($"Added task {id}: {description}");
    if (verbose)
    {
        Console.WriteLine($"  Priority: {priority}");
        if (due is DateOnly dueDate)
        {
            Console.WriteLine($"  Due: {dueDate}");
        }
    }
});

listCommand.SetAction(parseResult =>
{
    var showAll = parseResult.GetValue(allOption);
    var verbose = parseResult.GetValue(verboseOption);

    var tasks = LoadTasks();
    var filtered = showAll ? tasks : tasks.Where(t => !t.IsComplete).ToList();

    if (filtered.Count == 0)
    {
        Console.WriteLine("No tasks found.");
        return;
    }

    foreach (var task in filtered)
    {
        var status = task.IsComplete ? "✓" : " ";
        Console.WriteLine($"  [{status}] {task.Id}: {task.Description}");
        if (verbose)
        {
            Console.WriteLine($"       Priority: {task.Priority}");
            if (task.Due is DateOnly dueDate)
            {
                Console.WriteLine($"       Due: {dueDate}");
            }
        }
    }
});

completeCommand.SetAction(parseResult =>
{
    var id = parseResult.GetValue(taskIdArgument);
    var verbose = parseResult.GetValue(verboseOption);

    var tasks = LoadTasks();
    var task = tasks.FirstOrDefault(t => t.Id == id);

    if (task is null)
    {
        Console.Error.WriteLine($"Task {id} not found.");
        return;
    }

    tasks[tasks.IndexOf(task)] = task with { IsComplete = true };
    SaveTasks(tasks);

    Console.WriteLine($"Completed task {id}: {task.Description}");
    if (verbose)
    {
        Console.WriteLine($"  Priority: {task.Priority}");
    }
});

removeCommand.SetAction(parseResult =>
{
    var id = parseResult.GetValue(taskIdArgument);
    var verbose = parseResult.GetValue(verboseOption);

    var tasks = LoadTasks();
    var task = tasks.FirstOrDefault(t => t.Id == id);

    if (task is null)
    {
        Console.Error.WriteLine($"Task {id} not found.");
        return;
    }

    tasks.Remove(task);
    SaveTasks(tasks);

    Console.WriteLine($"Removed task {id}: {task.Description}");
    if (verbose)
    {
        Console.WriteLine($"  Priority: {task.Priority}");
    }
});
// </SetActions>

// <Invoke>
return rootCommand.Parse(args).Invoke();
// </Invoke>

// <DataHelpers>
static string GetTaskFilePath() => Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
    "taskcli-sample",
    "tasks.json");

static List<TaskItem> LoadTasks()
{
    var path = GetTaskFilePath();
    if (!File.Exists(path))
    {
        return [];
    }

    var json = File.ReadAllText(path);
    return JsonSerializer.Deserialize(json, TaskJsonContext.Default.ListTaskItem) ?? [];
}

static void SaveTasks(List<TaskItem> tasks)
{
    var path = GetTaskFilePath();
    Directory.CreateDirectory(Path.GetDirectoryName(path)!);
    var json = JsonSerializer.Serialize(tasks, TaskJsonContext.Default.ListTaskItem);
    File.WriteAllText(path, json);
}
// </DataHelpers>
