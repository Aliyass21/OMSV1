using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMSV1.Domain.Entities.DamagedDevices;

namespace OMSV1.Infrastructure.Configurations;

public class DamagedDeviceConfiguration : IEntityTypeConfiguration<DamagedDevice>
{
    public void Configure(EntityTypeBuilder<DamagedDevice> builder)
    {
        builder.HasKey(dd => dd.Id); // Assuming `Entity` has a primary key `Id`.

        builder.Property(dd => dd.SerialNumber)
            .IsRequired()
            .HasMaxLength(100); // Adjust length as needed.

        builder.Property(dd => dd.Date)
            .IsRequired();

        builder.Property(dd => dd.DamagedDeviceTypeId)
            .IsRequired();

        builder.Property(dd => dd.DeviceTypeId)
            .IsRequired();

        builder.Property(dd => dd.OfficeId)
            .IsRequired();

        builder.Property(dd => dd.GovernorateId)
            .IsRequired();

        builder.Property(dd => dd.ProfileId)
            .IsRequired();

        // Relationships
        builder.HasOne(dd => dd.DamagedType)
            .WithMany() // Adjust navigation property in `DamagedDeviceType` if necessary.
            .HasForeignKey(dd => dd.DamagedDeviceTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(dd => dd.DeviceType)
            .WithMany() // Adjust navigation property in `DeviceType` if necessary.
            .HasForeignKey(dd => dd.DeviceTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(dd => dd.Governorate)
            .WithMany()
            .HasForeignKey(dd => dd.GovernorateId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(dd => dd.Office)
            .WithMany()
            .HasForeignKey(dd => dd.OfficeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Attachments relationship (One-to-Many)
        // builder.Navigation(dd => dd.AttachmentCUs)
        //     .UsePropertyAccessMode(PropertyAccessMode.Field); // For private backing field.

        // Table Mapping
        builder.ToTable("DamagedDevices");
    }
}