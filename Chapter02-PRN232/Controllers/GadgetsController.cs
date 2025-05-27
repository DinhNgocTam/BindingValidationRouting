using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Chapter02_PRN232.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GadgetsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public GadgetsController(ApplicationDBContext context)
        {
            _context = context;
        }

        [EnableQuery]
        [HttpGet("GadgetsOData")]
        public IActionResult Get()
        {

            return Ok(_context.Gadgets.AsQueryable());
        }
    }
}
