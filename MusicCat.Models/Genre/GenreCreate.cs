using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCat.Models.Genre
{
    //gs
    public class GenreCreate
    {
        [Required]
        [MinLength(2, ErrorMessage ="Please enter at least 2 characters.")]
        [MaxLength (50, ErrorMessage ="The entry's length exceeds the maximum of 50 characters.")]
        public string Type { get; set; }
        public string Description { get; set; }

        //public int AlbumId { get; set; }
        //public int SongId { get; set; }
    }
    //gs
}
