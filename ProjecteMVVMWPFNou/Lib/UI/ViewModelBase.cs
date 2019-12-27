using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ProjecteMVVMWPFNou.Lib.UI
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        //Nuevo : Para poder mostrar avisos en pantalla ... posible borrar !!

        public event EventHandler<MvvmMessageBoxEventArgs> MessageBoxRequest;
        protected void MessageBox_Show(Action<MessageBoxResult> resultAction, string messageBoxText, string caption = "", MessageBoxButton button = MessageBoxButton.OK, MessageBoxImage icon = MessageBoxImage.None, MessageBoxResult defaultResult = MessageBoxResult.None, MessageBoxOptions options = MessageBoxOptions.None)
        {
            if (this.MessageBoxRequest != null)
            {
                this.MessageBoxRequest(this, new MvvmMessageBoxEventArgs(resultAction, messageBoxText, caption, button, icon, defaultResult, options));
            }
        }


       
       

    }
}
