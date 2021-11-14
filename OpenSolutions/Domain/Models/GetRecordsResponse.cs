using System.Collections.Generic;
using OpenSolutions.DataAccess.Entities;

namespace OpenSolutions.Domain.Models
{
    public class GetRecordsResponse
    {
        public List<RecordEntity> Records { get; set; }
        public int Count { get; set; }
    }
}