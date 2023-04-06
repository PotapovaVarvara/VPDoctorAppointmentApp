using DomainModels.Messaging;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using VPDoctorAppointmentApp.BotClientCommandHandlers;
using VPMessageType = DomainModels.Messaging.MessageType;

namespace VPDoctorAppointmentApp;

public class BotEngine
{
    private readonly TelegramBotClient _botClient;
    private static string _token = "5872250690:AAHGkW0BpEYaTRNFewhm6erGndgYpLWUUNg";

    public readonly IClientCommandHandler _clientCommandHandler;
        
    public BotEngine(IClientCommandHandler clientCommandHandler)
    {
        _botClient = new TelegramBotClient(_token);

        _clientCommandHandler = clientCommandHandler;
    }
    
    public async Task ListenForMessagesAsync()
    {
        using var cts = new CancellationTokenSource();

        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
        };
        
        _botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cts.Token
        );
        

        var me = await _botClient.GetMeAsync();

        await _botClient.SetMyCommandsAsync(
            new List<BotCommand>
            {
                new() {Command = VPMessageType.RegisterStart.ToString().ToLower(), Description = VPMessageType.RegisterStart.Description()},
                new() {Command = VPMessageType.GetActualAppointments.ToString().ToLower(), Description = VPMessageType.GetActualAppointments.Description()},
                new() {Command = VPMessageType.GetAllAppointments.ToString().ToLower(), Description = VPMessageType.GetAllAppointments.Description()},
            },
            cancellationToken: cts.Token);
        
        Console.WriteLine($"Start listening for @{me.Username}");
        Console.ReadLine();
    }
    
    
    private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { } message)
        {
            return;
        }

        if (message.Text is not { } messageText)
        {
            return;
        }
        
        _clientCommandHandler.Handle(messageText, _botClient, message.From.Id);

       // await botClient.SetChatMenuButtonAsync(message.Chat.Id, new MenuButtonDefault());
        Console.WriteLine($"Received a '{messageText}' message in chat {message.Chat.Id}.");
        await botClient.SendTextMessageAsync(message.Chat.Id, $"Received a '{messageText}' message in chat {message.Chat.Id}.");
        var v = await botClient.GetMyCommandsAsync();


    }
    
    private Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
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