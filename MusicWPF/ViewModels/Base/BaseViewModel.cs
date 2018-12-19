using PropertyChanged;
using System.ComponentModel;

namespace MusicWPF
{
    [AddINotifyPropertyChangedInterfaceAttribute]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
