using System;
using System.Collections.Generic;
using System.Text;

namespace Walle_WEB.Data
{
    public class SqlConfiguration
    {
        public SqlConfiguration(string connectionString) => ConnectionString = connectionString;

        public string ConnectionString { get; }
    }
}
