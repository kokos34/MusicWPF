using System.Linq;
using System.Collections.ObjectModel;
using System;
using System.Windows.Input;

namespace MusicWPF
{
    public class MusicItemViewModel : BaseViewModel
    {
        public int ID { get; set; }

        public ItemTypeEnum Type { get; set; }

        public string ImageName => Type == ItemTypeEnum.Album ? "Album" : (Type == ItemTypeEnum.Artist ? "Artist" : "Song");

        public string Name { get; set; }

        public ObservableCollection<MusicItemViewModel> Children { get; set; }

        public bool CanExpand { get { return this.Type != ItemTypeEnum.Song; } }

        public ICommand ExpandCommand { get; set; }

        public bool IsExpanded
        {
            get
            {
                return this.Children?.Count(f => f != null) > 0;
            }
            set
            {
                if (value == true)
                    Expand();
                else
                    ClearChildren();
            }
        }

        private void ClearChildren()
        {
            this.Children = new ObservableCollection<MusicItemViewModel>();

            // Show the expand arrow if we are not a file
            if (this.Type != ItemTypeEnum.Song)
                this.Children.Add(null);
        }

        private void Expand()
        {
            switch(this.Type)
            {
                case ItemTypeEnum.Song:
                    return;
                case ItemTypeEnum.Album:
                    var songs = MusicStructureHelper.GetAlbumsSongs(this.ID);
                    this.Children = new ObservableCollection<MusicItemViewModel>(songs.
                        Select(x => new MusicItemViewModel(ItemTypeEnum.Song, x.Name, x.ID)));
                    break;
                case ItemTypeEnum.Artist:
                    var albums = MusicStructureHelper.GetArtistsAlbums(this.ID);
                    this.Children = new ObservableCollection<MusicItemViewModel>(albums.
                        Select(x => new MusicItemViewModel(ItemTypeEnum.Album, x.Name, x.ID)));
                    break;
            }
        }

        public MusicItemViewModel(ItemTypeEnum type, string name, int id)
        {
            this.ExpandCommand = new RelayCommand(Expand);

            this.ID = id;
            this.Type = type;
            this.Name = name;

            this.ClearChildren();
        }
    }
}
