using EventSourcing.API.DTOs;
using EventSourcing.API.Models;
using EventSourcing.API.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.API.Handlers
{
    public class GetProductAllListByUserIdQueryHandler : IRequestHandler<GetProductAllListByUserIdQuery, List<ProductDto>>
    {
        private readonly AppDbContext _context;
        public GetProductAllListByUserIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductDto>> Handle(GetProductAllListByUserIdQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.Where(x => x.UserId == request.UserId).ToListAsync();

            return products.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                UserId = x.UserId,
                Price = x.Price,
                Stock = x.Stock
            }).ToList();
        }
    }
}
