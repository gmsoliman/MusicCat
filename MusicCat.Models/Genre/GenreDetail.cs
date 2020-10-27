using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCat.Models.Genre
{
    //gs
    public class GenreDetail
    {
        public int GenreId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        //Maybe add the number of artists, albums, or songs that fall under this genre?
    }
    //gs
}
