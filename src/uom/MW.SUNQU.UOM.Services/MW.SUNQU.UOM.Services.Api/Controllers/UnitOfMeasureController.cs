using MediatR;
using Microsoft.AspNetCore.Mvc;
using MW.SUNQU.UOM.Application.UseCases.Queries.GetAllUnitsOfMeasure;

namespace MW.SUNQU.UOM.Services.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UnitOfMeasureController : ControllerBase
{
    #region Properties & Variables
    //
    // private 
    //
    private readonly IMediator _mediator;
    #endregion

    #region Constructor
    public UnitOfMeasureController(IMediator mediator)
    {
        _mediator = mediator;
    }
    #endregion

    #region Methods
    [HttpGet]
    public async Task<IActionResult> ListUnitsOfMeasure()
    {
        var response = await _mediator.Send(new GetAllUnitsOfMeasureQuery());
        return Ok(response);
    }
    #endregion
}
