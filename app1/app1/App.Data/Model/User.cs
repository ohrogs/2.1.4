﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Model
{
    public class User
    {
        int ID { get; set; }
        string Nickname { get; set; }
        string Hash { get; set; }
        string Salt { get; set; }
    }
}