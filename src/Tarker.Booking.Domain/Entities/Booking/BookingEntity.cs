using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Domain.Entities.Booking
{
    public class BookingEntity
    {
        public int BookingId { get; set; }
        public DateTime RegisterDate { get; set; }
        public string? Code { get; set; }
        public string? Type { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public UserEntity? User { get; set; }
        public CustomerEntity? Customer { get; set; }
    }
}
