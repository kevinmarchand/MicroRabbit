using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _repository;

        public TransferEventHandler(ITransferRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(TransferCreatedEvent @event)
        {
            var log = new TransferLog();
            log.From = @event.From;
            log.To = @event.To;
            log.Amount = @event.Amount;
            log.Timestamp = @event.Timestamp;

            _repository.SaveTransferLog(log);
            return Task.CompletedTask;
        }
    }
}
