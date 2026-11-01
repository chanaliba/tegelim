using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Tegelim
{
    internal class TelegramBotHelper
    {
        // Создание констант для кнопок
        private const string ModeAni = "Модэ Ани";
        private const string AdonOlam = "Адон Олам";
        private const string Shma = "Шма Исраэль";
        private const string Amida = "Шмонэ Эсре";
        private const string DorojMol = "Дорожная молитва";
        private const string Spravka = "Справка";
        private string token; // токен
        Telegram.Bot.TelegramBotClient client; //переменная для обработки действий пользователя

        
        public TelegramBotHelper(string token)
        {
            this.token = token;
        }

        internal void GetUpdates() //для отправки/приёма сообщений ботом
        {
            client = new Telegram.Bot.TelegramBotClient(token); //создаём объект и передаём ему наш токен
            var me = client.GetMeAsync().Result;
            if (me != null && !string.IsNullOrEmpty(me.Username))
            {
                int offset = 0;
                while (true)
                {
                    try
                    {
                        
                        var updates = client.GetUpdatesAsync(offset).Result;
                        if (updates != null && updates.Count() > 0)
                        {
                            foreach(var update in updates)
                            {

                                processUpdate(update);
                                offset = update.Id + 1;
                            }
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }

                    Thread.Sleep(1000);
                }
            }
        }

        private async void processUpdate(Telegram.Bot.Types.Update update)
        {
            
            switch (update.Type)
            {
                case Telegram.Bot.Types.Enums.UpdateType.Message:
                    
                    var text = update.Message.Text;
                    
                    switch (text) // подключение картинок к кнопкам
                    {
                        case ModeAni:
                            Message[] photo1 = await client.SendMediaGroupAsync(chatId: update.Message.Chat.Id, media: new IAlbumInputMedia[]
                           {
                                new InputMediaPhoto("https://disk.yandex.ru/i/X27ydvcJRjAuHw"),
                           });
                            break;
                        case AdonOlam:
                            Message[] photo2 = await client.SendMediaGroupAsync(chatId: update.Message.Chat.Id, media: new IAlbumInputMedia[]
                           {
                                new InputMediaPhoto("https://disk.yandex.ru/i/w1nXDJJttmYSvA"),
                           });
                            break;

                        case Shma:

                            Message[] photo3 = await client.SendMediaGroupAsync(chatId: update.Message.Chat.Id, media: new IAlbumInputMedia[]
                            {
                                new InputMediaPhoto("https://disk.yandex.ru/i/TYKkP2FLhgUoCw"),
                                new InputMediaPhoto("https://disk.yandex.ru/i/VgXKvFYMl9sLDA"),
                                new InputMediaPhoto("https://disk.yandex.ru/i/rirL-QOLeAgZmA"),
                                new InputMediaPhoto("https://disk.yandex.ru/i/k6gVyHDCX5-NfQ"),
                            });
                            break;

                        case Amida:
                            Message[] photo4 = await client.SendMediaGroupAsync(chatId: update.Message.Chat.Id, media: new IAlbumInputMedia[]
                           {
                                new InputMediaPhoto("https://disk.yandex.ru/i/Lx_H7JzG31gUtA"),
                                new InputMediaPhoto("https://disk.yandex.ru/i/U0XJK5aYWD4XwA"),
                                new InputMediaPhoto("https://disk.yandex.ru/i/RSFzu_1M_7lTKA"),
                                new InputMediaPhoto("https://disk.yandex.ru/i/NV6EhTa1XHf05g"),
                                new InputMediaPhoto("https://disk.yandex.ru/i/5n__83TuMsIdTQ"),
                                new InputMediaPhoto("https://disk.yandex.ru/i/5HNXKU7C0Ooz3g"),
                           });
                            break;
                        case DorojMol:
                            Message[] photo5 = await client.SendMediaGroupAsync(chatId: update.Message.Chat.Id, media: new IAlbumInputMedia[]
                           {
                                new InputMediaPhoto("https://disk.yandex.ru/i/XxcxiLJbjjQKbg"),
                           });
                            break;
                        case Spravka:
                            client.SendTextMessageAsync(update.Message.Chat.Id, "Рады приветствовать Вас в телеграм канале Sidur! Данный канал поможет вам быстро и в удобном формате найти основные молитвы. Для того, чтобы увидеть, интерисующую вас молитву - нажмите на кнопку, с соответствующим названием. *Шмонэ Эсре = Амида.", replyMarkup: GetButtons());
                            break;
                    }
                    client.SendTextMessageAsync(update.Message.Chat.Id, "Чтобы выбрать молитву - нажмите на одну из кнопок внизу", replyMarkup: GetButtons());
                    break;
                default:
                    Console.WriteLine(update.Type + "Данный тип не обрабатывается. Нажмите на одну из предложенных кнопок, пожалуйста");
                    break;
            }
        }


       

        private IReplyMarkup GetButtons() // создание кнопок
        {
            return new ReplyKeyboardMarkup(new[]
            {
                new[]
                {
                    new KeyboardButton(ModeAni),
                    new KeyboardButton(AdonOlam),
                    new KeyboardButton(Shma),
                },
                new[]
                {
                    new KeyboardButton(Amida),
                    new KeyboardButton(DorojMol),
                    new KeyboardButton(Spravka),
            }   })
                {
                    ResizeKeyboard = true // размер кнопок
                };
        }
    }
}