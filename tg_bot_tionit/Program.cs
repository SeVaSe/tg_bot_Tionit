using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot;
using Telegram.Bot.Types;
//6489394873:AAET3koh_wVNMO2rX7zIyFLwBYOoR70ZlFc
namespace tg_bot_tionit
{
    internal class Program
    {
        private static readonly TelegramBotClient Bot_Tg = new TelegramBotClient("6489394873:AAET3koh_wVNMO2rX7zIyFLwBYOoR70ZlFc");
        private static readonly Dictionary<long, long> ClientToOperatorMap = new Dictionary<long, long>();
        private static readonly long OperatorGroupId = -1001711439253; // Replace with your operator group ID

        static async Task Main(string[] args)
        {
            Bot_Tg.OnMessage += Bot_OnMessage;
            Bot_Tg.StartReceiving();
            Console.WriteLine("Bot started. Press any key to exit...");
            Console.ReadKey();
            Bot_Tg.StopReceiving();
        }

        private static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var message = e.Message;

            if (message == null)
            {
                return;
            }

            if (message.Type == MessageType.Text)
            {
                if (message.Chat.Type == ChatType.Group && message.Chat.Id == OperatorGroupId)
                {
                    // Message is from operator group, forward it to the appropriate client
                    if (ClientToOperatorMap.ContainsKey(message.Chat.Id))
                    {
                        long clientId = ClientToOperatorMap[message.Chat.Id];
                        await Bot_Tg.SendTextMessageAsync(clientId, message.Text);
                    }
                }
                else if (message.Chat.Type == ChatType.Private)
                {
                    // Message is from a client, forward it to the operator group
                    await ForwardToOperatorGroup(message);
                }
            }
        }

        private static async Task ForwardToOperatorGroup(Message message)
        {
            // Store the mapping between client and operator
            ClientToOperatorMap[message.Chat.Id] = OperatorGroupId;

            // Forward the message to the operator group
            var forwardedMessage = $"Forwarded from client: {message.Chat.FirstName}\n{message.Text}";
            await Bot_Tg.SendTextMessageAsync(OperatorGroupId, forwardedMessage);
        }
    }
}
   