using Bogus;
using Dimitri.ACT.Core.DTOs;
using Dimitri.ACT.Tests.Entities.Mock;

namespace Dimitri.ACT.Tests.Entities
{
    [TestClass]
    public class EntryTest
    {
        private readonly Faker _faker;

        public EntryTest()
        {
            _faker = new Faker();
        }

        [TestMethod]
        public void ValidateInsertEntry_ShouldReturnSuccess()
        {
            // Arrange
            var entryDtoMock = new EntryMockDTO();

            // Act
            var entryDto = new NewEntryDTO { EntryType = entryDtoMock.EntryType, Total = entryDtoMock.Total };

            // Assert
            Assert.AreEqual(entryDtoMock.EntryType, entryDto.EntryType);
            Assert.AreEqual(entryDtoMock.Total, entryDto.Total);
        }
    }
}
