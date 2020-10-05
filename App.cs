using DSharpPlus;
using DSharpPlus.EventArgs;
using System;
using System.Threading.Tasks;
using DotNetEnv;

namespace App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Load environment variables
            DotNetEnv.Env.Load();

            // Create discord client using token
            var discordClient = new DiscordClient(new DiscordConfiguration
            {
                Token = DotNetEnv.Env.GetString("TOKEN"),
                TokenType = TokenType.Bot
            });

            // Register the message created task
            discordClient.MessageCreated += OnMessageCreated;

            // Connect
            await discordClient.ConnectAsync();
            await Task.Delay(-1);
        }

        // Message created tasl
        private static async Task OnMessageCreated(MessageCreateEventArgs eventArgs)
        {
            if (string.Equals(eventArgs.Message.Content, "hello", StringComparison.OrdinalIgnoreCase))
            {
                await eventArgs.Message.RespondAsync(eventArgs.Message.Author.Username);
            }
        }
    }
}