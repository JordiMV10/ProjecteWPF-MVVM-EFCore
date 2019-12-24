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

        public void AddStudent()
        {
            Student student = new Student()
            {
                Dni = DniVM,
                Name = NameVM,
                ChairNumber = ChairNumberVM,

            };
            student.Save();
            // DbContext.Students.Add(student.Id, student);   //OJO
            GetStudents();    // OJO PRUEBAS !!!  Volver a activar

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
    }
}
