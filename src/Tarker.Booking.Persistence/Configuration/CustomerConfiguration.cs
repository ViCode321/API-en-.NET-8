using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Persistence.Configuration
{
    public class CustomerConfiguration
    {
        public CustomerConfiguration(EntityTypeBuilder<CustomerEntity> entityTypeBuilder) 
        {
            entityTypeBuilder.HasKey(c => c.CustomerId);
            entityTypeBuilder.Property(c => c.FullName).IsRequired();
            entityTypeBuilder.Property(c => c.DocumentNumber).IsRequired();

            entityTypeBuilder.HasMany(u => u.Bookings)
                .WithOne(u => u.Customer)
                .HasForeignKey(u => u.CustomerId);

        }
    }
}
