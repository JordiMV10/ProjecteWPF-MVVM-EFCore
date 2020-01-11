using Common.Lib.Core.Context.Interfaces;
using Project.Lib.Models;
using ProjecteMVVMWPFNou.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjecteMVVMWPFNou.Views
{
    /// <summary>
    /// Lógica de interacción para ExamsView.xaml
    /// </summary>
    public partial class ExamsView : UserControl
    {
        public ExamsView()
        {
            InitializeComponent();

            ExamsViewModel examsVM = new ExamsViewModel();
            ComboBoxSubjects.ItemsSource = examsVM.GetSubjectsEVM(); 
        }

        public void Refresh()
        {
            ExamsViewModel examsVM = new ExamsViewModel();
            ComboBoxSubjects.ItemsSource = examsVM.GetSubjectsEVM();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
