using api_clientes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/clientes")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _config;

    public ClientesController(AppDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    [HttpGet("sp")]
    public async Task<IActionResult> GetClientesSP(int page = 1, int pageSize = 10)
    {
        var clientes = await _context.Clientes
            .FromSqlRaw("EXEC dbo.sp_GetClientes @PageNumber={0}, @PageSize={1}", page, pageSize)
            .ToListAsync();
        
        return Ok(clientes);
    }

    [HttpGet("linq")]
    public async Task<IActionResult> GetClientesLINQ(int page = 1, int pageSize = 10)
    {
        var clientes = await _context.Clientes
            .OrderBy(c => c.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return Ok(clientes);
    }
}
