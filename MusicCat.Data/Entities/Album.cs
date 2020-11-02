using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCat.Data.Entities
{
    public class Album
    {
        //bh
        [Key]
        public int AlbumId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string AlbumTitle { get; set; }
        public int Year { get; set; }

        [ForeignKey(nameof(Artist))]
        public int? ArtistId { get; set; }
        public virtual Artist Artist { get; set; }

        [ForeignKey(nameof(Genre))]
        public int? GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        //public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();

        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
    } //bh

}
