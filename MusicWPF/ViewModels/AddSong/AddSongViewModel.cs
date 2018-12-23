
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MusicWPF
{
    public class AddSongViewModel : BaseViewModel
    {
        #region properties
        public ObservableCollection<ARTISTS> ParentArtists { get; set; }
        public ObservableCollection<ALBUMS> ParentAlbums { get; set; }

        private ARTISTS _selectedArtist;
        public ARTISTS SelectedArtist
        {
            get { return _selectedArtist; }
            set
            {
                _selectedArtist = value;
                if (_selectedArtist != null)
                    ParentAlbums = new ObservableCollection<ALBUMS>(MusicStructureHelper.GetArtistsAlbums(value.ID));
            }
        }
        public ALBUMS SelectedAlbum { get; set; }
        public string SongName { get; set; }
        #endregion

        public AddSongViewModel()
        {
            this.AddItemCommand = new RelayCommand(AddItem);

            this.ParentArtists = new ObservableCollection<ARTISTS>(MusicStructureHelper.GetArtists());
            this.ParentAlbums = new ObservableCollection<ALBUMS>();
        }

        public ICommand AddItemCommand { get; set; }

        private void AddItem()
        {
            if(SelectedAlbum != null)
                MusicStructureHelper.AddSong(SelectedAlbum.ID, SongName);
            else
                MessageBox.Show("Please select album or artist", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
