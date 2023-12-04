using Entities;
using Repositories;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
     public class RatingService: IRatingService
    {
        private readonly IRatingRepository ratingRepository;

        public RatingService(IRatingRepository _ratingRepository)
        {
            ratingRepository = _ratingRepository;
        }


        public async Task<Rating> AddRating(Rating rating)
        {
            return await ratingRepository.AddRating(rating);
        }
    }
}
