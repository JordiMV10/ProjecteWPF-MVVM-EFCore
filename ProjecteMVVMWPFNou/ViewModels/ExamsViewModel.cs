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
    public class ExamsViewModel : ViewModelBase
    {
        public ExamsViewModel()
        {
            GetSubjectsEVCommand = new RouteCommand(GetSubjectsEV);
            GetSubjectsNameEVCommand = new RouteCommand(GetSubjectsNameEV);
            SaveExamEVCommand = new RouteCommand(SaveExam);
            DateEVM = DateTime.Now;
        }

        public ICommand GetSubjectsEVCommand { get; set; }
        public ICommand GetSubjectsNameEVCommand { get; set; }
        public ICommand SaveExamEVCommand { get; set; }



        private string _titleEVM;

        public string TitleEVM
        {
            get
            {
                return _titleEVM;
            }
            set
            {
                _titleEVM = value;
                OnPropertyChanged();
            }
        }

        private string _textEVM;

        public string TextEVM
        {
            get
            {
                return _textEVM;
            }
            set
            {
                _textEVM = value;
                OnPropertyChanged();
            }
        }

        private string _currentSubjectNameEVM;


        public string CurrentSubjectNameEVM
        {
            get
            {
                return _currentSubjectNameEVM;
            }
            set
            {
                _currentSubjectNameEVM = value;
                OnPropertyChanged();
            }
        }


        private DateTime _dateEVM;

        public DateTime DateEVM
        {
            get
            {
                return _dateEVM;
            }
            set
            {
                _dateEVM = value;
                OnPropertyChanged();
            }
        }




        private Subject _currentSubjectEVM;
        public Subject CurrentSubjectEVM  //Meu ok funciona !!
        {
            get { return _currentSubjectEVM; }
            set
            {
                _currentSubjectEVM = value;
                OnPropertyChanged("CurrentSubjectEVM");
                OnPropertyChanged("CanShowInfo");
            }
        }



        List<Subject> _subjectsListEV;
        public List<Subject> SubjectsListEV
        {
            get
            {
                return _subjectsListEV;
            }
            set
            {
                _subjectsListEV = value;
                OnPropertyChanged();
            }

        }


        List<string> _subjectsNameListEV;
        public List<string> SubjectsNameListEV
        {
            get
            {
                return _subjectsNameListEV;
            }
            set
            {
                _subjectsNameListEV = value;
                OnPropertyChanged();
            }

        }





        public void GetSubjectsEV()  //NO TOCAR
        {
            var repo = Subject.DepCon.Resolve<IRepository<Subject>>();
            SubjectsListEV = repo.QueryAll().ToList();
        }


        public List<string> GetSubjectsByNameEV()  //NO TOCAR
        {
            GetSubjectsEV();
            List<string> SubjectsNameListEV = new List<string>();
            foreach (Subject subj in SubjectsListEV)
            {
                var name = subj.Name;
                SubjectsNameListEV.Add(name);
            }
            return SubjectsNameListEV;
        }


        public void GetSubjectsNameEV()  //OK Funciona No tocar !!!!
        {
            SubjectsNameListEV = GetSubjectsByNameEV();
        }


        public void SaveExam()
        {
            Exam exam = new Exam();
            Subject subject = new Subject();


            exam = SaveExamNameEV(CurrentSubjectNameEVM);  // Hasta aquí funciona Bien. Tengo objeto Exam completo. pdte.SAVE!!

            /// PDTE exam.Save();

        }
        public Exam SaveExamNameEV(string name)   //Meu : Funciona OK !! Me devuelve exam completo!! .
        {
            Subject subject = new Subject();
            var repo = Subject.DepCon.Resolve<IRepository<Subject>>();
            subject = repo.QueryAll().FirstOrDefault(s => s.Name == name);   //Funciona bien, recupero bien el subject

            Exam exam = new Exam();
            exam.SubjectId = subject.Id;
            exam.Title = TitleEVM;
            exam.Text = TextEVM;
            exam.Date = DateEVM;

            return exam;

            //{
            //    Name = CurrentSubjectEVM.Name,

            //};
            ////subject.Name = SubjectNameVM;

            //if (isEdit == false)
            //    CurrentSubject = null;

            //if (CurrentSubject != null)
            //    subject.Id = CurrentSubject.Id;

            // subject.Save();


            //// ErrorsList = subject.CurrentValidation.Errors;
            //ErrorsList = subject.CurrentValidation.Errors.Select(x => new ErrorMessage() { Message = x }).ToList();



            //GetSubjects();
            //CurrentSubject = null;
            //SubjectNameVM = "";
            //isEdit = false;
        }

    }
}
