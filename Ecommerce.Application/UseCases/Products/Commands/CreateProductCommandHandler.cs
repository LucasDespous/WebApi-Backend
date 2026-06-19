using Ecommerce.Application.DTOs;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.UseCases.Products.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponseDto?>
{
    private readonly IProductRepository _products;
    private readonly ICategoryRepository _categories;

    public CreateProductCommandHandler(IProductRepository products, ICategoryRepository categories)
    {
        _products = products;
        _categories = categories;
    }

    public async Task<ProductResponseDto?> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if (await _categories.GetByIdAsync(request.Product.CategoryId, cancellationToken) is null)
        {
            return null;
        }

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Product.Name,
            Description = request.Product.Description,
            Price = request.Product.Price,
            Stock = request.Product.Stock,
            CategoryId = request.Product.CategoryId
        };

        await _products.AddAsync(product, cancellationToken);
        var created = await _products.GetByIdAsync(product.Id, cancellationToken);
        return created is null ? null : ToResponse(created);
    }

    private static ProductResponseDto ToResponse(Product product)
        => new(product.Id, product.Name, product.Description, product.Price, product.Stock, product.CategoryId, product.Category?.Name ?? string.Empty);
}
