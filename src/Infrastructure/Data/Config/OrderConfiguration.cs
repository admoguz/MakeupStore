﻿using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.BuyerId)
                .IsRequired();

            builder.OwnsOne<Address>(x => x.ShipToAddress, x =>
            {
                x.WithOwner();
                x.Property(a => a.Street).IsRequired().HasMaxLength(180);
                x.Property(a => a.City).IsRequired().HasMaxLength(100);
                x.Property(a => a.State).IsRequired().HasMaxLength(60);
                x.Property(a => a.Country).IsRequired().HasMaxLength(90);
                x.Property(a => a.ZipCode).IsRequired().HasMaxLength(18);
            });

            builder.Navigation(x => x.ShipToAddress).IsRequired();
        }
    }
}
