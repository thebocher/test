using System.Text.Json;
using APBD_Test2.App;
using APBD_Test2.App.DTO;
using APBD_Test2.App.Services.Record;
using APBD_Test2.Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Test2.API.Controllers;

[ApiController]
[Route("/api/records")]
public class RecordController : ControllerBase
{
    private readonly IRecordService _recordService;
    
    public RecordController(IRecordService recordService)
    {
        _recordService = recordService;
    }

    [HttpGet]
    public List<GetRecordListItemDto> GetAllRecords([FromBody] QueryDto q)
    {
        return _recordService.GetAllRecords(q);
    }

    [HttpPost]
    public IActionResult CreateRecord([FromBody] PostRecordDto dto)
    {
        try
        {
            _recordService.CreateRecord(dto);
            return Created();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    public IActionResult CreateRecord([FromBody] PostRecordWithTaskDto dto)
    {
        try
        {
            _recordService.CreateRecord(dto);
            return Created();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}