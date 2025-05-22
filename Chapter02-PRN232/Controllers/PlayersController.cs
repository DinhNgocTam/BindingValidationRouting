using AutoMapper;
using BusinessObjects;
using DataAccess.Player;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Chapter02_PRN232.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public PlayersController(IPlayerService playerService, IMapper mapper)
        {
            _playerService = playerService;
            _mapper = mapper;
        }

        // GET: api/Players
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var players = await _playerService.GetAllAsync();
            var response = _mapper.Map<IEnumerable<GetPlayerResponse>>(players);
            return Ok(response);
        }

        // GET: api/Players/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var player = await _playerService.GetByIdAsync(id);
            if (player == null) return NotFound();

            var response = _mapper.Map<GetPlayerDetailResponse>(player);
            return Ok(response);
        }

        // POST: api/Players
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePlayerRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var player = _mapper.Map<Player>(request);
            await _playerService.AddAsync(player);

            var response = _mapper.Map<GetPlayerResponse>(player);
            return CreatedAtAction(nameof(GetById), new { id = player.PlayerId }, response);
        }

        // PUT: api/Players/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePlayerRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingPlayer = await _playerService.GetByIdAsync(id);
            if (existingPlayer == null) return NotFound();

            _mapper.Map(request, existingPlayer);
            await _playerService.UpdateAsync(existingPlayer);

            return NoContent();
        }

        // DELETE: api/Players/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var player = await _playerService.GetByIdAsync(id);
            if (player == null) return NotFound();

            await _playerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
