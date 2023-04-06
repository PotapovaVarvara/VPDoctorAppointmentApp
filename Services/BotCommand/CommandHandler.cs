using System;
using System.Threading.Tasks;
using DomainModels.Messaging;
using Services.BotCommand.Handlers;
using VPMessageType = DomainModels.Messaging.MessageType;

namespace Services.BotCommand
{
    public interface ICommandHandler
    {
        Task Handle(string command);
    }

    public class CommandHandler: ICommandHandler
    {
        private readonly IRegisterCommandHandler _registerCommandHandler;

        public CommandHandler(IRegisterCommandHandler registerCommandHandler)
        {
            _registerCommandHandler = registerCommandHandler;
        }

        public Task Handle(string command)
        {
            if (command == VPMessageType.RegisterStart.Description())
            {
                //_registerCommandHandler.
            }

            throw new NotImplementedException();
        }
    }
}