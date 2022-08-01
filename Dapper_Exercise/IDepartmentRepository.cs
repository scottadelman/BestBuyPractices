using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Exercise
{
    internal interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments();

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO departments (Name) VALUES (@name);", new {name = newDepartmentName});
        }
    }
}
