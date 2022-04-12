using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kota.Model
{
    public class Ikota
    {
        public int Kode { get; set; }
        public string Deskripsi { get; set; }
        public List<KotaList> Kota { get; set; }
    }

    public class KotaList
    {
        public int Id { get; set; }
        public int ProvinsiId { get; set; }
        public string Nama { get; set; }
    }

    
}
