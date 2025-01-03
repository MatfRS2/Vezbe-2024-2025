using Ordering.Domain.Common;

namespace Ordering.Domain.ValueObjects;

public class Address: ValueObject
{
    public Address(string street, string city, string state, string country, string zipCode, string emailAddress)
    {
        Street = street ?? throw new ArgumentNullException(nameof(street));
        City = city ?? throw new ArgumentNullException(nameof(city));
        State = state ?? throw new ArgumentNullException(nameof(state));
        Country = country ?? throw new ArgumentNullException(nameof(country));
        ZipCode = zipCode ?? throw new ArgumentNullException(nameof(zipCode));
        EmailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
    }

    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }
    public string EmailAddress { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return State;
        yield return Country;
        yield return ZipCode;
        yield return EmailAddress;
    }
}