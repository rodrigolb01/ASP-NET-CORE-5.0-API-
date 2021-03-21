﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public long Cpf { get; set; }
    }
}
