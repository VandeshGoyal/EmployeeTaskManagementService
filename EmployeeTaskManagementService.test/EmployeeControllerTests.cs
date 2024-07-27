using EmployeeTaskManagementService.Controllers;
using EmployeeTaskManagementService.DataAcessLayer.Repository;
using EmployeeTaskManagementService.Models;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Xunit;

namespace EmployeeTaskManagementService.test
{
    public class EmployeeControllerTests
    {
        private readonly EmployeeController _employeeController;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeControllerTests()
        {
            _employeeRepository = Substitute.For<IEmployeeRepository>();
            _employeeController= new EmployeeController(_employeeRepository);
        }

        [Fact]
        public async Task CreateUser_PassedEmployeeDetails_returnok()
        {
            //Arrange
            EmployeeRequestDto request = new EmployeeRequestDto();

            //Act
            var result = await _employeeController.Create(request);

            //Assert
            Assert.Equals(200, ((OkObjectResult)result.Result).StatusCode);
        }
    }
}