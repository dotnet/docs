//<Snippet1>
using System;
using System.Data.SqlClient;

namespace Samples
{
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
}
//</Snippet1>

