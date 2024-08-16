using Bogus;
using Dimitri.ACT.Core.Enums;

namespace Dimitri.ACT.Tests.Entities.Mock
{
    public class EntryMockDTO
    {
        private readonly Faker _faker;

        public int Id { get; set; }
        public EntryType EntryType { get; set; }
        public decimal Total { get; set; }
        public DateTime Timestamp { get; set; }

        public EntryMockDTO()
        {
            _faker = new Faker();
            Id = 1;
            EntryType = EntryType.Credit;
            Total = _faker.Random.Decimal(1);
            Timestamp = DateTime.UtcNow;
        }
    }
}
