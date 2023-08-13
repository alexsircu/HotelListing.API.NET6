using AutoMapper;
using HotelListing.API.Contracts;
using HotelListing.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Repositories
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        private readonly HotelListingDbContext _context;
        private readonly IMapper _mapper;
        public HotelsRepository(HotelListingDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TResult> GetDetails<TResult>(int id)
        {
            var result = await _context.Hotels.FirstOrDefaultAsync(q => q.Id == id);
            var mappedResult = _mapper.Map<TResult>(result);
            return mappedResult;
        }
    }
}
