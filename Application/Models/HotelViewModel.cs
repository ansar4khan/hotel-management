using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class HotelViewModel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal ActualRent { get; set; }
        public decimal DiscountedRent { get; set; }
        public double Rating { get; set; }
        public int NoOfReviews { get; set; }
    }
}
