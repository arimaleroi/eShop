using System.Threading;
using Catalog.Host.Data.Entities;
using Catalog.Host.Services.Interfaces;
using Moq;

namespace Catalog.UnitTests.Services
{
    public class CatalogCategoryServiceTest
    {
        private readonly ICatalogCategoryService _catalogCategoryService;
        private readonly Mock<ICatalogCategoryRepository> _catalogCategoryRepository;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<CatalogCategoryService>> _logger;

        private readonly CatalogCategory _testCategory = new CatalogCategory()
        {
            Id = 1,
            Category = "Category"
        };

        public CatalogCategoryServiceTest()
        {
            _catalogCategoryRepository = new Mock<ICatalogCategoryRepository>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            _logger = new Mock<ILogger<CatalogCategoryService>>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(It.IsAny<CancellationToken>())).ReturnsAsync(dbContextTransaction.Object);

            _catalogCategoryService = new CatalogCategoryService(_dbContextWrapper.Object, _logger.Object, _catalogCategoryRepository.Object);
        }

        [Fact]
        public async Task AddCategoryAsync_Success()
        {
            int testResult = 1;

            _catalogCategoryRepository.Setup(x => x.AddCategoryAsync(
                It.IsAny<string>()))
                .ReturnsAsync(testResult);

            var result = await _catalogCategoryService.AddCategoryAsync(
                _testCategory.Category);

            result.Should().Be(testResult);
        }

        [Fact]
        public async Task AddCategoryAsync_Failed()
        {
            int? testResult = null;

            _catalogCategoryRepository.Setup(x => x.AddCategoryAsync(
                It.IsAny<string>()))
                .ReturnsAsync(testResult);

            var result = await _catalogCategoryService.AddCategoryAsync(
                _testCategory.Category);

            result.Should().Be(testResult);
        }

        [Fact]
        public async Task DeleteCategoryAsync_Success()
        {
            int testResult = 1;

            _catalogCategoryRepository.Setup(x => x.DeleteCategoryAsync(
                It.IsAny<int>()))
                .ReturnsAsync(testResult);

            var result = await _catalogCategoryService.DeleteCategoryAsync(
                _testCategory.Id);

            result.Should().Be(testResult);
        }

        [Fact]
        public async Task DeleteCategoryAsync_Failed()
        {
            int? testResult = null;

            _catalogCategoryRepository.Setup(x => x.DeleteCategoryAsync(
                It.IsAny<int>()))
                .ReturnsAsync(testResult);

            var result = await _catalogCategoryService.DeleteCategoryAsync(
                _testCategory.Id);

            result.Should().Be(testResult);
        }

        [Fact]
        public async Task UpdateCategoryAsync_Success()
        {
            int testResult = 1;

            _catalogCategoryRepository.Setup(x => x.UpdateCategoryAsync(
                It.IsAny<int>(),
                It.IsAny<string>()))
                .ReturnsAsync(testResult);

            var result = await _catalogCategoryService.UpdateCategoryAsync(
                _testCategory.Id,
                _testCategory.Category);

            result.Should().Be(testResult);
        }

        [Fact]
        public async Task UpdateCategoryAsync_Failed()
        {
            int? testResult = null;

            _catalogCategoryRepository.Setup(x => x.UpdateCategoryAsync(
                It.IsAny<int>(),
                It.IsAny<string>()))
                .ReturnsAsync(testResult);

            var result = await _catalogCategoryService.UpdateCategoryAsync(
                _testCategory.Id,
                _testCategory.Category);

            result.Should().Be(testResult);
        }

        [Fact]
        public async Task GetCategoryIdAsync_Success()
        {
            int expectedId = 1;
            CatalogCategory expectedCategory = new CatalogCategory { Id = expectedId, Category = "Category" };
            _catalogCategoryRepository.Setup(x => x.GetCategoryIdAsync(expectedId)).ReturnsAsync(expectedCategory);

            var result = await _catalogCategoryService.GetCategoryIdAsync(expectedId);

            result.Should().Be(expectedCategory);
        }

        [Fact]
        public async Task GetCategoryIdAsync_Failed()
        {
            int expectedId = 1;
            CatalogCategory? expectedCategory = null;
            _catalogCategoryRepository.Setup(x => x.GetCategoryIdAsync(expectedId)).ReturnsAsync(expectedCategory);

            var result = await _catalogCategoryService.GetCategoryIdAsync(expectedId);

            result.Should().Be(expectedCategory);
        }
    }
}
