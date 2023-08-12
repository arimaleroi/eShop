using System.Threading;
using Catalog.Host.Data.Entities;
using Moq;

namespace Catalog.UnitTests.Services
{
    public class CatalogItemServiceTest
    {
        private readonly ICatalogItemService _catalogItemService;
        private readonly Mock<ICatalogItemRepository> _catalogItemRepository;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<CatalogItemService>> _logger;

        private readonly CatalogItem _testItem = new CatalogItem()
        {
            Id = 1,
            Title = "Title",
            Description = "Description",
            Price = 100,
            PictureFileName = "1.png",
            CatalogCategoryId = 1,
        };

        public CatalogItemServiceTest()
        {
            _catalogItemRepository = new Mock<ICatalogItemRepository>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            _logger = new Mock<ILogger<CatalogItemService>>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(It.IsAny<CancellationToken>())).ReturnsAsync(dbContextTransaction.Object);

            _catalogItemService = new CatalogItemService(_dbContextWrapper.Object, _logger.Object, _catalogItemRepository.Object);
        }

        [Fact]
        public async Task AddItemAsync_Success()
        {
            int? testResult = 1;

            _catalogItemRepository.Setup(x => x.AddItemAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<int>(),
                It.IsAny<string>()))
                .ReturnsAsync(testResult);

            var result = await _catalogItemService.AddItemAsync(
                _testItem.Title,
                _testItem.Description,
                _testItem.Price,
                _testItem.CatalogCategoryId,
                _testItem.PictureFileName);

            result.Should().Be(testResult);
        }

        [Fact]
        public async Task AddItemAsync_Failed()
        {
            int? testResult = null;

            _catalogItemRepository.Setup(x => x.AddItemAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<int>(),
                It.IsAny<string>()))
                .ReturnsAsync(testResult);

            var result = await _catalogItemService.AddItemAsync(
                _testItem.Title,
                _testItem.Description,
                _testItem.Price,
                _testItem.CatalogCategoryId,
                _testItem.PictureFileName);

            result.Should().Be(testResult);
        }

        [Fact]
        public async Task DeleteItemAsync_Success()
        {
            int? testResult = 1;

            _catalogItemRepository.Setup(x => x.DeleteItemAsync(
                It.IsAny<int>()))
                .ReturnsAsync(testResult);

            var result = await _catalogItemService.DeleteItemAsync(
                _testItem.Id);

            result.Should().Be(testResult);
        }

        [Fact]
        public async Task DeleteItemAsync_Failed()
        {
            int? testResult = null;

            _catalogItemRepository.Setup(x => x.DeleteItemAsync(
                It.IsAny<int>()))
                .ReturnsAsync(testResult);

            var result = await _catalogItemService.DeleteItemAsync(
                _testItem.Id);

            result.Should().Be(testResult);
        }

        [Fact]
        public async Task UpdateItemAsync_Success()
        {
            int? testResult = 1;

            _catalogItemRepository.Setup(x => x.UpdateItemAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<int>(),
                It.IsAny<string>()))
                .ReturnsAsync(testResult);

            var result = await _catalogItemService.UpdateItemAsync(
                _testItem.Id,
                _testItem.Title,
                _testItem.Description,
                _testItem.Price,
                _testItem.CatalogCategoryId,
                _testItem.PictureFileName);

            result.Should().Be(testResult);
        }

        [Fact]
        public async Task UpdateItemAsync_Failed()
        {
            int? testResult = null;

            _catalogItemRepository.Setup(x => x.UpdateItemAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<int>(),
                It.IsAny<string>()))
                .ReturnsAsync(testResult);

            var result = await _catalogItemService.UpdateItemAsync(
                _testItem.Id,
                _testItem.Title,
                _testItem.Description,
                _testItem.Price,
                _testItem.CatalogCategoryId,
                _testItem.PictureFileName);

            result.Should().Be(testResult);
        }

        [Fact]
        public async Task GetItemAsync_Success()
        {
            int expectedId = 1;
            CatalogItem expectedItem = new CatalogItem { Id = expectedId, Title = "Title", Description = "Description" };
            _catalogItemRepository.Setup(x => x.GetItemId(expectedId)).ReturnsAsync(expectedItem);

            var result = await _catalogItemService.GetItemAsync(expectedId);

            result.Should().Be(expectedItem);
        }

        [Fact]
        public async Task GetItemAsync_Failed()
        {
            int expectedId = 1;
            CatalogItem? expectedItem = null;
            _catalogItemRepository.Setup(x => x.GetItemId(expectedId)).ReturnsAsync(expectedItem);

            var result = await _catalogItemService.GetItemAsync(expectedId);

            result.Should().Be(expectedItem);
        }
    }
}
