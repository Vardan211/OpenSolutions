using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSolutions.Domain.Models
{
    public class RecordModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string BirthDate { get; set; }
    }
}
