using OpenSolutions.DataAccess.Entities;
using OpenSolutions.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSolutions.Domain
{
    public interface IRecordService
    {
        List<RecordEntity> GetAll();
        Task Add(RecordEntity recordEntity);
        Task Delete(RecordEntity recordEntity);
        Task Change(RecordEntity recordEntity);
        List<RecordEntity> Sorting(Enum sort);
        IEnumerable<RecordEntity> GetRecords();

    }
}