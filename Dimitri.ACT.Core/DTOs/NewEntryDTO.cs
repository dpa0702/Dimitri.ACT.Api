using Dimitri.ACT.Core.Enums;

namespace Dimitri.ACT.Core.DTOs
{
    public class NewEntryDTO
    {
        public EntryType EntryType { get; set; }
        public decimal Total { get; set; }
    }
}