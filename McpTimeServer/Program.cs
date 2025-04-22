using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace McpTimeServer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = Host.CreateEmptyApplicationBuilder(null);

            // Configure logging
            builder.Services.AddLogging(logging =>
                logging.AddConsole().SetMinimumLevel(LogLevel.Debug)
            );

            // Add MCP server
            builder.Services
                .AddMcpServer()
                .WithStdioServerTransport()
                .WithToolsFromAssembly();

            var app = builder.Build();

            await app.RunAsync();
        }
    }
}
