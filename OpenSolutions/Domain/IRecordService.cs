using OpenSolutions.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSolutions.Domain
{
    interface IRecordService
    {
        public List<RecordEntity> GetAll();
    }
}
