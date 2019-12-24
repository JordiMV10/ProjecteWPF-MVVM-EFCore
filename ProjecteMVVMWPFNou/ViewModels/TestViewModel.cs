using ProjecteMVVMWPFNou.Lib.UI;
using System.Windows.Input;


namespace ProjecteMVVMWPFNou.ViewModels
{
    class TestViewModel : ViewModelBase
    {

        public TestViewModel()
        {

            TestCommand = new RouteCommand(SqLiteTestConnection);
        }

        public ICommand TestCommand { get; set; }

        public void SqLiteTestConnection()
        {
            var testCon = new TestConnection();



        }
    }
}
