using Entities;

namespace Services
{
    public interface IRatingService
    {

        public Task<Rating> AddRating(Rating rating);
    }
}