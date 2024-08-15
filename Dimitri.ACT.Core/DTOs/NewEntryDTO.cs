using Dimitri.ACT.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dimitri.ACT.Core.DTOs
{
    public class NewEntryDTO
    {
        public EntryType EntryType { get; set; }
        public decimal Total { get; set; }
    }
}
