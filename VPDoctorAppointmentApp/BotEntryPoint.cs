using Telegram.Bot;

namespace VPDoctorAppointmentApp;

public class BotEntryPoint
{
    private static TelegramBotClient client;
    private static string _token = "5872250690:AAHGkW0BpEYaTRNFewhm6erGndgYpLWUUNg";
    
    
    public static async Task Run()
    {

        client = new TelegramBotClient(_token);
        var result = await client.TestApiAsync();
        Console.WriteLine("Result = " + result);
        
       /* ReceiverOptions receiverOptions = new ()
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
       
         client.StartReceiving(
             updateHandler: HandleUpdateAsync,
             pollingErrorHandler: HandlePollingErrorAsync,
             receiverOptions: receiverOptions,
             cancellationToken: _token);
             
           client.OnMessage += BotOnMessageReceived;
           client.OnMessageEdited += BotOnMessageReceived;
           client.StartReceiving();
           Console.ReadLine();
           client.StopReceiving();  */
    } 
}