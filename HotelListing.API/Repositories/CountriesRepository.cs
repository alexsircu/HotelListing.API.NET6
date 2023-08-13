using AutoMapper;
using HotelListing.API.Contracts;
using HotelListing.API.Data;
using HotelListing.API.Models.Country;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Repositories
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelListingDbContext _context;
        private readonly IMapper _mapper;
        public CountriesRepository(HotelListingDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TResult> GetDetails<TResult>(int id)
        {
            var result = await _context.Countries.Include(q => q.Hotels).FirstOrDefaultAsync(q => q.Id == id);
            var mappedResult = _mapper.Map<TResult>(result);
            return mappedResult;
        }
    }
}
