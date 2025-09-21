using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulCBS.Data.Repositories.Context
{
    public class DapperContext
    {
        private readonly NpgsqlDataSource _dataSource;

        public DapperContext(IConfiguration configuration)
        {
            var cs = configuration.GetConnectionString("DefaultConnection");

            // DataSource builder ile NTS’yi aktifleştir
            var builder = new NpgsqlDataSourceBuilder(cs);
            builder.UseNetTopologySuite();         
            _dataSource = builder.Build();
        }

        public IDbConnection CreateConnection()
            => _dataSource.CreateConnection();
    }
}
