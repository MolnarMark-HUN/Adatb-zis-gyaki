using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adatbázis_gyaki
{
    public class datastore
    {
        public static List<datastore> kolbaszok = new List<datastore>();
        public int id { get; set; }
        public string fajta { get; set; }
        public int hossz { get; set; }
    }
}
