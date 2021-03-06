﻿using Common.Lib.Core;
using Common.Lib.Core.Context.Interfaces;
using Common.Lib.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Lib.Models
{
    public class Exam : Entity
    {
        public Exam()
        {

        }


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


        public SaveResult<Exam> Save() // OK Funciona
        {
            var saveResult = base.Save<Exam>();

            return saveResult;
        }

        public SaveResult<Exam> Delete()  //OK Funciona
        {
            var saveResult = base.Delete<Exam>();

            return saveResult;
        }

        #region Static Validations
        public static ValidationResult<string> ValidateTitle(string title, Guid currentId = default)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(title))
            {
                output.IsSuccess = false;
                output.Errors.Add("El Título no puede estar vacío");

            }

            if (output.IsSuccess)
                output.ValidatedResult = title;

            return output;
        }

        public static ValidationResult<string> ValidateText(string text, Guid currentId = default)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(text))
            {
                output.IsSuccess = false;
                output.Errors.Add("El Texto no puede estar vacío");

            }

            if (output.IsSuccess)
                output.ValidatedResult = text;

            return output;
        }

        public static ValidationResult<Subject> ValidateSubject(Subject subject, Guid currentId = default)
        {
            var output = new ValidationResult<Subject>()
            {
                IsSuccess = true
            };

            if (subject == null)
            {
                output.IsSuccess = false;
                output.Errors.Add("La asignatura no puede estar vacía");

            }

            if (output.IsSuccess)
                output.ValidatedResult = subject;

            return output;
        }

        #endregion


        #region Domain Validations
        public void ValidateTitle(ValidationResult validationResult)
        {
            var vr = ValidateTitle(this.Title, this.Id);
            if (!vr.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(vr.Errors);
            }

        }

        public void ValidateText(ValidationResult validationResult)
        {
            var vr = ValidateText(this.Text, this.Id);
            if (!vr.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(vr.Errors);
            }

        }

        public void ValidateSubject(ValidationResult validationResult)
        {
            var vr = ValidateSubject(this.Subject, this.Id);
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

            ValidateTitle(output);
            ValidateText(output);
            ValidateSubject(output);

            return output;
        }

    }
}
