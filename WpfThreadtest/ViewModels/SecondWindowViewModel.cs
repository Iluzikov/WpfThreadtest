using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using WpfThreadtest.Commands;
using WpfThreadtest.ViewModels.Base;

namespace WpfThreadtest.ViewModels
{
    class SecondWindowViewModel : ViewModelBase
    {
        DispatcherTimer _timer = new DispatcherTimer();
        private string _strText;
        public string StrText
        {
            get => _strText;
            set => Set(ref _strText, value);
        }
        public SecondWindowViewModel()
        {
            _timer.Tick += Timer_tick;
            ///_timer.Interval = new TimeSpan(0,0,1);
            
            AddPlusCommand = new RelayCommand(OnOpenNewWindowCommandEcecuted, CanOpenNewWindowCommandEcecute);
        }
        private void Timer_tick(object sender, EventArgs e)
        {
            StrText += "+";
            if (StrText.Length >= 400)
                StrText = "";
            //Thread.Sleep(2000);
        }

        public ICommand AddPlusCommand { get; }
        private bool CanOpenNewWindowCommandEcecute(object p) => true;
        private void OnOpenNewWindowCommandEcecuted(object p)
        {
            //StrText += "+";
            _timer.Start();
        }
    }
}
