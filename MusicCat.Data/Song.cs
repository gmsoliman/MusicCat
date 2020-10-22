using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCat.Data
{
    public class Song
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public decimal Length { get; set; }

        //foreignkey(nameof(album id))
    }
}
