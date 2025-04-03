using OpenAI;
using OpenAI.Assistants;
using OpenAI.Files;
using Azure.AI.OpenAI;
using Azure.Identity;

// Create the OpenAI client
OpenAIClient openAIClient = new("your-apy-key");

// For Azure OpenAI, use the following client instead:
AzureOpenAIClient azureAIClient = new(
        new Uri("your-azure-openai-endpoint"),
        new DefaultAzureCredential());

#pragma warning disable OPENAI001
AssistantClient assistantClient = openAIClient.GetAssistantClient();
OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();

// Create an in-memory document to upload to the file client
using Stream document = BinaryData.FromBytes("""
    {
        "description": "This document contains the sale history data for Contoso products.",
        "sales": [
            {
                "month": "January",
                "by_product": {
                    "113043": 15,
                    "113045": 12,
                    "113049": 2
                }
            },
            {
                "month": "February",
                "by_product": {
                    "113045": 22
                }
            },
            {
                "month": "March",
                "by_product": {
                    "113045": 16,
                    "113055": 5
                }
            }
        ]
    }
    """u8.ToArray()).ToStream();

// Upload the document to the file client
OpenAIFile salesFile = fileClient.UploadFile(
    document,
    "monthly_sales.json",
    FileUploadPurpose.Assistants);

// Configure the assistant options
AssistantCreationOptions assistantOptions = new()
{
    Name = "Example: Contoso sales RAG",
    Instructions =
        "You are an assistant that looks up sales data and helps visualize the information based"
        + " on user queries. When asked to generate a graph, chart, or other visualization, use"
        + " the code interpreter tool to do so.",
    Tools =
    {
        new FileSearchToolDefinition(), // Enable the assistant to search and access files
        new CodeInterpreterToolDefinition(), // Enable the assistant to run code for data analysis
    },
    ToolResources = new()
    {
        FileSearch = new()
        {
            NewVectorStores =
            {
                new VectorStoreCreationHelper([salesFile.Id]),
            }
        }
    },
};

// Create the assistant
Assistant assistant = assistantClient.CreateAssistant("gpt-4o", assistantOptions);

// Configure and create the conversation thread
ThreadCreationOptions threadOptions = new()
{
    InitialMessages = { "How well did product 113045 sell in February? Graph its trend over time." }
};

ThreadRun threadRun = assistantClient.CreateThreadAndRun(assistant.Id, threadOptions);

// Sent the prompt and monitor progress until the thread run is complete
do
{
    Thread.Sleep(TimeSpan.FromSeconds(1));
    threadRun = assistantClient.GetRun(threadRun.ThreadId, threadRun.Id);
}
while (!threadRun.Status.IsTerminal);

// Get the messages from the thread run
var messages = assistantClient.GetMessagesAsync(
    threadRun.ThreadId,
    new MessageCollectionOptions()
    { 
        Order = MessageCollectionOrder.Ascending
    });

await foreach (ThreadMessage message in messages)
{
    // Print out the messages from the assistant
    Console.Write($"[{message.Role.ToString().ToUpper()}]: ");
    foreach (MessageContent contentItem in message.Content)
    {
        if (!string.IsNullOrEmpty(contentItem.Text))
        {
            Console.WriteLine($"{contentItem.Text}");

            if (contentItem.TextAnnotations.Count > 0)
            {
                Console.WriteLine();
            }

            // Include annotations, if any
            foreach (TextAnnotation annotation in contentItem.TextAnnotations)
            {
                if (!string.IsNullOrEmpty(annotation.InputFileId))
                {
                    Console.WriteLine($"* File citation, file ID: {annotation.InputFileId}");
                }
                if (!string.IsNullOrEmpty(annotation.OutputFileId))
                {
                    Console.WriteLine($"* File output, new file ID: {annotation.OutputFileId}");
                }
            }
        }
        // Save the generated image file
        if (!string.IsNullOrEmpty(contentItem.ImageFileId))
        {
            OpenAIFile imageInfo = fileClient.GetFile(contentItem.ImageFileId);
            BinaryData imageBytes = fileClient.DownloadFile(contentItem.ImageFileId);
            using FileStream stream = File.OpenWrite($"{imageInfo.Filename}.png");
            imageBytes.ToStream().CopyTo(stream);

            Console.WriteLine($"<image: {imageInfo.Filename}.png>");
        }
    }
    Console.WriteLine();
}