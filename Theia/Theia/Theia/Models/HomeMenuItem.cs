﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Theia.Models
{
    public enum MenuItemType
    {
        //Browse,
        About,
        Settings,
        Navigation
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
