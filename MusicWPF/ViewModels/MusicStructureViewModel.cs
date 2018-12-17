using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace MusicWPF
{
    public class MusicStructureViewModel : BaseViewModel
    {
        public ObservableCollection<MusicItemViewModel> Items { get; set; }

        public MusicStructureViewModel()
        {
            MusicStructureHelper.InitializeDB();

            var children = MusicStructureHelper.GetArtists();

            this.Items = new ObservableCollection<MusicItemViewModel>(children.
                Select(x => new MusicItemViewModel(ItemTypeEnum.Artist, x.Name, x.ID)));
        }
    }
}
