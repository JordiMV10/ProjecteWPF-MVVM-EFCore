using Common.Lib.Core.Context.Interfaces;
using Project.Lib.Models;
using ProjecteMVVMWPFNou.Lib.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ProjecteMVVMWPFNou.ViewModels
{
    public class SubjectsViewModel : ViewModelBase
    {
        private string _subjectNameVM;

        public string SubjectNameVM
        {
            get { return _subjectNameVM; }
            set
            {
                _subjectNameVM = value;
                OnPropertyChanged();
            }
        }

        public List<Subject> Subjects
        {
            get
            {
                return _subjects;
            }
            set
            {
                _subjects = value;
                OnPropertyChanged();
            }
        }
        List<Subject> _subjects;


        public SubjectsViewModel()
        {

            AddSubjectCommand = new RouteCommand(AddSubject);
            GetSubjectsCommand = new RouteCommand(GetSubjects);
        }

        public void AddSubject()
        {
            Subject subject = new Subject()
            {
                Name = SubjectNameVM
            };
            subject.Save();

            ErrorsList = subject.CurrentValidation.ErrorsQueryAll().ToList();


            GetSubjects();    

            SubjectNameVM = "";
        }

        public void GetSubjects()
        {

            var subject = new Subject();
            var repo = Subject.DepCon.Resolve<IRepository<Subject>>();
            SubjectListNou = repo.QueryAll().ToList();
        }

        List<Subject> _subjectsListNou;
        public List<Subject> SubjectListNou
        {
            get
            {
                return _subjectsListNou;
            }
            set
            {
                _subjectsListNou = value;

                if (value != null && value.Count > 0)  //Nou
                {
                    CurrentSubject = value[0];          //Nou
                }                                       //Nou
                OnPropertyChanged();
            }
        }

        #region Commands
        public ICommand AddSubjectCommand { get; set; }
        public ICommand GetSubjectsCommand { get; set; }

        List<string> _errorsList;

        public List<string> ErrorsList
        {
            get
            {
                return _errorsList;
            }
            set
            {
                _errorsList = value;
                OnPropertyChanged();
            }
        }

        //NOU

        //public ICommand DelSubjectCommand { get; set; }

        private ICommand _delSubjectCommand;
        public ICommand DelSubjectCommand   
        {
            get
            {
                if (_delSubjectCommand == null)
                    _delSubjectCommand = new RouteCommand(DelSubject);
                return _delSubjectCommand;
            }
        }


        private Subject _currentSubject;
        public Subject CurrentSubject
        {
            get { return _currentSubject; }
            set
            {
                _currentSubject = value;
                OnPropertyChanged("CurrentSubject");
                OnPropertyChanged("CanShowInfo");
            }
        }

        public void DelSubject()
        {

            Subject subject = new Subject();

            subject = CurrentSubject;
                //Name = CurrentSubject.Name ,  //OJO CurrentSubject
                //Id = CurrentSubject.Id
            
            subject.Delete();

            ErrorsList = subject.CurrentValidation.ErrorsQueryAll().ToList();


            GetSubjects();

            SubjectNameVM = "";
        }
        #endregion

        private ICommand _verInfoCommand;
        public ICommand VerInfoCommand   //No Funciona bien, enseña el primero de la lista. Es el boton de Editar !!
        {
            get
            {
                if (_verInfoCommand == null)
                    _verInfoCommand = new RouteCommand(VerInfo);
                return _verInfoCommand;
            }
        }

        private bool CanShowInfo
        {
            get
            {
                return CurrentSubject != null;
            }
        }

        private void VerInfo()    //Funciona
        {
           SubjectNameVM=CurrentSubject.Name;
        }


        //private void EliminarPersona(object obj)
        //{
        //    if (obj != null)
        //    {
        //        CurrentPersona = (Persona)obj;
        //        if (App.DbConnector.eliminarPersona(CurrentPersona))
        //        {
        //            if (MessageBox.Show("Eliminado " + CurrentPersona.Nombre + "!") == MessageBoxResult.OK)
        //            {
        //                ListaPersonas.Remove(((Persona)obj));
        //            }
        //        }
        //    }
        //}
    }
}
