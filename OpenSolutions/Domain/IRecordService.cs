using OpenSolutions.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenSolutions.Domain.Models;

namespace OpenSolutions.Domain
{
    public interface IRecordService
    {
        Task<RecordModel> GetById(int id);
        Task<GetRecordsResponse> GetAll(RecordFilterModel filters, SortState sort, int skip = 0, int take = 10);
        Task Add(RecordEntity recordEntity);
        Task Delete(RecordEntity recordEntity);
        Task Update(RecordEntity recordEntity);
        double GetAvgAge();
    }
}