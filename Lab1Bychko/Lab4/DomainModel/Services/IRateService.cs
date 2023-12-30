using Lab1Bychko.Lab4.DomainModel.Entities;

namespace Lab1Bychko.Lab4.DomainModel.Services
{
    public interface IRateService
    {
        Task<IEnumerable<Rate>> GetRates(DateTime date);
    }
}
