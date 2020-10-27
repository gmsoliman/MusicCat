using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCat.Data.Entities
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string AlbumTitle { get; set; }
        public int Year { get; set; }

        //foreignkey(nameof(artist id))
    }
       
}
