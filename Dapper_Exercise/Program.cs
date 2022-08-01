using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Dapper_Exercise;
//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

var repo = new DepartmentRepository(conn);

repo.InsertDepartment(newDepartment);

var departments = repo.GetAllDepartments();

foreach (var department in departments)
{
    Console.WriteLine(department.DepartmentID);
    Console.WriteLine(department.Name);
}

var repoP = new DapperProductRepository(conn);

var products = repoP.GetAllProducts();
foreach (var product in products)
{
    Console.WriteLine(product.Name, product.Price, product.CategoryID);
}

Console.WriteLine("What is the name of your product?");
var nameP = Console.ReadLine();
Console.WriteLine("What is the price of your product?");
double priceP = double.Parse(Console.ReadLine());
Console.WriteLine("What is the CategoryID of your product");
int CategoryIDp = int.Parse(Console.ReadLine());

repoP.CreateProduct(nameP, priceP, CategoryIDp);
var newListOfProducts = repoP.GetAllProducts();
foreach( var product in newListOfProducts)
{
    Console.WriteLine(product.Name, product.Price, product.CategoryID);
}