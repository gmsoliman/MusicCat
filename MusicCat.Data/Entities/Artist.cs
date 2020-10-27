using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCat.Data.Entities
{
    public class Artist
    {
        //tr
        [Key]
        public int ArtistId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string ArtistName { get; set; }
        [Required]
        public string Hometown { get; set; }
        //tr
    }
}
