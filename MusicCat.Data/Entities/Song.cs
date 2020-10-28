using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCat.Data.Entities
{
    public class Song
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public decimal Length { get; set; }
        public Guid OwnerId { get; set; }

        //foreignkey(nameof(album id))

        //// betsy test two
    }
}
