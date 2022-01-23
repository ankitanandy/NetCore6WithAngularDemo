
using Microsoft.AspNetCore.Mvc;
using TestApi.Models;
using System.Linq;

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

    [HttpPost]
    public async Task<ActionResult<List<Department>>> Add(Department department)
    {
        this.context.Departments.Add(department);
        await this.context.SaveChangesAsync();

        return Ok(await context.Departments.ToListAsync());
    }

    [HttpPut]
    public async Task<ActionResult<List<Department>>> Update(Department request)
    {
        var department= this.context.Departments.FirstOrDefault(d=>d.DepartmentId==request.DepartmentId);
        if(department ==null)
            return BadRequest("Department not found");
            department.DepartmentName=request.DepartmentName;
        return Ok(await context.Departments.ToListAsync());
    }

    [HttpDelete]
    public async Task<ActionResult<List<Department>>> Delete()
    {
        return Ok(await context.Departments.ToListAsync());
    }
}