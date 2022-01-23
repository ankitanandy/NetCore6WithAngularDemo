
using Microsoft.AspNetCore.Mvc;
using TestApi.Models;

namespace TestAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly DataContext context;

    public EmployeeController(DataContext context)
    {
        this.context = context;
    }

    [HttpGet(Name = "GetAllEmployees")]
    public async Task<JsonResult> Get()
    {
        return new JsonResult(await this.context.Employees.ToListAsync());
    }

   [HttpGet("{id}")]
    public async Task<ActionResult<List<Department>>> Get(int id)
    {
        var employee = await context.Employees.FindAsync(id);
        return Ok(employee);
    }

    // [HttpPost(Name = "AddEmployee")]
    // public async Task<JsonResult> Add()
    // {
    //     context.Employees.Add()
    //     return new JsonResult(await this.context.Employees.ToListAsync());
    // }
}