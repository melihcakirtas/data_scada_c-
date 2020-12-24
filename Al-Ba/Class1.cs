using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Ba
{
    class socket
    {
        public static string  Ip { get; set; }

        public static int port { get; set; }
    }
    class server
    {

        public static string username { get; set; }// sql server kullanıcı adı

        public static string servername { get; set; }// sql server adı

        public static string password { get; set; }// sql server password

        public static string dbname { get; set; }// database adı

        public static string sql_port { get; set; }// database adı

        public static string tbname { get; set; }// tablo adı
    }
    public class sqlpost
    {
        public string address { get; set; }

        public string value { get; set; }

        public string definition { get; set; }
    }

    public class listitems
    {
        public bool status { get; set; }

        public int address { get; set; }

        public string type { get; set; }

        public string definition { get; set; }
    }

    public class sıfırlama
    {
        public static string gündüz_saat { get; set; }

        public static string gündüz_dak { get; set; }

        public static string mesai_saat { get; set; }

        public static string mesai_dak { get; set; }

        public static string gece_saat { get; set; }

        public static string gece_dak { get; set; }
    }
}
