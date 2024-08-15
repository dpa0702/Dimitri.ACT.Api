using Dimitri.ACT.Core.Entities;
using Dimitri.ACT.EntryMS.Data;
using Dimitri.ACT.EntryMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dimitri.ACT.EntryMS.Repositories
{
    public class EntryRepository : IEntryRepository
    {
        public readonly EntryMSContext _context;

        public EntryRepository(EntryMSContext context)
        {
            _context = context;
        }

        public async Task<IList<Entry>> GetAll(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            return await _context.Entries.ToListAsync(ct);
        }

        public async Task<decimal> GetAllDay(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            decimal total = _context.Entries.Where(d => d.Timestamp.Date == DateTime.Now.Date)
                .Sum(e => e.Total);

            return total;//await _context.Entries.ToListAsync(ct);
        }

        public async Task<Entry> GetById(int id, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            return await _context.Entries.FirstOrDefaultAsync(entry => entry.Id == id, ct);
        }

        public async Task Insert(Entry entity, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            _context.Entries.Add(entity);
            await _context.SaveChangesAsync(ct);
        }

        public async Task Update(Entry entity, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            _context.Entries.Update(entity);
            await _context.SaveChangesAsync(ct);
        }
    }
}
