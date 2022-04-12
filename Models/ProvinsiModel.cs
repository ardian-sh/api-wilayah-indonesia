using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace provinsi.Model
{
    public class IProvinsi
    {
        public int Kode { get; set; }
        public string Deskripsi { get; set; }
        public List<ProvinsiList> Provinsi { get; set; }
    }

    public class ProvinsiList
    {
        public int Id { get; set; }
        public string Nama { get; set; }
    }
}
