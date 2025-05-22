using BusinessObjects;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        // Lấy tất cả Player
        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            return await _playerRepository.GetAllAsync();
        }

        // Lấy Player theo ID
        public async Task<Player> GetByIdAsync(int id)
        {
            return await _playerRepository.GetByIdAsync(id);
        }

        // Thêm Player mới
        public async Task AddAsync(Player player)
        {
            player.JoinedDate = DateTime.Now; // Gán giá trị JoinedDate mặc định
            await _playerRepository.AddAsync(player);
        }

        // Cập nhật Player
        public async Task UpdateAsync(Player player)
        {
            await _playerRepository.UpdateAsync(player);
        }

        // Xóa Player theo ID
        public async Task DeleteAsync(int id)
        {
            await _playerRepository.DeleteAsync(id);
        }
    }
}
