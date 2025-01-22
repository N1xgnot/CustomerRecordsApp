using CustomerApp.Controllers;
using CustomerApp.Data;
using CustomerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CustomerApp.Test;

public class UnitTest1
{
    //Testing POST endpoint correctly creates a new customer.
    [Fact]
    public async Task PostCustomer_ShouldCreateCustomer()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        var context = new AppDbContext(options);
        var controller = new CustomerController(context);

        var newCustomer = new Customer
        {
            FirstName = "Jane",
            LastName = "Smith",
            Email = "jane.smith@example.com"
        };

        // Act
        var result = await controller.PostCustomer(newCustomer);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var createdCustomer = Assert.IsType<Customer>(createdAtActionResult.Value);
        Assert.Equal(newCustomer.FirstName, createdCustomer.FirstName);
        Assert.Equal(newCustomer.LastName, createdCustomer.LastName);
        Assert.Equal(newCustomer.Email, createdCustomer.Email);
    }
}
