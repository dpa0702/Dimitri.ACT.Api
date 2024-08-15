using Dimitri.ACT.Core.DTOs;

namespace Dimitri.ACT.Api.Services.Interfaces
{
    public interface IEntryService
    {
        Task NewEntry(NewEntryDTO dto);
    }
}
