using System;
using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;

namespace DapperSample
{
    #region snippet_TypeHandlers
    abstract class SqliteTypeHandler<T> : SqlMapper.TypeHandler<T>
    {
        // Parameters are converted by Microsoft.Data.Sqlite
        public override void SetValue(IDbDataParameter parameter, T value)
            => parameter.Value = value;
    }

    class DateTimeOffsetHandler : SqliteTypeHandler<DateTimeOffset>
    {
        public override DateTimeOffset Parse(object value)
            => DateTimeOffset.Parse((string)value);
    }

    class GuidHandler : SqliteTypeHandler<Guid>
    {
        public override Guid Parse(object value)
            => Guid.Parse((string)value);
    }

    class TimeSpanHandler : SqliteTypeHandler<TimeSpan>
    {
        public override TimeSpan Parse(object value)
            => TimeSpan.Parse((string)value);
    }
    #endregion

    public class AllTypes
    {
        public bool Boolean { get; set; }
        public byte Byte { get; set; }
        public byte[]? ByteArray { get; set; }
        public char Char { get; set; }
        public DateTime DateTime { get; set; }
        public DateTimeOffset DateTimeOffset { get; set; }
        public decimal Decimal { get; set; }
        public double Double { get; set; }
        public float Single { get; set; }
        public Guid Guid { get; set; }
        public int Int32 { get; set; }
        public long Int64 { get; set; }
        public sbyte SByte { get; set; }
        public short Int16 { get; set; }
        public string? String { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public uint UInt32 { get; set; }
        public ulong UInt64 { get; set; }
        public ushort UInt16 { get; set; }
    }

    class Program
    {
        static void Main()
        {
            #region snippet_AddTypeHandlers
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
            SqlMapper.AddTypeHandler(new GuidHandler());
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
            #endregion

            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            // Ensure parameters use the '@' prefix and match the case of the anonymous
            // object property
            #region snippet_Parameter
            var result = connection.ExecuteScalar(
                "SELECT @Value",
                new { Value = 1 });
            #endregion

            var allTypes = connection.QuerySingle<AllTypes>(
                @"
                    SELECT @Boolean AS Boolean,
                           @Byte AS Byte,
                           @ByteArray AS ByteArray,
                           @Char AS Char,
                           @DateTime AS DateTime,
                           @DateTimeOffset AS DateTimeOffset,
                           @Decimal AS Decimal,
                           @Double AS Double,
                           @Guid AS Guid,
                           @Int16 AS Int16,
                           @Int32 AS Int32,
                           @Int64 AS Int64,
                           @SByte AS SByte,
                           @Single AS Single,
                           @String AS String,
                           @TimeSpan AS TimeSpan,
                           @UInt16 AS UInt16,
                           @UInt32 AS UInt32,
                           @UInt64 AS UInt64
                ",
                new AllTypes
                {
                    Boolean = true,
                    Byte = 1,
                    ByteArray = new byte[] { 1 },
                    Char = 'A',
                    DateTime = DateTime.UtcNow,
                    DateTimeOffset = DateTimeOffset.UtcNow,
                    Decimal = 1m,
                    Double = 1.0,
                    Guid = Guid.NewGuid(),
                    Int16 = 1,
                    Int32 = 1,
                    Int64 = 1L,
                    SByte = 1,
                    Single = 1.0f,
                    String = "A",
                    TimeSpan = DateTime.UtcNow.TimeOfDay,
                    UInt16 = 1,
                    UInt32 = 1u,
                    UInt64 = 1uL
                });
        }
    }
}
