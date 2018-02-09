using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Juniansoft.MvvmReady
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected bool Set<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            RaisePropertyChanged(propertyName, onChanged);
            return true;
        }

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
