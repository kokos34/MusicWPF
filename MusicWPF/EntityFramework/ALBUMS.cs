namespace MusicWPF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ALBUMS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ALBUMS()
        {
            SONGS = new HashSet<SONGS>();
        }

        public int ID { get; set; }

        public int? ID_Artist { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [StringLength(50)]
        public string Genre { get; set; }

        public virtual ARTISTS ARTISTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SONGS> SONGS { get; set; }
    }
}
