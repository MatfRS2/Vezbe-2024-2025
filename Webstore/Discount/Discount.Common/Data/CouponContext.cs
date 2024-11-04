using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Discount.Common.Data;

public class CouponContext : ICouponContext
{
    private readonly IConfiguration _configuration;


    public CouponContext(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public NpgsqlConnection GetConnection()
    {
        var conStr = _configuration.GetValue<string>("DatabaseString:ConnectionString");
        return new NpgsqlConnection(conStr);
    }
}