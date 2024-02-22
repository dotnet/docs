using System.IO;
using System.Collections;

const int InitialCapacity = 100;

Hashtable creationTimeByFile = new(InitialCapacity, StringComparer.OrdinalIgnoreCase);
string directoryToProcess = Directory.GetCurrentDirectory();

// Fill the hash table
PopulateFileTable(directoryToProcess);

// Get some of the files and try to find them with upper cased names
foreach (var file in Directory.GetFiles(directoryToProcess))
    PrintCreationTime(file.ToUpper());


void PopulateFileTable(string directory)
{
    foreach (string file in Directory.GetFiles(directory))
        creationTimeByFile.Add(file, File.GetCreationTime(file));
}

void PrintCreationTime(string targetFile)
{
    object? dt = creationTimeByFile[targetFile];

    if (dt is DateTime value)
        Console.WriteLine($"File {targetFile} was created at time {value}.");
    else
        Console.WriteLine($"File {targetFile} does not exist.");
}
