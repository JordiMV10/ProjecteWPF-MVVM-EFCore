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
            var subjectsRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new SubjectsRepository(dbContextConst());
            });

            dp.Register<IRepository<Student>, GenericRepository<Student>>(studentRepoBuilder);

            dp.Register<IRepository<Subject>, SubjectsRepository>(subjectsRepoBuilder);
            dp.Register<ISubjectsRepository, SubjectsRepository>(subjectsRepoBuilder);
        }
    }
}
