using Dimitri.ACT.Api.Services.Interfaces;
using Dimitri.ACT.Core.DTOs;
using Dimitri.ACT.Core.Entities;
using MassTransit;

namespace Dimitri.ACT.Api.Services
{
    public class EntryService : IEntryService
    {
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;

        public EntryService(IBus bus, IConfiguration configuration)
        {
            _bus = bus;
            _configuration = configuration;
        }

        public async Task NewEntry(NewEntryDTO dto)
        {
            var entry = new Entry
            {
                EntryType = dto.EntryType,
                Total = dto.Total,
            };

            var queueName = _configuration.GetSection("MassTransit")["NewEntryQueue"] ?? string.Empty;
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{queueName}"));

            await endpoint.Send(entry);
        }
    }
}
