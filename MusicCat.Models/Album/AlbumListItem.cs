using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCat.Models.Album
{
    public class AlbumListItem
    {
        //bh
        public int AlbumId { get; set; }
        public string AlbumTitle { get; set; }
        public int Year { get; set; }
        public int ArtistId { get; set; }
        public int GenreId { get; set; }

        //bh
    }
}
