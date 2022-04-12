using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kelurahan.Model
{
    public class Ikelurahan
    {
        public int Kode { get; set; }
        public string Deskripsi { get; set; }
        public List<KelurahanList> Kelurahan { get; set; }
    }
    public class KelurahanList
    {
        public long Id { get; set; }
        public long KecamatanId { get; set; }
        public string Nama { get; set; }
    }
}
