﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookIt.Views.Menu
{

    public class MainMasterDetailMenuItem
    {
        public MainMasterDetailMenuItem()
        {
            TargetType = typeof(MainMasterDetailDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}