using Dimitri.ACT.Core.DTOs;
using Dimitri.ACT.Core.Entities;

namespace Dimitri.ACT.EntryMS.Services.Interfaces
{
    public interface IEntryService
    {
        Task<IList<Entry>> GetAll(CancellationToken ct);
        Task<decimal> GetAllDay(CancellationToken ct);
        Task<Entry> GetById(int id, CancellationToken ct);
        Task Add(NewEntryDTO entry, CancellationToken ct);
    }
}
