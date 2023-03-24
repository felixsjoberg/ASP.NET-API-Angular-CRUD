using webApi.Models;

namespace webApi.Services;
public interface IOwnerRepository
{
    Task<IEnumerable<Owner>> GetOwners();
    Task<Owner> GetOwner(int ownerId);
    Task<Owner> GetOwnerOfAccount(int accountId);
    void CreateOwner(Owner owner);
    void UpdateOwner(Owner owner);
    void DeleteOwner(Owner owner);
}