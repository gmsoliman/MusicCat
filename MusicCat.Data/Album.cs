using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCat.Data
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string AlbumTitle { get; set; }
        public DateTime Year { get; set; }

        //foreignkey(nameof(artist id))
        //test
        //james
        //test
    }
}
