using Elementora.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Elementora.Web.Controllers;

public class SpeciesController : Controller
{
    private readonly ISpeciesService _speciesService;

    public SpeciesController(ISpeciesService speciesService)
    {
        _speciesService = speciesService;
    }

    //GET /Species
    public async Task<IActionResult> Index()
    {
        var species = await _speciesService.GetAllAsync();
        return View(species);
    }

    //GET /Species/Details/3
    public async Task<IActionResult> Details(int id)
    {
        var species = await _speciesService.GetByIdAsync(id);

        if(species is null)
        {
            return NotFound();
        }
        return View(species);
    }

}
