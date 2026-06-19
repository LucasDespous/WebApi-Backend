using Ecommerce.Application.DTOs;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.UseCases.Products.Queries;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IReadOnlyCollection<ProductResponseDto>>
{
    private readonly IProductRepository _products;

    public GetAllProductsQueryHandler(IProductRepository products)
    {
        _products = products;
    }

    public async Task<IReadOnlyCollection<ProductResponseDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        => (await _products.GetAllAsync(cancellationToken)).Select(ToResponse).ToList();

    private static ProductResponseDto ToResponse(Product product)
        => new(product.Id, product.Name, product.Description, product.Price, product.Stock, product.CategoryId, product.Category?.Name ?? string.Empty);
}
