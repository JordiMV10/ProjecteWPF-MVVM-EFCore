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
    public class ManagementViewModel : ViewModelBase
    {

        public ManagementViewModel()
        {
            AddSubjectToListVMCommand = new RouteCommand(AddSubjectToListVM);
            FindStudentCommand = new RouteCommand(FindStudent);
            GetSubjectsMGVMCommand = new RouteCommand(GetSubjectsMGVM);


            //GetSubjectsCommand = new RouteCommand(GetSubjects);
            //DelSubjectCommand = new RouteCommand(DelSubject);
            //EditSubjectCommand = new RouteCommand(EditSubject);
        }

        private string _dniMGVM;

        public string DniMGVM
        {
            get { return _dniMGVM; }
            set
            {
                _dniMGVM = value;
                OnPropertyChanged();
            }
        }

        private string _nameMGVM;

        public string NameMGVM
        {
            get { return _nameMGVM; }
            set
            {
                _nameMGVM = value;
                OnPropertyChanged();
            }
        }

        private string _subjectNameMGVM;

        public string SubjectNameMGVM
        {
            get { return _subjectNameMGVM; }
            set
            {
                _subjectNameMGVM = value;
                OnPropertyChanged();
            }
        }

        private string _managementErrorMGVM;

        public string ManagementErrorMGVM
        {
            get { return _managementErrorMGVM; }
            set
            {
                _managementErrorMGVM = value;
                OnPropertyChanged();
            }
        }



        public ICommand AddSubjectToListVMCommand { get; set; }
        public ICommand FindStudentCommand { get; set; }
        public ICommand GetSubjectsMGVMCommand { get; set; }



        private Student _currentStudentMVM;
        public Student CurrentStudentMVM  //Meu ok funciona !!
        {
            get { return _currentStudentMVM; }
            set
            {
                _currentStudentMVM = value;
                OnPropertyChanged("CurrentStudentMVM");
                OnPropertyChanged("CanShowInfo");
            }
        }




        private Subject _currentSubjectMVM;
        public Subject CurrentSubjectMVM  //Meu ok funciona !!
        {
            get { return _currentSubjectMVM; }
            set
            {
                _currentSubjectMVM = value;
                OnPropertyChanged("CurrentSubjectMVM");
                OnPropertyChanged("CanShowInfo");
            }
        }

        //public void CatchPropiertiesStudent(Student obj)
        //{
        //    var propiertie = obj;
        //    CurrentStudentMVM = propiertie;
        //}

        //public void CatchPropiertiesSubject(Subject obj)
        //{
        //    CurrentSubjectMVM = obj;
        //}

        public void AddSubjectToListVM()
        {
            //CurrentSubjectMVM.Name = SubjectNameMGVM;
            //CurrentStudentMVM.Dni = DniMGVM;
            //CurrentStudentMVM.Name = NameMGVM;
            Subject subject = new Subject();
            Student student = new Student();

            subject = CurrentSubjectMVM;
            student = CurrentStudentMVM;
            

            //StudentsViewModel studentMVM = new StudentsViewModel();
            //SubjectsViewModel subjectMVM = new SubjectsViewModel();

            StudentBySubject studentBySubjectMVM = new StudentBySubject();
            //Subject subject = new Subject();

            // CurrentStudentMVM.Dni = DniMGVM;
            //CurrentSubjectMVM.Name = subjectMVM.SubjectNameVM;
            //subject = CurrentSubjectMVM;
            //string name = subject.Name;

            var error = studentBySubjectMVM.AddSubjectsToList(subject);

            if (error != null)
            {
                ManagementErrorMGVM = error;
            }
            else
            {
                var repo = StudentBySubject.DepCon.Resolve<IRepository<StudentBySubject>>();
               // SubjectsByStudentList = repo.QueryAll().ToList();  // Quitada por errores. Solucionar !!

            }

        }


        private void FindStudent()   //Meu : 
        {
            var studentsVM = new StudentsViewModel();
            studentsVM.GetStudents();

            CurrentStudentMVM = studentsVM.StudentsListNou.FirstOrDefault(x => x.Dni == DniMGVM);

            if (CurrentStudentMVM != null)
            {
                DniMGVM = CurrentStudentMVM.Dni;
                NameMGVM = CurrentStudentMVM.Name;
                ManagementErrorMGVM = "";
            }

            else
            {
                ManagementErrorMGVM = "Student no Existe";
                DniMGVM = "";
                NameMGVM = "";

            }

        }

        public void GetSubjectsMGVM()    //Meu : OK funciona
        {

            var subject = new Subject();
            var repo = Subject.DepCon.Resolve<IRepository<Subject>>();
            SubjectListMGVM = repo.QueryAll().ToList();
        }

        List<Subject> _subjectsListMGVM;
        public List<Subject> SubjectListMGVM  //Meu : OK funciona
        {
            get
            {
                return _subjectsListMGVM;
            }
            set
            {
                _subjectsListMGVM = value;

                if (value != null && value.Count > 0)  //Nou
                {
                    CurrentSubjectMVM = value[0];          //Nou
                }                                       //Nou
                OnPropertyChanged();
            }
        }




        List<Subject> _subjectsByStudentList;
        public List<Subject> SubjectsByStudentList  //Meu 
        {
            get
            {
                return _subjectsByStudentList;
            }
            set
            {
                _subjectsByStudentList = value;

                if (value != null && value.Count > 0)  //Nou
                {
                    CurrentSubjectMVM = value[0];          //Nou
                }                                       //Nou
                OnPropertyChanged();
            }
        }










        private bool CanShowInfo
        {
            get
            {
                return CurrentSubjectMVM != null;
            }
        }


    }
}
