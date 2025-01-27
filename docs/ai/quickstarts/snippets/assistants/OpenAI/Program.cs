using OpenAI;
using OpenAI.Assistants;
using OpenAI.Files;
using System.ClientModel;

OpenAIClient openAIClient = new("your-apy-key");

#pragma warning disable OPENAI001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
AssistantClient assistantClient = openAIClient.GetAssistantClient();
OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();

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

OpenAIFile salesFile = fileClient.UploadFile(
    document,
    "monthly_sales.json",
    FileUploadPurpose.Assistants);

AssistantCreationOptions assistantOptions = new()
{
    Name = "Example: Contoso sales RAG",
    Instructions =
        "You are an assistant that looks up sales data and helps visualize the information based"
        + " on user queries. When asked to generate a graph, chart, or other visualization, use"
        + " the code interpreter tool to do so.",
    Tools =
    {
        new FileSearchToolDefinition(),
        new CodeInterpreterToolDefinition(),
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

Assistant assistant = assistantClient.CreateAssistant("gpt-4o", assistantOptions);

ThreadCreationOptions threadOptions = new()
{
    InitialMessages = { "How well did product 113045 sell in February? Graph its trend over time." }
};

ThreadRun threadRun = assistantClient.CreateThreadAndRun(assistant.Id, threadOptions);

do
{
    Thread.Sleep(TimeSpan.FromSeconds(1));
    threadRun = assistantClient.GetRun(threadRun.ThreadId, threadRun.Id);
}
while (!threadRun.Status.IsTerminal);

var messages = assistantClient.GetMessagesAsync(threadRun.ThreadId, new MessageCollectionOptions() { Order = MessageCollectionOrder.Ascending });

await foreach (ThreadMessage message in messages)
{
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

            // Include annotations, if any.
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