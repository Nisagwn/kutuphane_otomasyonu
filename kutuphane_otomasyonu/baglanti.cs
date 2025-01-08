using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace kutuphane_otomasyonu
{
    internal class baglanti
    {
        public SqlConnection baglan()
        {
            SqlConnection bag = new SqlConnection(@"Data Source=NISA\SQLEXPRESS;Initial Catalog=kutuphaneotomasyon;Integrated Security=True;Trust Server Certificate=True");
            bag.Open();
            return bag;
        }
    }
    
}
