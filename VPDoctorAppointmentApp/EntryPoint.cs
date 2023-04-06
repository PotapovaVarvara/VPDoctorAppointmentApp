using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace VPDoctorAppointmentApp;

public static class EntryPoint
{
    
    private static TelegramBotClient client;
    private static string _token = "6084183767:AAFIot6jTZP65lMzmFa8C2UUCM_3GcaW4YM";

    public static async Task Run()
    {

        client = new TelegramBotClient(_token);
        var result = await client.TestApiAsync();
        Console.WriteLine("Result = " + result);
        
        ReceiverOptions receiverOptions = new ()
        {
            AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
        };
        
        var updateReceiver = new QueuedUpdateReceiver(client, receiverOptions);
        var cts = new CancellationTokenSource();
        
        try
        {
            await foreach (Update update in updateReceiver.WithCancellation(cts.Token))
            {
                if (update.Message is Message message)
                {
                    await client.SendTextMessageAsync(
                        message.Chat,
                        $"Still have to process {updateReceiver.PendingUpdates} updates"
                    );
                }
            }
        }
        catch (OperationCanceledException exception)
        {
        }
        
       /* client.StartReceiving(
            updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: _token);
            
          client.OnMessage += BotOnMessageReceived;
          client.OnMessageEdited += BotOnMessageReceived;
          client.StartReceiving();
          Console.ReadLine();
          client.StopReceiving(); */
    } 
     /* private async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
      {
          var message = messageEventArgs.Message;         
          if (message?.Type == MessageType.TextMessage)
          {
              await client.SendTextMessageAsync(message.Chat.Id, message.Text);
          }
      } 
}*/
     
     static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
     {
         // Only process Message updates: https://core.telegram.org/bots/api#message
         if (update.Message is not { } message)
             return;
         // Only process text messages
         if (message.Text is not { } messageText)
             return;

         var chatId = message.Chat.Id;

         Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

         // Echo received message text
         Message sentMessage = await botClient.SendTextMessageAsync(
             chatId: chatId,
             text: "You said:\n" + messageText,
             cancellationToken: cancellationToken);
     }

     static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
     {
         var ErrorMessage = exception switch
         {
             ApiRequestException apiRequestException
                 => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
             _ => exception.ToString()
         };

         Console.WriteLine(ErrorMessage);
         return Task.CompletedTask;
     }
}