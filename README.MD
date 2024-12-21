## Demo Semantic Kernel with local model with Ollama Connector

#### First need to install ollama from this site
```
https://ollama.com/
```

#### after install pull the model to your system with this command

```shell
ollama pull llama3.2:1b
```

#### after pull use this command to get list of installed model on your computer
```shell
ollama list
```
---
### Run the project

```shell
dotnet restore  // to install packages
dotnet run --project ./DemoSemanticKernel/
```

for quit the conversation type /q