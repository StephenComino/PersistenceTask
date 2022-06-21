using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PersistenceTask.ViewModels
{
    abstract class BaseViewModel
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;
        public virtual void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}