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
                OnPropertyChanged();
            }
        }

        #region Commands
        public ICommand AddSubjectCommand { get; set; }
        public ICommand GetSubjectsCommand { get; set; }

        #endregion

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


    }
}
