using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Appium.Test
{
    public class SomeViewModel: INotifyPropertyChanged
    {
        public NotifyTaskCompletion<string> _someString { get; set; }

        public NotifyTaskCompletion<string> SomeString
        {
            get
            {
                return _someString;
            }
            set
            {
                if (_someString != value)
                {
                    _someString = value;
                    OnPropertyChanged("SomeString");
                }
            }
        }

        public SomeViewModel()
        {
            _someString = new NotifyTaskCompletion<string>(AString());
        }

        private async Task<string> AString()
        {
            return await Task.FromResult("A String");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
