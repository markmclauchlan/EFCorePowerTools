using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using NpgsqlTypes;

namespace RevEng.Core.UlidTypeHanding;

public sealed class UlidTypeMapping : NpgsqlTypeMapping
{
    public UlidTypeMapping()
        : base("ulid", typeof(Ulid), NpgsqlDbType.Bytea)
    {
    }
    
    private UlidTypeMapping(RelationalTypeMappingParameters parameters)
        : base(parameters, NpgsqlDbType.Bytea)
    {
    }
    
    public override Expression GenerateCodeLiteral(object value)
    {
        return Expression.Constant(System.Ulid.Parse(value.ToString()));
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new UlidTypeMapping(parameters);
    }

    protected override string GenerateNonNullSqlLiteral(object value)
    {
        return System.Ulid.Parse(value.ToString()).ToString();
    }
}
