using System;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace DeepOrange_bot
{
    class Program
    {
        private static string token { get; set; } = "2123782383:AAHJHwaPuGjSu3khAJcFleuiqR2JxsIoE-4";

        private static TelegramBotClient client;

        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += onMessageHandler;
            client.OnCallbackQuery += onCallbackQueryHandler;
            Console.ReadLine();
            client.StopReceiving();
        }

        private static Dictionary<long, UserState> clientStates = new Dictionary<long, UserState>();

        private static async void onMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            
            var state = clientStates.ContainsKey(msg.Chat.Id) ? clientStates[msg.Chat.Id] : null;
            if(state != null)
            {
                switch(state.State)
                {
                    case State.SearchAnswer:
                        var answer = GetAnswer(msg.Text);
                        if(answer != null)
                        {
                            await client.SendTextMessageAsync(chatId: msg.Chat.Id, text: "Правильно");
                        }
                        else
                        {
                            await client.SendTextMessageAsync(chatId: msg.Chat.Id, text: "Неправильно");
                        }

                        break;
                }
            } 
            else
            {
                if (msg != null)
                {
                    try
                    {
                        if (msg.Text == "/start" || msg.Text == "/start@DeepOrange_bot")
                        {
                            clientStates[msg.Chat.Id] = new UserState { State = State.SearchAnswer };
                            await client.SendTextMessageAsync(chatId: msg.Chat.Id, text: "Игра началась!");
                            await client.SendTextMessageAsync(chatId: msg.Chat.Id, text: "Выберите предложение:", replyMarkup: GetTextWithPossibleAnswer());
                        }
                        if (msg.Text == "/rules" || msg.Text == "/rules@DeepOrange_bot")
                        {
                            await client.SendTextMessageAsync(
                                chatId: msg.Chat.Id,
                                text: "Правила тутутуту \n\nНаш веб-сайт, где можно скачать клиент:",
                                replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl(
                                          "DeepOrange",
                                          "https://DeepOrange-project.com"))
                                );
                        }
                    }
                    catch (Exception ex)
                    {
                        await client.SendTextMessageAsync(
                                chatId: msg.Chat.Id,
                                text: ex.Message
                                );
                    }
                }
            } 
        }

        private static async void onCallbackQueryHandler(object sender, CallbackQueryEventArgs c)
        {

        }

        private static IReplyMarkup GetTextWithPossibleAnswer()
        {
            //TODO: GET TEXT WITH POSSIBLE ANSWER FROM DATA BASE
            return new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    new InlineKeyboardButton{ Text = "I'm call now", CallbackData = "id" },
                }
            });
        }

        private static string GetAnswer(string msg)
        {
            //TODO: GET POSSIBLE ANSWER FROM DATA BASE
            if(msg.Equals("calling")) {
                return "calling";
            }
            else
            {
                return null;
            }
        }
    }
}