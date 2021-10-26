using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MVCDemoAppMastek.Models
{
    public class ProductDataStore
    {
        SqlConnection connection;
        IConfiguration Config;
        SqlCommand command;
        SqlDataReader reader;

        public ProductDataStore(IConfiguration _config)
        {
            Config = _config;
            connection = new SqlConnection(Config["ConnectionStrings:NorthwindConnection"]);
        }

        //write a method which returns all Products table data
        public List<Product> GetProducts()
        {
            //write ado.net connected architecture code
            //populate collection object
            //return collection object
            try
            {
                string sql = "Select productID, ProductName, UnitPrice from products";
                command = new SqlCommand(sql, connection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                reader = command.ExecuteReader();
                List<Product> productList = new List<Product>();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductId = (int)reader["ProductID"];
                    product.ProductName = reader["ProductName"].ToString();
                    product.UnitPrice = (Decimal)reader["UnitPrice"];
                    productList.Add(product);
                }
                    return productList;
                }
                catch (Exception)
                {
                throw;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }
    }


