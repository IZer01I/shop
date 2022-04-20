using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AuthTreaning.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void SetProperty<T>([Required]ref T destination, T value, [CallerMemberName] string propName = null)
        {
            destination = value;
            OnPropertyChanged(propName);
        }

        public virtual void OnPropertyChanged([CallerMemberName] string propertuName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertuName));
        }
    }
}
