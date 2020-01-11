using Common.Lib.Core;
using Common.Lib.Core.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Lib.Models
{
    public class StudentExam : Entity
    {

        public Exam Exam
        {
            get
            {
                var repo = Exam.DepCon.Resolve<IRepository<Exam>>();
                var exam = repo.Find(ExamId);
                return exam;
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


        public Guid ExamId { get; set; }


        public Guid StudentId { get; set; }

        public double Mark { get; set; }

        public bool HasCheated { get; set; }

        public StudentExam()
        {

        }
    }
}
