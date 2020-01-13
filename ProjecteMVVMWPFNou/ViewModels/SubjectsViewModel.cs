using Common.Lib.Core.Context.Interfaces;
using Project.Lib.Models;
using ProjecteMVVMWPFNou.Lib.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace ProjecteMVVMWPFNou.ViewModels
{
    public class SubjectsViewModel : ViewModelBase
    {

        public SubjectsViewModel()
        {

            SaveSubjectCommand = new RouteCommand(SaveSubject);
            GetSubjectsCommand = new RouteCommand(GetSubjects);
            DelSubjectCommand = new RouteCommand(DelSubject);
            EditSubjectCommand = new RouteCommand(EditSubject);
        }


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


        bool isEdit = false;

        public void SaveSubject()   //Meu : OK funciona
        {
            
            Subject subject = new Subject()
            {
                Name = SubjectNameVM,
                
            };
            //subject = CurrentSubject;
            //subject.Name = SubjectNameVM;

            if (isEdit == false)
                CurrentSubject = null;

            if (CurrentSubject != null)
                subject.Id = CurrentSubject.Id;

            subject.Save();

            // ErrorsList = subject.CurrentValidation.Errors;
            ErrorsList = subject.CurrentValidation.Errors.Select(x => new ErrorMessage() { Message = x }).ToList();



            GetSubjects();
            CurrentSubject = null;  
            SubjectNameVM = "";
            isEdit = false;
        }

        public void GetSubjects()    //Meu : OK funciona
        {

            var subject = new Subject();
            var repo = Subject.DepCon.Resolve<IRepository<Subject>>();
            SubjectList = repo.QueryAll().ToList();
        }

        List<Subject> _subjectsList;
        public List<Subject> SubjectList  //Meu : OK funciona
        {
            get
            {
                return _subjectsList;
            }
            set
            {
                _subjectsList = value;

                if (value != null && value.Count > 0)  //Nou
                {
                    CurrentSubject = value[0];          //Nou
                }                                       //Nou
                OnPropertyChanged();
            }
        }

        #region Commands
        public ICommand SaveSubjectCommand { get; set; }
        public ICommand GetSubjectsCommand { get; set; }
        public ICommand DelSubjectCommand { get; set; } //Meu funciona OK
        public ICommand EditSubjectCommand { get; set; }

        #endregion


        List<ErrorMessage> _errorsList;

        public List<ErrorMessage> ErrorsList
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


        private Subject _currentSubject;
        public Subject CurrentSubject  //Meu ok funciona !!
        {
            get { return _currentSubject; }
            set
            {
                _currentSubject = value;
                OnPropertyChanged("CurrentSubject");
                OnPropertyChanged("CanShowInfo");
            }
        }

        public void DelSubject()    //Meu, verificado funciona OK
        {

            Subject subject = new Subject();

            subject = CurrentSubject;
            
            subject.Delete();

            ErrorsList = subject.CurrentValidation.Errors.Select(x => new ErrorMessage() { Message = x }).ToList();



            GetSubjects();

            SubjectNameVM = "";
        }
        

        //private ICommand _editInfoCommand;
        //public ICommand EditCommand   //No Funciona bien, enseña el primero de la lista. Es el boton de Editar !!
        //{
        //    get
        //    {
        //        if (_editInfoCommand == null)
        //            _editInfoCommand = new ParamCommand(new Action<object>(Edit));
        //        return _editInfoCommand;


        //    }
        //}

        private bool CanShowInfo
        {
            get
            {
                return CurrentSubject != null;
            }
        }


        public void EditSubject()   //Meu : Funciona ok. Recupera currentSubject y lo pone en la textBox. Pdte.Ajustar el salvado
        {
            
            var subject = new Subject();

            subject = CurrentSubject;

            SubjectNameVM = CurrentSubject.Name;

            // CurrentSubject = null;

            isEdit = true;
        }



        //private void Edit(object obj)    
        //{

        //    if (obj != null)
        //    {
        //        var subject = new Subject();


        //        subject = CurrentSubject;

        //        SubjectNameVM = CurrentSubject.Name;
        //        //CurrentPersona = (Persona)obj;
        //        //MessageBox.Show(CurrentPersona.Nombre);
        //    }


        //}





    }
}
