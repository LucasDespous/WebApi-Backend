using Ecommerce.Application.DTOs;
using MediatR;

namespace Ecommerce.Application.UseCases.Products.Commands;

public record CreateProductCommand(ProductRequestDto Product) : IRequest<ProductResponseDto?>;
