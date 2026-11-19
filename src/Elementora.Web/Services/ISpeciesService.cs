using Elementora.Web.Data.Entities;

namespace Elementora.Web.Services;

public interface ISpeciesService
{
    Task<IReadOnlyList<Species>> GetAllAsync();
    Task<Species?> GetByIdAsync(int id);
}