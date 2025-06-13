using APBD_Test2.App.DTO;

namespace APBD_Test2.App.Services.Record;

public interface IRecordService
{
    List<GetRecordListItemDto> GetAllRecords(QueryDto q);
    
    void CreateRecord(PostRecordWithTaskDto record);
    
    void CreateRecord(PostRecordDto dto);
}