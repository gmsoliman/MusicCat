﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCat.Models
{
    public class AlbumCreate
    {
        [Required]
        public string AlbumTitle { get; set; }
        public DateTime Year { get; set; }

    }
}
