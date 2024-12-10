using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Persistence.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<UserEntity> entityTypeBuilder)            
        {
            entityTypeBuilder.HasKey(u => u.UserId);
            entityTypeBuilder.Property(u => u.FirstName).IsRequired();
            entityTypeBuilder.Property(u => u.LastName).IsRequired();
            entityTypeBuilder.Property(u => u.UserName).IsRequired();
            entityTypeBuilder.Property(u => u.Password).IsRequired();

            entityTypeBuilder.HasMany(u => u.Bookings)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);

        }
    }
}
