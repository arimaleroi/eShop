using MVC.ViewModels.Pagination;

namespace MVC.ViewModels.CatalogViewModels;

public class IndexViewModel
{
    public IEnumerable<CatalogItem> CatalogItems { get; set; }
    public IEnumerable<SelectListItem> Categories { get; set; }
    public int? CategoryFilterApplied { get; set; }
    public PaginationInfo PaginationInfo { get; set; }
    public CatalogItem Item { get; set; }
}
