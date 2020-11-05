using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCat.Data.Entities
{
    public class Genre
    {
        //gs
        [Key]
        public int GenreId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Type { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();

        //[ForeignKey(nameof(Album))]
        //public int? AlbumId { get; set; }
        //public virtual Album Album { get; set; }

        //[ForeignKey(nameof(Song))]
        //public int? SongId { get; set; }
        //public virtual Song Song { get; set; }

        //gs
    }
}
