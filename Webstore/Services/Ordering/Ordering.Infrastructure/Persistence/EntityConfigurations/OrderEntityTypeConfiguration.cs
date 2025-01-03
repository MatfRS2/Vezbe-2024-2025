using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Aggregates;
using Ordering.Domain.Exceptions;

namespace Ordering.Infrastructure.Persistence.EntityConfigurations;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id).UseHiLo("orderseq");

        builder.OwnsOne(o => o.Address, a =>
        {
            a.Property<int>("OrderId").UseHiLo("orderseq");
            a.WithOwner();
        });

        var navigation = builder.Metadata.FindNavigation(nameof(Order.OrderItems))
                         ?? throw new OrderingDomainException($"No navigation property found on {nameof(Order.OrderItems)}");
        navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}