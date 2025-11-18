using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace YurtKayitSistemi
{
    public class SqlBaglantim
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-HJ161GJ\SQLEXPRESS; Initial Catalog = YurtKayit; Integrated Security = True; Encrypt=False");
            baglan.Open();
            return baglan;
        }
    }
}
