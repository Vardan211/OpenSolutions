using System;

namespace OpenSolutions.DataAccess.Entities
{
    public class RecordEntity
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
