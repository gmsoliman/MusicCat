using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCat.Models.Song
{
    public class SongEdit
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public decimal Length { get; set; }
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
    }
}
//JAH