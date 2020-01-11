using Common.Lib.Core.Context.Interfaces;
using Common.Lib.Infrastructure.Interfaces;
using Project.Lib.Context.Interfaces;
using Project.Lib.DAL.EFCore;
using Project.Lib.DAL.EFCore.Context;
using Project.Lib.Models;
using System;

namespace ProjecteMVVMWPFNou.Boot

{
    public class Bootstrapper
    {
        public Bootstrapper()
        {

        }

        public void Init(IDependencyContainer dp, Func<ProjectDbContext> dbContextConst)
        {
            RegisterRepositories(dp, dbContextConst);
        }

        void RegisterRepositories(IDependencyContainer dp, Func<ProjectDbContext> dbContextConst)
        {
            var studentRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new GenericRepository<Student>(dbContextConst());
            });
            var subjectsRepoBuilder2 = new Func<object[], object>((parameters) =>   //Original
            {
                return new SubjectsRepository(dbContextConst());
            });
            var subjectsRepoBuilder = new Func<object[], object>((parameters) =>   //meu
            {
                return new GenericRepository<Subject>(dbContextConst());
            });
            var examsRepoBuilder = new Func<object[], object>((parameters) =>   //meu
            {
                return new GenericRepository<Exam>(dbContextConst());
            });
            var studentExamsRepoBuilder = new Func<object[], object>((parameters) =>   //meu
            {
                return new GenericRepository<StudentExam>(dbContextConst());   //Meu
            });

            var studentSubjectRepoBuilder = new Func<object[], object>((parameters) =>   //meu
            {
                return new GenericRepository<StudentSubject>(dbContextConst());   //Meu
            });
            var studentRepoBuilder2 = new Func<object[], object>((parameters) =>   //meu
            {
                return new StudentsRepository(dbContextConst());
            });


            dp.Register<IRepository<Student>, GenericRepository<Student>>(studentRepoBuilder);
            dp.Register<IRepository<Subject>, GenericRepository<Subject>>(subjectsRepoBuilder);  //meu
            dp.Register<IRepository<Exam>, GenericRepository<Exam>>(examsRepoBuilder);  //meu
            dp.Register<IRepository<StudentExam>, GenericRepository<StudentExam>>(studentExamsRepoBuilder);  //meu
            dp.Register<IRepository<StudentSubject>, GenericRepository<StudentSubject>>(studentSubjectRepoBuilder);   //meu
            dp.Register<IRepository<Subject>, SubjectsRepository>(subjectsRepoBuilder); 
            dp.Register<ISubjectsRepository, SubjectsRepository>(subjectsRepoBuilder2);
            dp.Register<IStudentsRepository, StudentsRepository>(studentRepoBuilder2);  //Meu
        }
    }
}
