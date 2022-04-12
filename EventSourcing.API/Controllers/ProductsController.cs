using EventSourcing.API.Commands;
using EventSourcing.API.DTOs;
using EventSourcing.API.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcing.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public ProductsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllListByUserId(int userId)
        {
            return Ok(await _mediatr.Send(new GetProductAllListByUserIdQuery { UserId = userId }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {
            await _mediatr.Send(new CreateProductCommand
            {
                CreateProductDto = createProductDto
            });

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> ChangeName(ChangeProductNameDto changeProductNameDto)
        {
            await _mediatr.Send(new ChangeProductNameCommand
            {
                ChangeProductNameDto = changeProductNameDto
            });

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> ChangePrice(ChangeProductPriceDto changeProductPriceDto)
        {
            await _mediatr.Send(new ChangeProductPriceCommand
            {
                ChangeProductPriceDto = changeProductPriceDto
            });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediatr.Send(new DeleteProductCommand { Id = id });

            return NoContent();
        }
    }
}
