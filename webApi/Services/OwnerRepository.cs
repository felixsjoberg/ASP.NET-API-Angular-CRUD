using Microsoft.EntityFrameworkCore;
using webApi.Data;
using webApi.Models;

namespace webApi.Services;

public class OwnerRepository : IOwnerRepository
{

    private readonly DataContext _repositoryContext;
    public OwnerRepository(DataContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }

    public async Task<Owner?> GetOwner(int ownerId)
    {
        return await _repositoryContext.Owners.FindAsync(ownerId);
    }
    public async Task<IEnumerable<Owner>> GetOwners()
    {
        return await _repositoryContext.Owners.ToListAsync();
    }

    public async Task<Owner> GetOwnerWithDetails(int ownerId)
    {
        return await _repositoryContext.Owners
            .Include(owner => owner.Accounts)
            .FirstOrDefaultAsync(owner => owner.Id == ownerId);

    }

    public void CreateOwner(Owner owner)
    {
        _repositoryContext.Owners.Add(owner);
        _repositoryContext.SaveChanges();
    }

    public void UpdateOwner(Owner dbOwner,Owner owner)
    {
        dbOwner.Name = owner.Name;
        dbOwner.Address = owner.Address;
        dbOwner.DateOfBirth = owner.DateOfBirth;
        
        _repositoryContext.Owners.Update(dbOwner);
        _repositoryContext.SaveChanges();
    }

    public void DeleteOwner(Owner owner)
    {
        _repositoryContext.Owners.Remove(owner);
        _repositoryContext.SaveChanges();
    }


}
