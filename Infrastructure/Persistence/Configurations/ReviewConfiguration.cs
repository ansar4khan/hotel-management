using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasData(
                 new Review { Id = 1, HotelId = 1, Rating = 5 },
                 new Review { Id = 2, HotelId = 1, Rating = 4 },
                 new Review { Id = 3, HotelId = 1, Rating = 5 },
                 new Review { Id = 4, HotelId = 1, Rating = 4 },

                 new Review { Id = 5, HotelId = 2, Rating = 3 },
                 new Review { Id = 6, HotelId = 2, Rating = 4 },

                 new Review { Id = 7, HotelId = 3, Rating = 5 },
                 new Review { Id = 8, HotelId = 3, Rating = 3 },
                 new Review { Id = 9, HotelId = 3, Rating = 4 }
                 );
        }
    }
}
