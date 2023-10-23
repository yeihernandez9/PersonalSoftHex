using HexPersonalSoft.Application.Common.Exceptions;
using HexPersonalSoft.Application.Polizas.Commands.CreatePolizaCommand;
using HexPersonalSoft.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace HexPersonalSoft.Application.IntegrationTests.Polizas.Commands;


using static Testing;

public class CreatePolizaTests:  BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreatePolizaCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateTodoItem()
    {
        var userId = await RunAsDefaultUserAsync();

        var listId = await SendAsync(new CreatePolizaCommand
        {
            Polizaa = "001",
            ClientName = "Yeison",
            ClientIdentification = "123456789",
            DateBirth = "20/08/1987",
            DateCretePolicy = "19/04/2003",
            Coverage = "50000",
            ValueMax = "2000000",
            PlanPolicyName = "Cererza",
            HomeCity = "Medellin",
            AddressHome = "Kr 72D # 74",
            Placa = "GLW338",
            Modelo = "2019",
            Inspeccion = false,
});

        var command = new CreatePolizaCommand
        {
            ListId = listId,
            Polizaa = "001",
            ClientName = "Yeison",
            ClientIdentification = "123456789",
            DateBirth = "20/08/1987",
            DateCretePolicy = "19/04/2003",
            Coverage = "50000",
            ValueMax = "2000000",
            PlanPolicyName = "Cererza",
            HomeCity = "Medellin",
            AddressHome = "Kr 72D # 74",
            Placa = "GLW338",
            Modelo = "2019",
            Inspeccion = false,
        };

        var itemId = await SendAsync(command);

        var item = await FindAsync<Polizas>(itemId);

        item.Should().NotBeNull();
        item!.ListId.Should().Be(command.ListId);
        item.Polizaa.Should().Be(command.Polizaa);
        item.ClientName.Should().Be(command.ClientName);
        item.ClientIdentification.Should().Be(command.ClientIdentification);
        item.DateBirth.Should().Be(command.DateBirth);
        item.DateCretePolicy.Should().Be(command.DateCretePolicy);
        item.Coverage.Should().Be(command.Coverage);
        item.ValueMax.Should().Be(command.ValueMax);
        item.PlanPolicyName.Should().Be(command.PlanPolicyName);
        item.HomeCity.Should().Be(command.HomeCity);
        item.AddressHome.Should().Be(command.AddressHome);
        item.Placa.Should().Be(command.Placa);
        item.Modelo.Should().Be(command.Modelo);
        item.Inspeccion.Should().Be(command.Inspeccion);
        item.CreatedBy.Should().Be(userId);
        item.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        item.LastModifiedBy.Should().Be(userId);
        item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}

