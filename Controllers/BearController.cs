using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace SignalRWebpack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BearController : ControllerBase
{
    private readonly ILogger<BearController> _logger;
    private readonly Context _context;
    public BearController(ILogger<BearController> logger, Context context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bear>>> Get()
    {
        return await _context.Bears.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Bear>> GetOne(int id)
    {
        var oneBear = await _context.Bears.FirstOrDefaultAsync(b => b.Id == id);
        if(oneBear == null)
        {
            return NotFound();
        }
        return Ok(oneBear);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> ChangeBear(int id, float longitude, float latitude) {
        var Bear = await _context.Bears.FirstOrDefaultAsync(p => p.Id == id);
        
        if(Bear == null) {
            return NotFound();
        }
        
        if(!ModelState.IsValid) {
            return BadRequest();
        }
        
        Bear.latitude = latitude;
        Bear.longitude = longitude;
        
        await _context.SaveChangesAsync();
        
        return Ok(Bear);
    }

    [HttpPost]
    public async Task<ActionResult<Bear>> PostBear(Bear bear)
    {
        bear.Date = DateTime.Now;
        if (!ModelState.IsValid) 
        {
            return BadRequest();
        }
        _context.Bears.Add(bear);

        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetOne), new { id = bear.Id }, bear );
    }
}