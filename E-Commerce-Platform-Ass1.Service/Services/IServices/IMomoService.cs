namespace E_Commerce_Platform_Ass1.Service.Services.IServices
{
    public interface IMomoService
    {
        Task<string> CreatePaymentAsync(long amount, string orderInfo);
    }
}
