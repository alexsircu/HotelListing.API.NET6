using HotelListing.API.Data;

namespace HotelListing.API.Contracts
{
    public interface IHotelsRepository : IGenericRepository<Hotel>
    {
        Task<TResult> GetDetails<TResult>(int id);
    }
}
