namespace RealisticExample.Shared.Products;

using Bogus;
public class BogusProductService : IProductService
{
    private readonly List<ProductDto.Detail> _products = new();
    //private readonly List<ProductDto.Index> _productsIndex = new();
    public BogusProductService()
    {
        _products = CreateProductDetail();
        //_productsIndex = CreateProductIndex();
    }

    private List<ProductDto.Detail> CreateProductDetail()
    {
        var productIds = 0;
        var productFaker = new Faker<ProductDto.Detail>("en")
            .UseSeed(1337) // Always return the same products
            .RuleFor(x => x.Id, _ => ++productIds)
            .RuleFor(x => x.Name, f => f.Commerce.ProductName())
            .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
            .RuleFor(x => x.Image, f => f.Internet.Avatar())
            .RuleFor(x => x.Price, f => f.Random.Decimal(0, 250));
        return productFaker.Generate(25);
    }

    //private List<ProductDto.Index> CreateProductIndex()
    //{
    //    List<ProductDto.Index> result = new();
    //    foreach (var item in _products)
    //    {
    //        result.Add(new ProductDto.Index
    //        {
    //            Id = item.Id,
    //            Name = item.Name,
    //            Price = item.Price,
    //        });
    //    }
    //    return result;
    //}

    public Task<ProductDto.Detail> GetDetailAsync(int productId)
    {
        return Task.FromResult(_products.Single(x => x.Id == productId));
    }

    public Task<IEnumerable<ProductDto.Index>> GetIndexAsync()
    {
        return Task.FromResult(_products.Select(x => new ProductDto.Index
        {
            Id = x.Id,
            Name = x.Name,
            Price = x.Price
        }));
    }
}