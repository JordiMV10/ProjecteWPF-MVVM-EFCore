using Common.Lib.Core;
using Common.Lib.Core.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Lib.Models
{
    public class Exam : Entity
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public Subject Subject
        {
            get
            {
                var repo = Subject.DepCon.Resolve<IRepository<Subject>>();
                var subject = repo.Find(SubjectId);
                return subject;
            }
        }


        public Guid SubjectId { get; set; }

        public Exam()
        {

        }

    }
}
