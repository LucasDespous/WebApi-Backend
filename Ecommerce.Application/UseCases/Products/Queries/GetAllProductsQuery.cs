using Ecommerce.Application.DTOs;
using MediatR;

namespace Ecommerce.Application.UseCases.Products.Queries;

public record GetAllProductsQuery : IRequest<IReadOnlyCollection<ProductResponseDto>>;
