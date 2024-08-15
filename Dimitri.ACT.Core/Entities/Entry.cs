using Dimitri.ACT.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dimitri.ACT.Core.Entities
{
    public class Entry
    {
        public int Id { get; set; }
        public EntryType EntryType { get; set; }
        public decimal Total { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
