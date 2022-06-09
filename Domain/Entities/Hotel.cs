using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public decimal ActualRent { get; set; }
        public decimal DiscountedRent { get; set; }
        public string Image { get; set; }
        public List<Facility> Facilities { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
