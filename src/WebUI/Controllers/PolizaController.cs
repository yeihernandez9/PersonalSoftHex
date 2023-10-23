using HexPersonalSoft.Application.Common.Models;
using HexPersonalSoft.Application.Polizas.Commands.CreatePolizaCommand;
using HexPersonalSoft.Application.Polizas.Commands.DeletePolizaCommand;
using HexPersonalSoft.Application.Polizas.Queries.GetPolizaWhitPagination;
using Microsoft.AspNetCore.Mvc;

namespace HexPersonalSoft.WebUI.Controllers;

public class PolizaController : ApiControllerBase

{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<PolizaListDto>>> GetPolizaWithPagination([FromQuery] GetPolizaWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreatePolizaCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpGet]
    [Route("getPlaca")]
    public async Task<ActionResult<PaginatedList<PolizaListDto>>> GetPolizaPlacaPolizaWithPagination([FromQuery] GetPolizPlacaPolizaWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeletePolizaCommand(id));

        return NoContent();
    }

}

