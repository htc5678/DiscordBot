using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

public class Program
{
	private DiscordSocketClient _client;

	public static void Main(string[] args)
		=> new Program().MainAsync().GetAwaiter().GetResult();

	public async Task MainAsync()
	{
		_client = new DiscordSocketClient();
		_client.Log += Log;
		var token = "https://discord.com/api/oauth2/authorize?client_id=959176639005200485&permissions=8&scope=bot";

		await _client.LoginAsync(TokenType.Bot, token);
		await _client.StartAsync();

		// Block this task until the program is closed.
		await Task.Delay(-1);
	}
	private Task Log(LogMessage msg)
	{
		Console.WriteLine(msg.ToString());
		return Task.CompletedTask;
	}

	private static Task ClientOnMessageReceived(SocketMessage arg)
	{
		if (arg.Content.StartsWith("!helloworld"))
		{
			arg.Channel.SendMessageAsync($"User '{arg.Author.Username}' successfully ran helloworld!");
		}
		return Task.CompletedTask;
	}
}