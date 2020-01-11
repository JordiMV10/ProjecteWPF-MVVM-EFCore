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
            // RefreshEVMCommand = new RouteCommand(RefreshEVM);
        }

        // public ICommand RefreshEVMCommand { get; set; }


        //public void RefreshEVM()
        //{
        //    GetSubjectsEVM();
        //}

        public List<string> GetSubjectsEVM()  //OK Funciona.
        {
            var subject = new Subject();
            var repo = Subject.DepCon.Resolve<IRepository<Subject>>();
            SubjectsListEVM = repo.QueryAll().ToList();
            List<string> SubjectsByNameListEVM = new List<string>();
            foreach (Subject subj in SubjectsListEVM)
            {
                var name = subj.Name;
                SubjectsByNameListEVM.Add(name);
            }
            return SubjectsByNameListEVM;
        }

        //public void GetSubjectsEVM2()  //OK Funciona. Revisar XAML pq no aparece la info
        //{
        //    var subject = new Subject();
        //    SubjectNameEVM = subject.Name;
        //    var repo = Subject.DepCon.Resolve<IRepository<Subject>>();
        //    SubjectsListEVM = repo.QueryAll().ToList();
        //    SubjectNameEVM = subject.Name;

        //    List<string> SubjectsByNameListEVM = new List<string>();
        //    foreach (Subject subj in SubjectsListEVM)
        //    {
        //        var name = subj.Name;
        //        SubjectsByNameListEVM.Add(name);
        //    }

        //}


        //private string _subjectNameEVM;

        //public string SubjectNameEVM
        //{
        //    get { return _subjectNameEVM; }
        //    set
        //    {
        //        _subjectNameEVM = value;
        //        OnPropertyChanged();
        //    }
        //}


        List<Subject> _subjectsListEVM;
        public List<Subject> SubjectsListEVM  //Meu : OK funciona
        {
            get
            {
                return _subjectsListEVM;
            }
            set
            {
                _subjectsListEVM = value;

                OnPropertyChanged();
            }
        }


        List<string> _subjectsByNameListEVM;
        public List<string> SubjectsByNameListEVM  //Meu : OK funciona
        {
            get
            {
                return _subjectsByNameListEVM;
            }
            set
            {
                _subjectsByNameListEVM = value;

                OnPropertyChanged();
            }
        }
    }
}
