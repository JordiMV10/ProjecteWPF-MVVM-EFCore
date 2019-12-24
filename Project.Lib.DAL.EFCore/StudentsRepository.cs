using Common.Lib.Infrastructure;
using Project.Lib.Context.Interfaces;
using Project.Lib.DAL.EFCore.Context;
using Project.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Lib.DAL.EFCore
{
    public class StudentsRepository : GenericRepository<Student>, IStudentsRepository
    {
        private static Dictionary<string, Student> StudentsByDni { get; set; } = new Dictionary<string, Student>();
        private static Dictionary<string, List<Subject>> StudentsBySubjects { get; set; } = new Dictionary<string, List<Subject>>();

        public StudentsRepository(ProjectDbContext dbContext)
            : base(dbContext)
        {
            if (StudentsByDni == null)
            {
                StudentsByDni = new Dictionary<string, Student>();

                foreach (var student in dbContext.Students)
                    StudentsByDni.Add(student.Name, student);

            }
        }

        public Student FindByDni(string dni)
        {
            return StudentsByDni[dni];
        }

        public override SaveResult<Student> Add(Student entity)
        {
            var output = new SaveResult<Student>();  // Meu
            output = base.Add(entity);   //JOSE
            if (entity.Id == QueryAll().FirstOrDefault(s => s.Id == entity.Id).Id)     //MEU
            {
                output.Entity = entity;
                output.IsSuccess = true;
            }

            if (output.IsSuccess || entity.Id == QueryAll().FirstOrDefault(s => s.Id == entity.Id).Id)  //Meu
            {
                StudentsByDni.Add(output.Entity.Dni, output.Entity);  //de Jose
            }

            return output;
        }

        public override SaveResult<Student> Delete(Student entity)    //MEU
        {
            var output = new SaveResult<Student>();
            output = base.Delete(entity);

            if (output.IsSuccess)
            {
                output.Entity = entity;
                StudentsByDni.Remove(output.Entity.Dni);
                output.IsSuccess = true;
            }
            else
            {
                output.IsSuccess = false;
            }

            return output;
        }




        public override SaveResult<Student> Update(Student entity)
        {
            var existingStudent = Find(entity.Id);

            var previousDni = existingStudent.Dni;

            var output = base.Update(entity);


            if (output.IsSuccess)
            {
                output.Entity = entity;  //meu
                if (previousDni != output.Entity.Dni)
                {
                    StudentsByDni.Remove(previousDni);
                    StudentsByDni.Add(output.Entity.Dni, output.Entity);
                }
                else
                {
                    StudentsByDni[output.Entity.Dni] = output.Entity;

                }

            }

            return output;
        }

        //public Student GetStudentByDni(string dni, Guid currentId = default)
        //{
        //    var student = new Student();
        //    if (StudentsByDni.ContainsKey(dni))
        //    {
        //        return StudentsByDni[dni];  //Jose

        //    }

        //    else if (Find(student.Id) != null)
        //    {
        //        var DniOld = QueryAll().FirstOrDefault(s => s.Id == currentId).Dni;
        //        var cadira = QueryAll().FirstOrDefault(s => s.Id == currentId).ChairNumber;
        //        var nom = QueryAll().FirstOrDefault(s => s.Id == currentId).Name;
        //        // currentId = QueryAll().FirstOrDefault(s => s.Id == currentId).Id;
        //        return student;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public Student GetStudentByDni(string dni, Guid currentId = default)   //Funciona, intento optimizar y evitar LlistatDbSet
        {
            if (StudentsByDni.ContainsKey(dni))
            {
                return StudentsByDni[dni];  //Jose
            }

            //var keyss = QueryAll().Select(x => x.Id).ToList();  //Esta es una forma de obtener una lista con todos los ID de DbSet
            //var keys = LlistatDbSet();  //Esta es otra forma de obtener lista con todos los Id de DbSet (mia)

            if (DbSetContainsKey(currentId))
            {
                var existingStudent = Find(currentId);

                return existingStudent;
            }
            else
            {
                return null;
            }

        }


        public IQueryable<Student> QueryAllStudentsByDni()   //Meu - Copiat de de Repository QueryAll
        {
            return StudentsByDni.Values.AsQueryable<Student>();
        }

    }
}
