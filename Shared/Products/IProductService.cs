namespace RealisticExample.Shared.Products;

public interface IProductService
{
    Task<IEnumerable<ProductDto.Index>> GetIndexAsync();
    Task<ProductDto.Detail> GetDetailAsync(int productId);
}

