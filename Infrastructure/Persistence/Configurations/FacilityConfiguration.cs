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
    public class FacilityConfiguration : IEntityTypeConfiguration<Facility>
    {
        public void Configure(EntityTypeBuilder<Facility> builder)
        {
            builder.HasData(
                new Facility { Id = 1, Name = "Breakfast", HotelId = 1,IconUrl="https://cdn.static-files.com/path-to-icon.png" },
                new Facility { Id = 2, Name = "WiFi", HotelId = 1, IconUrl = "https://cdn.static-files.com/path-to-icon.png" },
                new Facility { Id = 3, Name = "SPA", HotelId = 1, IconUrl = "https://cdn.static-files.com/path-to-icon.png" },
                new Facility { Id = 4, Name = "Parking", HotelId = 1, IconUrl = "https://cdn.static-files.com/path-to-icon.png" },

                new Facility { Id = 5, Name = "Breakfast", HotelId = 2, IconUrl = "https://cdn.static-files.com/path-to-icon.png" },
                new Facility { Id = 6, Name = "WiFi", HotelId = 2, IconUrl = "https://cdn.static-files.com/path-to-icon.png" },
                new Facility { Id = 7, Name = "Parking", HotelId = 2, IconUrl = "https://cdn.static-files.com/path-to-icon.png" },

                new Facility { Id = 8, Name = "SPA", HotelId = 3, IconUrl = "https://cdn.static-files.com/path-to-icon.png" },
                new Facility { Id = 9, Name = "Parking", HotelId = 4, IconUrl = "https://cdn.static-files.com/path-to-icon.png" }
                );
        }
    }
}
