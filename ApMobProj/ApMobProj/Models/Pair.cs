﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApMobProj.Models
{
    public class Pair
    {
        public int Id { get; set; }
        public int User1Id { get; set; }
        public int User2Id { get; set; }
        public string User1Decision { get; set; }
        public string User2Decision { get; set; }
        public System.DateTime MatchDate { get; set; }
    }
}
