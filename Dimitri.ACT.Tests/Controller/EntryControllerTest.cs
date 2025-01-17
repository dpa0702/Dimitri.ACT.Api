﻿using Dimitri.ACT.Api.Controllers;
using Dimitri.ACT.Api.Services.Interfaces;
using Dimitri.ACT.Core.DTOs;
using Dimitri.ACT.Tests.Entities.Mock;
using Moq;

namespace Dimitri.ACT.Tests.Controller
{
    [TestClass]
    public class EntryControllerTest
    {
        EntryController? entryController;
        private Mock<IEntryService> _mockEntryService;

        [TestInitialize]
        public void Start()
        {
            _mockEntryService = new Mock<IEntryService>();

            entryController = new EntryController(_mockEntryService.Object);
        }

        [TestMethod]
        public void InsertCustomer_ReturnsOk()
        {
            // Arrange
            var entryDtoMock = new EntryMockDTO();
            var entryDto = new NewEntryDTO { EntryType = entryDtoMock.EntryType, Total = entryDtoMock.Total };
            _mockEntryService.Setup(service => service.NewEntry(entryDto));

            // Act
            var result = entryController?.NewEntry(entryDto);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
