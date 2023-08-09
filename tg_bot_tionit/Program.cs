﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot;
using Telegram.Bot.Types;

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
            var mes = e.Message;

            if (mes == null) // если сообщение будет пустное
            {
                return;
            }

            // проверка есть ли клиент в словаре, если нет то делаю заношу его и делаю новую тему
            if (!Our_Clients.ContainsKey(mes.Chat.Id))
            {
                var nameClient = mes.Chat.FirstName;
                Our_Clients.Add(mes.Chat.Id, nameClient);
            }

            // создание темы + получение сообщения от клиента
            var clientTheme = $"Forwarded from {Our_Clients[mes.Chat.Id]}";
            var mesClient = $"{clientTheme}\n{mes.Text}";



        }




    }
}
   