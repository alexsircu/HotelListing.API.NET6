using HotelListing.API.Data;

namespace HotelListing.API.Contracts
{
    public interface ICountriesRepository : IGenericRepository<Country>
    {
        Task<TResult> GetDetails<TResult>(int id);
    }
}
