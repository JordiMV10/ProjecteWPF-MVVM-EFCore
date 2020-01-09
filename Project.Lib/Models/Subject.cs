using Common.Lib.Core;
using Common.Lib.Core.Context.Interfaces;
using Common.Lib.Infrastructure;
using Project.Lib.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Lib.Models
{
    public class Subject : Entity
    {
        public string Name { get; set; }

        public Guid Guid { get; private set; }

       //  public IList<StudentSubject> StudentSubjects { get; set; }


        public SaveResult<Subject> Save()
        {
            var saveResult = base.Save<Subject>();

            return saveResult;
        }






        #region Static Validations
        public static ValidationResult<string> ValidateName(string name, Guid currentId = default)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(name))
            {
                output.IsSuccess = false;
                output.Errors.Add("el nombre de la asignatura no puede estar vacío");

            }

            #region check duplication
            var repo = DepCon.Resolve<IRepository<Subject>>();

            var entityWithName = repo.QueryAll().FirstOrDefault(s => s.Name == name);

            if (currentId == default && entityWithName != null)
            {
                // on create
                output.IsSuccess = false;
                output.Errors.Add("ya existe una Asignatura con ese nombre");
                // Console.WriteLine("Soy Subject : Ya existe una Asignatura con este Nombre");

            }
            //else if (currentId != default && entityWithName.Id != currentId)  //Original
            else if (currentId != default && entityWithName != null && entityWithName.Id != currentId)    //Modificado
            {
                if (entityWithName.Name == name)
                {
                    // on update
                    // Console.WriteLine("Soy Subject : Ya existe una Asignatura con este Nombre"); 
                    output.IsSuccess = false;
                    output.Errors.Add("Ya existe una Asignatura con este Nombre");
                }
            }
            #endregion

            if (output.IsSuccess)
                output.ValidatedResult = name;

            return output;
        }
        #endregion


        #region Domain Validations
        public void ValidateName(ValidationResult validationResult)
        {
            var vr = ValidateName(this.Name, this.Id);
            if (!vr.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(vr.Errors);
            }

        }
        #endregion

        

        public override ValidationResult Validate()
        {
            var output = base.Validate();

            ValidateName(output);

            return output;
        }

        public Subject Clone()
        {
            return Clone<Subject>();
        }

        public override T Clone<T>()
        {
            var output = base.Clone<T>() as Subject;

            output.Name = this.Name;

            return output as T;
        }

        //public override Repository<T> ResolveRepository<T>()
        //{
        //    return new SubjectRepository() as Repository<T>;

        public SaveResult<Subject> Delete()  //MEU
        {
            var saveResult = base.Delete<Subject>();

            return saveResult;
        }

    }


    
}

