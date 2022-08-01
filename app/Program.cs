using Discord;
using Discord.WebSocket;
using Discord.Commands;

namespace Program{
    class app{
        public static Task Main(string[] args) => new app().MainAsync();
        private DiscordSocketClient _client;
        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.MessageReceived += CommandHandler;
            _client.Log += Log;
            var token = "";
            await _client.LoginAsync(TokenType.Bot,token);
            await _client.StartAsync();
            // Block this task until the program is closed.
            await Task.Delay(-1);
        }
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
        private Task CommandHandler(SocketMessage message)
        {
            string command = "";
            int lengthofcommand = -1;
            
            //filter

            if(!message.Content.StartsWith("^"))
                return Task.CompletedTask;

            if (message.Author.IsBot)
                return Task.CompletedTask;

            if (message.Content.Contains(" "))
            {
                lengthofcommand = message.Content.IndexOf(" ");
            }
            else
            {
                lengthofcommand = message.Content.Length;
            }
            command = message.Content.Substring(1,lengthofcommand-1);

            //commands
            if (command.Equals("hi"))
            {
                message.Channel.SendMessageAsync($@"Hello {message.Author.Mention}" );
            }
            else if (command.Equals("gamecreate")){
                string vchannel = command.Substring(9, command.Length-1);
                RoomCreator(vchannel);
            }

            return Task.CompletedTask;
        }
        public Task RoomCreator(string vcTitle)
        {
            
            return Task.CompletedTask;
        }
        
    }
}