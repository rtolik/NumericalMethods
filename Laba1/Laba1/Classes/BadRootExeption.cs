﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1.Classes
{
    class BadRootExeption:ApplicationException  
    {
        public BadRootExeption():base("Bad Root separation")
        {
        }
    }
}
