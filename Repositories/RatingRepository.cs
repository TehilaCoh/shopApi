using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AdoNet1Context _DbContext;
 

        public RatingRepository(AdoNet1Context dbContext)
        {
            _DbContext = dbContext;
        }
        public async Task<Rating> AddRating(Rating rating)
        {
            await _DbContext.Ratings.AddAsync(rating);
            await _DbContext.SaveChangesAsync();

            return rating;
        }


    }
}
