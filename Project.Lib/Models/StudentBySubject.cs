using Common.Lib.Core;
using Common.Lib.Core.Context.Interfaces;
using Common.Lib.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Lib.Models
{
    public class StudentBySubject : Entity
    {
        public Student Dni { get; set; }

        public List<Subject> SubjectsForStudent { get; set; }


        public SaveResult<StudentBySubject> Save()
        {
            var saveResult = base.Save<StudentBySubject>();

            return saveResult;
        }


        public SaveResult<StudentBySubject> Delete()  //MEU
        {
            var saveResult = base.Delete<StudentBySubject>();

            return saveResult;
        }


        public override ValidationResult Validate()  //meu
        {
            var output = base.Validate();
            var student = new Student();

            student.ValidateDni(output);

            return output;
        }


        public StudentBySubject Clone()
        {
            return Clone<StudentBySubject>();
        }

        public override T Clone<T>()
        {
            var output = base.Clone<T>() as StudentBySubject;

            output.Dni = this.Dni;

            return output as T;
        }

        public string AddSubjectsToList(Subject subj)
        {
            var output = "";
            var subject = new Subject();
            //{
            //    Name = subj.Name
            //};

            subject = subj;
            

            //var subject = new Subject();
            //subject.Name = name.Name;
            if (SubjectsForStudent != null)
            {
                subject = SubjectsForStudent.FirstOrDefault(x => x.Name == subj.Name);

                if (subject == null)
                {

                    subject.Name = subj.Name;
                    SubjectsForStudent.Add(subj);
                    return output = null;
                }

                else
                {
                    subj.Name = "";
                    return output = "Asignatura ya existe en la lista";
                }
            }
                
            // Para la primera entrada
            else
            {
                SubjectsForStudent.Add(subj);
                return output = null;
            }

        }

        //#region Static Validations
        //public static ValidationResult<Student> ValidateDni(Student dni, Guid currentId = default)
        //{
        //    var output = new ValidationResult<Student>()
        //    {
        //        IsSuccess = true
        //    };

        //    if (Student.IsNullOrEmpty(dni))
        //    {
        //        output.IsSuccess = false;
        //        output.Errors.Add("el dni del alumno no puede estar vacío");


        //    }

        //    #region check duplication
        //    var repo = DepCon.Resolve<IRepository<StudentBySubject>>();

        //    //var entityWithDni = repo.GetStudentByDni(dni, currentId);  //Jose
        //    var entityWithDni = repo.QueryAll().FirstOrDefault(s => s.Dni == dni);

        //    if (currentId == default && entityWithDni != null)
        //    {
        //        // on create
        //        output.IsSuccess = false;
        //        output.Errors.Add("ya existe un alumno con ese dni");

        //    }

        //    else if (currentId != default && entityWithDni != null && entityWithDni.Id != currentId)    //Modificado
        //    {
        //        if (entityWithDni.Dni == dni)
        //        {
        //            // on update
        //            // Console.WriteLine("Soy Student : Ya existe un alumno con este DNI");  //Meu
        //            output.IsSuccess = false;
        //            output.Errors.Add("ya existe un alumno con ese dni");
        //        }
        //    }
        //    #endregion

        //    if (output.IsSuccess)
        //        output.ValidatedResult = dni;

        //    return output;
        //}
        //#endregion








    }





}

