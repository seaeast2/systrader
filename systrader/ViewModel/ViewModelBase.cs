using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

namespace systrader.ViewModel
{
    class ViewModelBase : INotifyPropertyChanged
    {
        //basic ViewModelBase
        internal void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        //Extra Stuff, shows why a base ViewModel is useful
        bool? _CloseWindowFlag;
        public bool? CloseWindowFlag
        {
            get { return _CloseWindowFlag; }
            set
            {
                _CloseWindowFlag = value;
                OnPropertyChanged("CloseWindowFlag");
            }
        }

        public virtual void CloseWindow(bool? result = true)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => 
                { CloseWindowFlag = CloseWindowFlag == null ? true : !CloseWindowFlag; }
            ));
        }
    }
}
