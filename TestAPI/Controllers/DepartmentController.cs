
using Microsoft.AspNetCore.Mvc;
using TestApi.Models;

namespace TestAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly DataContext context;

    public DepartmentController(DataContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Department>>> Get()
    {
        return Ok(await context.Departments.ToListAsync());
    }
}