using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{

    class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                 new Hotel
                 {
                     Id = 1,
                     Name = "Taj Dubai",
                     Address = "Downtown Burj Khalifa Street, Dubai",
                     Description = "Located in Downtown Dubai, this luxury hotel is within 1 mile (2 km) of Emaar Square, Burj Khalifa and Dubai Fountain. Dubai Aquarium & Underwater Zoo and Dubai Mall are also within 2 miles (3 km). Business Bay Station is 14 minutes by foot and Burj Khalifa - Dubai Mall Station is 15 minutes.",
                     Image = "https://www.kayak.ae/rimg/himg/63/57/9d/revato-875940-12291951-253506.jpg?width=968&height=607&crop=true",
                     ActualRent = 840,
                     DiscountedRent = 690,
                 },
                 new Hotel
                 {
                     Id = 2,
                     Name = "JW Marriott Marquis Hotel Dubai",
                     Address = "Sheikh Zayed Road, Business Bay Dubai 121000 United Arab Emirates, Dubai 121000",
                     Description = "This family-friendly Dubai hotel is located near the airport, within 3 mi (5 km) of Burj Khalifa and Dubai Mall. Wild Wadi Water Park and Ski Dubai are also within 9 mi (15 km). Business Bay Station is 10 minutes by foot and Burj Khalifa - Dubai Mall Station is 28 minutes.",
                     Image = "https://www.kayak.ae/rimg/himg/e2/49/25/leonardo-67279111-dxbjw-arabic-wedding-4905-hor-clsc_O-318881.jpg?width=968&height=607&crop=true",
                     ActualRent = 520,
                     DiscountedRent = 415,
                 },
                 new Hotel
                 {
                     Id = 3,
                     Name = "Sheraton Grand Hotel, Dubai",
                     Address = "3 Sheikh Zayed Road, Dubai",
                     Description = "Located in Trade Center, this luxury hotel is 0.6 mi (1 km) from Dubai World Trade Centre, and within 3 mi (5 km) of Dubai Mall and Burj Khalifa. Dubai Creek and City Centre Deira are also within 6 mi (10 km). World Trade Centre Station is 11 minutes by foot and Al Jafiliya Station is 15 minutes.",
                     Image = "https://www.kayak.ae/rimg/himg/c6/66/b1/leonardo-125231316-dxbgh-suite-0255-hor-clsc_O-385966.jpg?width=968&height=607&crop=true",
                     ActualRent = 720,
                     DiscountedRent = 578,
                 });
        }
    }
}
