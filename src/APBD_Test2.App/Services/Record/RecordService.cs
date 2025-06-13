using APBD_Test2.App.DTO;
using APBD_Test2.Infrastructure.DAL;
using APBD_Test2.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Task = APBD_Test2.Infrastructure.Model.Task;

namespace APBD_Test2.App.Services.Record;

public class RecordService : IRecordService
{
    private readonly MasterContext _context;

    public RecordService(MasterContext context)
    {
        _context = context;
    }
    
    public List<GetRecordListItemDto> GetAllRecords(QueryDto q)
    {
        var query = _context.Record
            .Include(r => r.Language)
            .Include(r => r.Task)
            .Include(r => r.Student);

        IOrderedQueryable<Infrastructure.Model.Record> q1;

        switch (q.sortBy)
        {
            case "create":
                q1 = query.OrderByDescending(r => r.ExecutionTime);
                break;
            case "lastName":
                q1 = query.OrderBy(r => r.Student.LastName);
                break;
            default:
                q1 = query.OrderBy(r => r.Id);
                break;
        }

        return q1
            .Select(r => new GetRecordListItemDto
            {
                Id = r.Id,
                Language = new GetRecordListItemLanguageDto()
                {
                    Id = r.Language.Id,
                    Name = r.Language.Name
                },
                Task = new GetRecordListItemTaskDto()
                {
                    Id = r.Task.Id,
                    Name = r.Task.Name,
                    Description = r.Task.Description,
                },
                Student = new GetRecordListItemStudentDto()
                {
                    Id = r.Student.Id,
                    FirstName = r.Student.FirstName,
                    LastName = r.Student.LastName,
                    Email = r.Student.Email,
                },
                ExecutionTime = r.ExecutionTime,
                Created = r.CreatedAt
            })
            .ToList();
    }

    public void CreateRecord(PostRecordWithTaskDto record)
    {
        var task = new Task()
        {
            Name = record.Task.Name,
            Description = record.Task.Description,
        };
        _context.Task.Add(task);
        _context.SaveChanges();
        
        CreateRecord(new PostRecordDto()
        {
            LanguageId = record.LanguageId,
            StudentId = record.StudentId,
            TaskId = task.Id,
            ExecutionTime = record.ExecutionTime,
            Created = record.Created,
        });
    }

    public void CreateRecord(PostRecordDto dto)
    {
        var language = _context.Language.FirstOrDefault(r => r.Id == dto.LanguageId);

        if (language == null)
        {
            throw new NotFoundException("language not found");
        }
        
        var student = _context.Student.FirstOrDefault(s => s.Id == dto.StudentId);

        if (student == null)
        {
            throw new NotFoundException("student not found");
        }
        
        var task = _context.Task.FirstOrDefault(t => t.Id == dto.TaskId);

        if (task == null)
        {
            throw new NotFoundException("task not found");
        }

        var record = new Infrastructure.Model.Record
        {
            Language = language,
            Task = task,
            Student = student,
            ExecutionTime = dto.ExecutionTime,
            CreatedAt = dto.Created,
        };
        _context.Record.Add(record);
        _context.SaveChanges();
    }
}