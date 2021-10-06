using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumeRestfulProject.Database
{
    public class CAR
    {
        [PrimaryKey, AutoIncrement]
        public int CARID { get; set; }
        public string BRAND { get; set; }
        public string MODEL { get; set; }
        public string YEAR { get; set; }
        public string DETAILS { get; set; }
        public string IMAGE { get; set; }
    }
}
