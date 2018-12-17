

namespace MusicWPF
{
    public class MusicItemViewModel : BaseViewModel
    {
        public ItemTypeEnum Type { get; set; }

        public string ImageName => Type == ItemTypeEnum.Album ? "Album" : (Type == ItemTypeEnum.Artist ? "Artist" : "Song");

        public string Name { get; set; }

        public MusicItemViewModel(ItemTypeEnum type, string name)
        {
            this.Type = type;
            this.Name = name;
        }
    }
}
