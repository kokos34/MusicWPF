using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace MusicWPF
{
    public class CentralViewModel : BaseViewModel
    {
        public ObservableCollection<MusicItemViewModel> Items { get; set; }

        public CentralViewModel()
        {            
            this.RefreshCommand = new RelayCommand(RefreshClicked);

            GetItems();
        }

        private void GetItems()
        {
            MusicStructureHelper.InitializeDB();

            var children = MusicStructureHelper.GetArtists();

            this.Items = new ObservableCollection<MusicItemViewModel>(children.
                Select(x => new MusicItemViewModel(ItemTypeEnum.Artist, x.Name, x.ID)));
        }

        public ICommand RefreshCommand { get; set; }

        public void RefreshClicked()
        {
            GetItems();
        }

    }
}
