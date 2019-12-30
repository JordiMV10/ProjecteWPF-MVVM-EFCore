using Common.Lib.Core.Context.Interfaces;
using Project.Lib.Models;
using ProjecteMVVMWPFNou.Lib.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Common.Lib.Infrastructure;

namespace ProjecteMVVMWPFNou.ViewModels
{
    public class StudentsViewModel : ViewModelBase
    {
        private string _dniVM;

        public string DniVM
        {
            get { return _dniVM; }
            set
            {
                _dniVM = value;
                OnPropertyChanged();
            }
        }

        private string _nameVM;

        public string NameVM
        {
            get { return _nameVM; }
            set
            {
                _nameVM = value;
                OnPropertyChanged();
            }
        }

        private int _chairNumberVM;

        public int ChairNumberVM
        {
            get { return _chairNumberVM; }
            set
            {
                _chairNumberVM = value;
                OnPropertyChanged();
            }
        }

        public List<Student> Students
        {
            get
            {
                return _students;
            }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }
        List<Student> _students;


        public StudentsViewModel()
        {

            AddStudentCommand = new RouteCommand(AddStudent);
            GetStudentsCommand = new RouteCommand(GetStudents);
        }

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

        public void AddStudent()
        {
            Student student = new Student()
            {
                Dni = DniVM,
                Name = NameVM,
                ChairNumber = ChairNumberVM,

            };
            student.Save();

            //Funciona (2 lineas) aparece mensaje
            // this.MessageBoxRequest += new EventHandler<MvvmMessageBoxEventArgs>(StudentsView_MessageBoxRequest);

            // AskTheQuestion();


            // ErrorsList = student.CurrentValidation.Errors;  //ES bo, enseña 2 la longitud de los 2 mensajes y no el texto
            
            ErrorsList = student.CurrentValidation.ErrorsQueryAll().ToList();
            GetStudents();

            DniVM = "";
            NameVM = "";
            ChairNumberVM = 0;
        }

        public void GetStudents()
        {

            var student = new Student();
            var repo = Student.DepCon.Resolve<IRepository<Student>>();
            StudentsListNou = repo.QueryAll().ToList();

        }





        List<Student> _studentsListNou;
        public List<Student> StudentsListNou
        {
            get
            {
                return _studentsListNou;
            }
            set
            {
                _studentsListNou = value;
                OnPropertyChanged();
            }
        }

        #region Commands
        public ICommand AddStudentCommand { get; set; }
        public ICommand GetStudentsCommand { get; set; }

        #endregion

        //Nou : Per mostrar avisos en pantalla !!
        protected void AskTheQuestion()
        {
            MessageBox_Show(ProcessTheAnswer, "Are you sure you want to do this?", "Alert", System.Windows.MessageBoxButton.YesNo);

        }

        public void ProcessTheAnswer(MessageBoxResult result)
        {
            if (result == MessageBoxResult.Yes)
            {
                GetStudents();
            }
        }

        void StudentsView_MessageBoxRequest(object sender, MvvmMessageBoxEventArgs e)
        {

            e.Show();
        }

    }
}
