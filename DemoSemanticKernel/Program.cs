#pragma warning disable SKEXP0010
#pragma warning disable SKEXP0070

using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using OllamaSharp;

const string endpoint = "http://localhost:11434";
const string model = "llama3.2:1b";

var builder = Kernel.CreateBuilder()
    .AddOllamaChatCompletion(ollamaClient: new OllamaApiClient(new Uri(endpoint), model));

var kernel = builder.Build();
var chatService = kernel.GetRequiredService<IChatCompletionService>();

var chatHistory = new ChatHistory();

Console.WriteLine("Type /q to quit from conversation.");

while (true)
{
    Console.Write("Question: ");
    var userQuestion = Console.ReadLine();

    if (string.IsNullOrEmpty(userQuestion))
    {
        continue;
    }

    if (userQuestion == "/q")
    {
        break;
    }
    
    chatHistory.AddUserMessage(userQuestion);

    var responses = chatService
        .GetStreamingChatMessageContentsAsync(chatHistory, kernel: kernel);

    Console.Write("Answer: ");
    var fullAnswer = "";
    await foreach (var message in responses)
    {
        Console.Write(message.Content ?? string.Empty);
        fullAnswer += message.Content ?? string.Empty;
    }
    
    chatHistory.AddAssistantMessage(fullAnswer);
    
    Console.Write("\n");
}