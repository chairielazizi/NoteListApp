﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteListApp.Models
{
    public class Diary
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string title { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
    }
}
