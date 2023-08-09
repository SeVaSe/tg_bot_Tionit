using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot;

namespace tg_bot_tionit
{
    internal class Program
    {
        // токен
        private static readonly TelegramBotClient Bot_Tg = new TelegramBotClient("6489394873:AAET3koh_wVNMO2rX7zIyFLwBYOoR70ZlFc"); 
        private static Dictionary<long, string> Our_Clients = new Dictionary<long, string>();// словарь с данными клиента

        static async Task Main(string[] args)
        {

        }

        private static async void Input_Message(object sender, MessageEventArgs e)
        {

        }




    }
}
   