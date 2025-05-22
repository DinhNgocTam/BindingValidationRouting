using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        // Lấy tất cả Player
        Task<IEnumerable<Player>> GetAllAsync();

        // Lấy Player theo ID
        Task<Player> GetByIdAsync(int id);

        // Thêm Player mới
        Task AddAsync(Player player);

        // Cập nhật Player
        Task UpdateAsync(Player player);

        // Xóa Player theo ID
        Task DeleteAsync(int id);
    }
}
