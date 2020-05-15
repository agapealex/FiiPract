using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class TablePerson
    {
        public TablePerson()
        {
            Questions = new HashSet<Question>();
        }
        public int TablePersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhotoPath { get; set; }
        public bool IsDeleted { get; set; }
        public int LocalityId { get; set; }
        public double TestResult { get; set; }
        #region [ Navigation Properties ]
        public virtual ICollection<Question> Questions { get; set; }
        #endregion
    }
}
