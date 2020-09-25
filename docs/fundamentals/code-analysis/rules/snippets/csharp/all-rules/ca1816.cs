using System;
using System.Data.SqlClient;

namespace ca1816
{
    //<snippet1>
    public class DatabaseConnector : IDisposable
    {
        private SqlConnection _Connection = new SqlConnection();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);  // Violates rule
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_Connection != null)
                {
                    _Connection.Dispose();
                    _Connection = null;
                }
            }
        }
    }
    //</snippet1>
}

namespace ca1816_2
{
    //<snippet2>
    public class DatabaseConnector : IDisposable
    {
        private SqlConnection _Connection = new SqlConnection();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_Connection != null)
                {
                    _Connection.Dispose();
                    _Connection = null;
                }
            }
        }
    }
    //</snippet2>
}
