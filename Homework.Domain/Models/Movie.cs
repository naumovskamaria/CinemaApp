﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Domain.Models
{
    public class Movie
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual Ticket? Ticket { get; set; }
    }
}
