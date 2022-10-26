using EntityFrameworkRepository.Core.Contracts.Services.Persistence;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkRepository.Core.Exceptions;
using EntityFrameworkRepository.Service.Contracts;
using EntityFrameworkRepository.Shared.DTOs;

namespace EntityFrameworkRepository.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _itemService;

    public AuthorsController(IServiceManager service)
    {
        _itemService = service.AuthorService;
    }

    [HttpGet]
    public async Task<IEnumerable<AuthorDto>> Get()
    {
        return await _itemService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorDto>> GetById(Guid id)
    {
        var item = await _itemService.GetById(id);

        if (item == null)
        {
            return NotFound();
        }

        return item;
    }

    [HttpPost]
    public async Task<ActionResult<AuthorDto>> Add(AuthorAddUpdateInputDto item)
    {
        var newItem = await _itemService.Add(item);

        return CreatedAtAction(nameof(GetById), new {id = newItem.Id}, newItem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, AuthorAddUpdateInputDto item)
    {
        try
        {
            await _itemService.Update(id, item);
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
            await _itemService.Remove(id);
        }
        catch (EntityNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}