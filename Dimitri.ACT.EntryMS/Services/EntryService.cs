using Dimitri.ACT.Core.DTOs;
using Dimitri.ACT.Core.Entities;
using Dimitri.ACT.Core.Enums;
using Dimitri.ACT.EntryMS.Repositories.Interfaces;
using Dimitri.ACT.EntryMS.Services.Interfaces;

namespace Dimitri.ACT.EntryMS.Services
{
    public class EntryService : IEntryService
    {
        private readonly IEntryRepository _entryRepository;
        public EntryService(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public async Task Add(NewEntryDTO entryDTO, CancellationToken ct)
        {
            try
            {
                ct.ThrowIfCancellationRequested();

                var entry = new Entry
                {
                    EntryType = entryDTO.EntryType,
                    Total = entryDTO.EntryType == EntryType.Debit ? decimal.Negate(entryDTO.Total) : entryDTO.Total,
                    Timestamp = DateTime.Now,
                };

                await _entryRepository.Insert(entry, ct);
            }
            catch (Exception ex)
            {
                throw new BadHttpRequestException("Erro: " + ex.Message);
            }
        }

        public async Task<IList<Entry>> GetAll(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            return await _entryRepository.GetAll(ct);
        }
        public async Task<decimal> GetAllDay(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            return await _entryRepository.GetAllDay(ct);
        }

        public async Task<Entry> GetById(int id, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            var entry = await _entryRepository.GetById(id, ct);

            return entry ?? throw new BadHttpRequestException("Lançamento não encontrado");
        }
    }
}
