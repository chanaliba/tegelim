using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using System.Collections.Specialized;

namespace Tegelim
{
    class Program
    {
        static void Main(string[] args)
        {
            //5376981469:AAHb9UgHSckTQib7smlXgBYpSxUI10EKtYA
            try
            {
                TelegramBotHelper hlp = new TelegramBotHelper(token: "5376981469:AAHb9UgHSckTQib7smlXgBYpSxUI10EKtYA");
                hlp.GetUpdates();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
