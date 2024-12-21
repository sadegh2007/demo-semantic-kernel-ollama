## Demo Semantic Kernel with local model with Ollama Connector

1.First need to install Ollama from this site
```
https://ollama.com
```

2.Start Ollama

```shell
ollama serve
```

3.Pull the model to your system with this command with Ollama

```shell
ollama pull llama3.2:1b
```

4.Use this command to get list of installed model on your computer
```shell
ollama list
```
---
### packages used in this project
```
Microsoft.SemanticKernel [1.32.0]
Microsoft.SemanticKernel.Connectors.Ollama [1.32.0-alpha]
```
---
### Run the project
```shell
dotnet restore  // to install packages
dotnet run --project ./DemoSemanticKernel/
```

for quit the conversation type /q