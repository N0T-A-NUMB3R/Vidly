﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
  
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Genre { get; set; }

        public DateTime ReleaseDate { get; set; }
        public DateTime AddedDate { get; set; }
        public short StockNumber { get; set; }

    }

    // /movies/random
}