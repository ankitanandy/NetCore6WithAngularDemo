
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
}