using Common.Lib.Core;
using Common.Lib.Core.Context.Interfaces;
using Common.Lib.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Lib.Models
{
    public class StudentSubject  : Entity
    {
        public Guid StudentId { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject 
        {
            get
            {
                var repo = Subject.DepCon.Resolve<IRepository<Subject>>();
                var subject = repo.Find(SubjectId);
                return subject;
            }
        }

        public Student Student
        {
            get
            {
                var repo = Student.DepCon.Resolve<IRepository<Student>>();
                var student = repo.Find(StudentId);
                return student;
            }
        }


        public SaveResult<StudentSubject> Save()   //OK funciona bien
        {
            var saveResult = base.Save<StudentSubject>();

            return saveResult;
        }


        public SaveResult<StudentSubject> Delete()  //MEU
        {
            var saveResult = base.Delete<StudentSubject>();

            return saveResult;
        }

        public List<StudentSubject> StudentBySubjects(Guid idStudent)   //Meu Funciona OK, torna llista dels IDs dels students i les ID de les seves Subjects.
        {
            var repo = DepCon.Resolve<IRepository<StudentSubject>>();
            var entityId = repo.QueryAll().Where(e => e.StudentId == idStudent).ToList();
            return entityId;
        }



        public StudentSubject Clone()
        {
            return Clone<StudentSubject>();
        }


    }
}

