using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.Booking;

namespace Tarker.Booking.Persistence.Configuration
{
    public class BookingConfiguration
    {
        public BookingConfiguration(EntityTypeBuilder<BookingEntity> entityTypeBuilder) 
        {
            entityTypeBuilder.HasKey(b => b.BookingId);
            entityTypeBuilder.Property(b => b.RegisterDate).IsRequired();
            entityTypeBuilder.Property(b => b.Code).IsRequired();
            entityTypeBuilder.Property(b => b.Type).IsRequired();
            entityTypeBuilder.Property(b => b.UserId).IsRequired();
            entityTypeBuilder.Property(b => b.CustomerId).IsRequired();

            entityTypeBuilder.HasOne(b => b.User)
                .WithMany(b => b.Bookings)
                .HasForeignKey(b => b.UserId);

            entityTypeBuilder.HasOne(b => b.Customer)
                .WithMany(b => b.Bookings)
                .HasForeignKey(b => b.CustomerId);
        }
    }
}
