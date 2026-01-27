using E_Commerce_Platform_Ass1.Data.Database;
using E_Commerce_Platform_Ass1.Data.Database.Entities;
using E_Commerce_Platform_Ass1.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Platform_Ass1.Data.Repositories
{
    public class EKycRepository : IEKycRepository
    {
        private readonly ApplicationDbContext _context;

        public EKycRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(EKycVerification entity)
        {
            await _context.EKycVerifications.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsUserVerifiedAsync(Guid userId)
        {
            return await _context.EKycVerifications
            .AnyAsync(x => x.UserId == userId && x.Status == "VERIFIED");
        }
    }
}
