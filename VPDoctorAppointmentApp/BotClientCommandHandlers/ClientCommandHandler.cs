using DomainModels.Messaging;
using Services.BotCommand;
using Telegram.Bot;
using VPMessageType = DomainModels.Messaging.MessageType;

namespace VPDoctorAppointmentApp.BotClientCommandHandlers;

public interface IClientCommandHandler
{
    void Handle(string command, TelegramBotClient botClient, long telegramId);
}

public class ClientCommandHandler: IClientCommandHandler
{
    private readonly IRegisterStartCommandHandler _registerStartCommandHandler;
    private readonly ICommandHandler _commandHandler;
        
    public ClientCommandHandler(
        IRegisterStartCommandHandler registerStartCommandHandler,
        ICommandHandler commandHandler)
    {
        _registerStartCommandHandler = registerStartCommandHandler;
        _commandHandler = commandHandler;
    }
        
    public void Handle(
        string command, 
        TelegramBotClient botClient,
        long telegramId)
    {
        if (command == VPMessageType.RegisterStart.Description())
        {
            _registerStartCommandHandler.Handle(botClient,telegramId);
        }

        _commandHandler.Handle(command);

    }
}