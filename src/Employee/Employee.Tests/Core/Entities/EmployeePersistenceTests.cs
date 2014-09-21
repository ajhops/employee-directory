using System;
using System.Linq;
using System.Linq.Expressions;
using Employee.Core;
using Employee.Core.Entities;
using Xunit;

namespace Employee.Tests.Core.Entities
{
    public class EmployeePersistenceTests : PersistenceTest
    {
        [Fact]
        public void Trivial_Test()
        {
            Assert.Equal(5, 5);
        }

        [Fact]
        public void Can_Insert_And_Select()
        {
            var context = new EmployeeContext();
            var employee = new Employee.Core.Entities.Employee()
            {
                Id = Guid.NewGuid(),
                FirstName = "Ralph",
                LastName = "Wiggum",
                PhonePreferred = "123-123-1234",
                PhoneAlternate = "789-789-7890",
                Department = "Sales"
            };
            SaveAndSelect(employee, e => e.Id == employee.Id);
        }
    }
}
