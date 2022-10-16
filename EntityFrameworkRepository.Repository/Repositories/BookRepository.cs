using Microsoft.EntityFrameworkCore;
using EntityFrameworkRepository.Core.Contracts.Repositories;
using EntityFrameworkRepository.Core.Entities;
using EntityFrameworkRepository.Core.Exceptions;
using EntityFrameworkRepository.Service.Contracts;
using EntityFrameworkRepository.Shared.DTOs;

namespace EntityFrameworkRepository.Repository.Repositories;

// public class BookRepository : IBookRepository // RepositoryBase<Book>, IBookRepository
public class BookRepository : RepositoryBase<Book>, IBookRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Book> _dbSet;

    public BookRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
        _dbSet = context.Books;
    }

    public async Task<IEnumerable<BookDetailDto>> GetAll()
    {
        var query = _dbSet
            .Select(x => new BookDetailDto
            {
                Id = x.Id,
                Title = x.Title,
                PublishedOn = x.PublishedOn,
                Image = new BookImageDto
                {
                    Url = x.Image.Url,
                    Alt = x.Image.Alt
                },
                Authors = x.AuthorsLink
                    .Select(y => new AuthorListDto
                    {
                        Id = y.Author.Id,
                        Name = y.Author.Name
                    })
            })
            .AsNoTracking();

        return await query.ToListAsync();
    }

    public async Task<BookDetailDto?> GetById(Guid id)
    {
        var query = _dbSet
            .Select(x => new BookDetailDto
            {
                Id = x.Id,
                Title = x.Title,
                PublishedOn = x.PublishedOn,
                Image = new BookImageDto
                {
                    Url = x.Image.Url,
                    Alt = x.Image.Alt
                },
                Authors = x.AuthorsLink
                    .Select(y => new AuthorListDto
                    {
                        Id = y.Author.Id,
                        Name = y.Author.Name
                    })
            });

        return await query
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task Add(Book item)
    {
        _dbSet.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Guid id, BookAddUpdateInputDto item)
    {
        var currentItem = await _dbSet
            .Include(x => x.Image)
            .Include(x => x.AuthorsLink)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (currentItem == null)
        {
            throw new EntityNotFoundException(id);
        }

        // Main update
        currentItem.Title = item.Title;
        currentItem.PublishedOn = item.PublishedOn;

        // Image update
        currentItem.Image.Url = item.Image.Url;
        currentItem.Image.Alt = item.Image.Alt;

        // Authors update
        var authorsToAdd = item.Authors
            .Where(x => currentItem.AuthorsLink.All(y => y.AuthorId != x))
            .Select(x => new BookAuthor {BookId = id, AuthorId = x});
        foreach (var authorToAdd in authorsToAdd)
        {
            currentItem.AuthorsLink.Add(authorToAdd);
        }

        var authorsToRemove = currentItem.AuthorsLink
            .Where(x => item.Authors.All(y => y != x.AuthorId))
            .ToList();
        foreach (var authorToRemove in authorsToRemove)
        {
            currentItem.AuthorsLink.Remove(authorToRemove);
        }

        _context.Entry(currentItem).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Remove(Guid id)
    {
        var item = await _dbSet
            .Include(x => x.AuthorsLink)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (item == null)
        {
            throw new EntityNotFoundException(id);
        }

        _dbSet.Remove(item);
        await _context.SaveChangesAsync();
    }
}