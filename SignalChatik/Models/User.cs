﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SignalChatik.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public int AuthUserId { get; set; }
        public AuthUser AuthUser { get; set; }
    }
}
