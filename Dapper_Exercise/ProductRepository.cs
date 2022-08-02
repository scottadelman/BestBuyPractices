using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Dapper_Exercise;
using Dapper;
using System.Data.Common;
using DocumentFormat.OpenXml.Drawing.Diagrams;

namespace Dapper_Exercise
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public void CreateProduct(string name, double price, int CategoryID)
        {
            _connection.Execute("INSERT INTO  products (name)")
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products");
        }

        public ProductRepository(IDbConnection connection) { }
        DbConnection = connection;
    }
}
