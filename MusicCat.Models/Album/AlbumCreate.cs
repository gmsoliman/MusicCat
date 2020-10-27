using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCat.Models.Album
{
    public class AlbumCreate
    {
        //bh
        [Required]
        public string AlbumTitle { get; set; }
        public int Year { get; set; }

        //bh

    }
}
