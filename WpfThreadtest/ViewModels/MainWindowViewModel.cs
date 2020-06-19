using System;
using System.Threading;
using System.Windows.Input;
using System.Windows.Threading;
using WpfThreadtest.Commands;
using WpfThreadtest.ViewModels.Base;
using WpfThreadtest.Views;

namespace WpfThreadtest.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        DispatcherTimer _timer = new DispatcherTimer();
        private string _strText;
        public string StrText
        {
            get => _strText;
            set => Set(ref _strText, value);
        }
        public MainWindowViewModel()
        {
            //_timer.Tick += Timer_tick;
            //_timer.Interval = new TimeSpan(100);
            //_timer.Start();
            OpenNewWindowCommand = new RelayCommand(OnOpenNewWindowCommandEcecuted, CanOpenNewWindowCommandEcecute);
            PutPlusCommand = new RelayCommand(OnPutPlusCommandEcecuted, CanPutPlusCommandEcecute);
        }

        //private void Timer_tick(object sender, EventArgs e)
        //{
        //    StrText += "+";
        //    if (StrText.Length >= 400)
        //        StrText = "";
        //    //Thread.Sleep(2000);
        //}


        public ICommand PutPlusCommand { get; }
        private bool CanPutPlusCommandEcecute(object p) => true;
        private void OnPutPlusCommandEcecuted(object p)
        {
            StrText += "+";
        }

        private void OpenNewWindowMethod()
        {
            SecondWindow secondWindow = new SecondWindow();
            secondWindow.Show();
        }


        public ICommand OpenNewWindowCommand { get; }
        private bool CanOpenNewWindowCommandEcecute(object p) => true;
        private void OnOpenNewWindowCommandEcecuted(object p)
        {
            OpenNewWindowMethod();
        }
    }
}
