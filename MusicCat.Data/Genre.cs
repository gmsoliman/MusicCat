using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCat.Data
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        //foreignkey(nameof(album id))
        //foreignkey(nameof(song id))

        //gabe test
    }
}
