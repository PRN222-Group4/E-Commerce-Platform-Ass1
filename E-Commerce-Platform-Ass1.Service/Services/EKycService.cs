using E_Commerce_Platform_Ass1.Data.Database.Entities;
using E_Commerce_Platform_Ass1.Data.Repositories.Interfaces;
using E_Commerce_Platform_Ass1.Service.Services.IServices;
using Microsoft.AspNetCore.Http;

namespace E_Commerce_Platform_Ass1.Service.Services
{
    public class EKycService : IEkycService
    {
        private readonly IVnptEKycService _vnptEKycService;
        private readonly IEKycRepository _eKycRepository;

        public EKycService(IVnptEKycService vnptEKycService, IEKycRepository eKycRepository)
        {
            _vnptEKycService = vnptEKycService;
            _eKycRepository = eKycRepository;
        }

        public async Task<bool> IsUserVerifiedAsync(Guid userId)
        {
            return await _eKycRepository.IsUserVerifiedAsync(userId);
        }

        public async Task<bool> VerifyAndSaveAsync(Guid userId, IFormFile front, IFormFile back)
        {
            var result = await _vnptEKycService.VerifyAsync(front, back);
            if (!result.IsSuccess)
            {
                return false;
            }

            var entity = new EKycVerification
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                CccdNumber = result.CCCDNumber,
                FullName = result.FullName,
                FaceMatchScore = 0, // Không còn kiểm tra face match
                Liveness = true,    // Mặc định true khi bỏ qua liveness
                Status = "VERIFIED",
                CreatedAt = DateTime.Now
            };

            await _eKycRepository.AddAsync(entity);
            return true;
        }
    }
}
