using Telegram.Bot;
using Telegram.Bot.Types;
using VPDoctorAppointmentApp.Cache;

namespace VPDoctorAppointmentApp.BotClientCommandHandlers;

public interface IRegisterStartCommandHandler
{
    Task Handle(TelegramBotClient botClient,
        long telegramId);
}

public class RegisterStartCommandHandler: IRegisterStartCommandHandler
{
    public readonly ICacheRegistrationService _cacheRegistrationService;

    public RegisterStartCommandHandler(ICacheRegistrationService cacheRegistrationService)
    {
        _cacheRegistrationService = cacheRegistrationService;
    }
        
    public Task Handle(TelegramBotClient botClient,
        long telegramId)
    {

        var user = _cacheRegistrationService.InProcess(telegramId);
       /* await botClient.SetMyCommandsAsync(
            new List<BotCommand>
            {
                new() {Command = VPMessageType.RegisterStart.Description(), Description = "Register in WhiteDent bot"},
                new() {Command = VPMessageType.GetActualAppointments.Description(), Description = "Get my planned appointments"},
                new() {Command = VPMessageType.GetAllAppointments.Description(), Description = "Get my all appointments"},
            },
            cancellationToken: cts.Token);*/

       return Task.CompletedTask;
    }
}