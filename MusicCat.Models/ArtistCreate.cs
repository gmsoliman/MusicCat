using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCat.Models
{
    public class ArtistCreate
    {
        //tr
        [Required]
        public string ArtistName { get; set; }
        public string Hometown { get; set; }
        //tr
    }
}
