using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    internal class PairModel
    {
        public int Id { get; set; }
        public int User1_ID { get; set; }
        public int User2_ID { get; set; }
        public string User1_Decision { get; set; }
        public string User2_Decision { get; set; }
        public System.DateTime Match_Date { get; set; }
    }
}
