﻿using System;

namespace CleanArchMVC.API.Models
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiracao { get; set; }
    }
}
