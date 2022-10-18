using Microsoft.AspNetCore.Mvc;
using EntityFrameworkRepository.Core.Exceptions;
using EntityFrameworkRepository.Service.Contracts;
using EntityFrameworkRepository.Shared.DTOs;

namespace EntityFrameworkRepository.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewsController : ControllerBase
{
    private readonly IServiceManager _service;

    public ReviewsController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<ReviewDto>> Get()
    {
        return await _service.ReviewService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReviewDto>> GetById(Guid id)
    {
        var item = await _service.ReviewService.GetById(id);

        if (item == null)
        {
            return NotFound();
        }

        return item;
    }
    
    [HttpPost]
    public async Task<ActionResult<ReviewDto>> Add(ReviewAddUpdateInputDto item)
    {
        var newItem = await _service.ReviewService.Add(item);

        return CreatedAtAction(nameof(GetById), new {id = newItem.Id}, newItem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, ReviewAddUpdateInputDto item)
    {
        try
        {
            await _service.ReviewService.Update(id, item);
        }
        catch (EntityNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        try
        {
            await _service.ReviewService.Remove(id);
        }
        catch (EntityNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}