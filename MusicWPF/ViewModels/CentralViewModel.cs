using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace MusicWPF
{
    public class CentralViewModel : BaseViewModel
    {
        public ObservableCollection<MusicItemViewModel> Items { get; set; }
        ButtonsViewModel buttonsVM = new ButtonsViewModel();

        public CentralViewModel()
        {            
            this.RefreshCommand = new RelayCommand(buttonsVM.RefreshClicked);

            MusicStructureHelper.InitializeDB();

            var children = MusicStructureHelper.GetArtists();

            this.Items = new ObservableCollection<MusicItemViewModel>(children.
                Select(x => new MusicItemViewModel(ItemTypeEnum.Artist, x.Name, x.ID)));
        }

        public ICommand RefreshCommand { get; set; }
        
    }
}
