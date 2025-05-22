using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDBContext _context;

        public PlayerRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        // Lấy tất cả Player
        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            return await _context.Players
                .Include(p => p.PlayerInstruments) // Include để lấy dữ liệu liên quan
                .ToListAsync();
        }

        // Lấy Player theo ID với thông tin Instrument
        public async Task<Player> GetByIdAsync(int id)
        {
            return await _context.Players
                .Include(p => p.PlayerInstruments)
                .ThenInclude(pi => pi.InstrumentType) // Include để lấy thông tin Instrument liên quan
                .FirstOrDefaultAsync(p => p.PlayerId == id);
        }

        // Thêm Player mới
        public async Task AddAsync(Player player)
        {
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
        }

        // Cập nhật Player
        public async Task UpdateAsync(Player player)
        {
            var existingPlayer = await _context.Players.FindAsync(player.PlayerId);
            if (existingPlayer != null)
            {
                _context.Entry(existingPlayer).CurrentValues.SetValues(player);
                await _context.SaveChangesAsync();
            }
        }

        // Xóa Player theo ID
        public async Task DeleteAsync(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player != null)
            {
                _context.Players.Remove(player);
                await _context.SaveChangesAsync();
            }
        }
    }
}
