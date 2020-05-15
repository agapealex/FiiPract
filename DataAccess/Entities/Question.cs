using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Question
    {
        public Question()
        {
            TablePersons = new HashSet<TablePerson>();
        }
        public Guid QuestionId { get; set; }
        public string Sentence { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string CorrectAnswer { get; set; }
        #region [ Navigation Properties ]
        public virtual ICollection<TablePerson> TablePersons { get; set; }
        #endregion
    }
}
