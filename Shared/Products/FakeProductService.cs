namespace RealisticExample.Shared.Products;

using Bogus;
public class FakeProductService : IProductService
{
    private readonly List<ProductDto.Index> _products = new();
    public FakeProductService()
    {

        int productId = 1;

        _products.Add(new ProductDto.Index
        {
            Id = productId++,
            Price = 20,
            Name = "Plastic zak"
        });

        _products.Add(new ProductDto.Index
        {
            Id = productId++,
            Price = 3,
            Name = "Orval (flesje)"
        });

    }

    public Task<IEnumerable<ProductDto.Index>> GetIndexAsync()
    {
        return Task.FromResult(_products.AsEnumerable());
    }
}