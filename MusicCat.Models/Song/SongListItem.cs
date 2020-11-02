using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCat.Models.Song
{
   public class SongListItem
    {
        public int SongID { get; set; }
        public string Title { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public int Lenght { get; set; }
        public int GenreId { get; set; }
        public int AlbumId { get; set; }

    }
}
//JAH