using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lands.ViewModels
{
    public class BaseViewModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T BackingField, T Value,[CallerMemberName] string propertyName= null)
        {
            if (EqualityComparer<T>.Default.Equals(BackingField, Value))
            {
                return;
            }
            BackingField = Value;
            OnPropertyChanged(propertyName);
        }
    }
}
