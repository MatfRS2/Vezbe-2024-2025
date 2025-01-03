using Npgsql;

namespace Discount.Common.Data;

public interface ICouponContext
{
    NpgsqlConnection GetConnection();
}