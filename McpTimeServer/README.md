# Building Your First MCP Server with .NET: A Developer's Guide to Model Context Protocol

Este repositório contém instruções detalhadas para construir e integrar um servidor MCP usando .NET, com o objetivo de expandir as funcionalidades de Modelos de Linguagem de Grande Porte (LLMs) em aplicações modernas.

## Sobre o MCP
O **Model Context Protocol (MCP)** é um padrão aberto que facilita a comunicação bidirecional segura entre modelos de IA, ferramentas e APIs externas, permitindo interações mais estruturadas e previsíveis.

## Funcionalidades
- Conexão de **LLMs** com ferramentas e fontes de dados externas.
- Criação de um **servidor MCP** em .NET para fornecer dados especializados, como informações de horário.
- Integração do servidor MCP com o **Cursor IDE** como cliente MCP.

## Melhorias

1. **Adição de Logs**:
   - Logs foram introduzidos em `Program.cs` para facilitar a depuração e monitorar o comportamento do servidor MCP.

2. **Validação de Entrada**:
   - O método `GetTimeInTimezone` agora verifica se o parâmetro de fuso horário não está vazio ou nulo antes de processá-lo, evitando erros desnecessários.

3. **Mensagens de Erro Detalhadas**:
   - Tratamento aprimorado de exceções em `GetTimeInTimezone` com mensagens específicas, como para fusos horários inválidos ou não encontrados.

4. **Formato Configurável de Hora**:
   - Data e hora foram formatadas (`dd/MM/yyyy HH:mm:ss`) para maior legibilidade, com possibilidade de personalização.

5. **Estrutura com Namespaces**:
   - Organizei as classes em namespaces (`McpTimeServer` e `McpTimeServer.Tools`) para melhor separação lógica e escalabilidade.

6. **Código mais robusto e organizado**:
   - As alterações tornam o servidor MCP mais confiável, preparado para crescimentos futuros e com melhor clareza para equipes de desenvolvimento.

## Passos para Configuração

### Criação do Projeto
Crie um novo aplicativo de console:
```bash
dotnet new console -n McpTimeServer
cd McpTimeServer
```

### Instalação de Dependências
Adicione os pacotes necessários:
```bash
dotnet add package ModelContextProtocol --prerelease
dotnet add package Microsoft.Extensions.Hosting
```

### Implementação do Servidor
Configure o servidor MCP em `Program.cs`:
```c#
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
```

Implemente ferramentas como métodos para funcionalidades específicas:
```c#
public static string GetCurrentTime() { return DateTimeOffset.Now.ToString(); }
```

### Integração com Cursor IDE
Adicione o servidor MCP ao arquivo de configuração `mcp.json` no Cursor IDE:
```json
{
  "mcpServers": {
    "timeServer": {
      "command": "dotnet",
      "args": ["run", "--project", "path/to/your/McpTimeServer"]
    }
  }
}
```

---

## Origem do Conteúdo
As instruções deste repositório são baseadas no artigo **"Building Your First MCP Server with .NET: A Developer's Guide to Model Context Protocol"**, escrito por **Engincan Veske**. O conteúdo original pode ser encontrado [neste link](https://engincanveske.substack.com/p/building-your-first-mcp-server-with).

---

## Contribuição
Sinta-se à vontade para abrir **Issues** ou enviar **Pull Requests** para melhorar este guia ou adicionar novas funcionalidades.

---

## Links Úteis
- [Protocolo de Contexto do Modelo (MCP)](https://www.anthropic.com/news/model-context-protocol)
- [SDK oficial do MCP C#](https://github.com/modelcontextprotocol/csharp-sdk)
- [Especificação MCP](https://github.com/modelcontextprotocol/specification)

---