using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.Booking;

namespace Tarker.Booking.Domain.Entities.Customer
{
    public class CustomerEntity
    {
        public int CustomerId { get; set; }
        public string? FullName { get; set; }
        public string? DocumentNumber { get; set; }
        public ICollection<BookingEntity>? Bookings { get; set; }
    }
}
