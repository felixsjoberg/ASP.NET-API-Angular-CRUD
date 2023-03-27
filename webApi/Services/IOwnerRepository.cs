using webApi.Models;

namespace webApi.Services;
public interface IOwnerRepository
{
    Task<IEnumerable<Owner>> GetOwners();
    Task<Owner> GetOwner(int ownerId);
    Task<Owner> GetOwnerWithDetails(int ownerId);
    void CreateOwner(Owner owner);
    void UpdateOwner(Owner dbOwner, Owner owner);
    void DeleteOwner(Owner owner);
}