using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kecamatan.Model
{
    public class Ikecamatan
    {
        public int Kode { get; set; }
        public string Deskripsi { get; set; }
        public List<KecamatanList> Kecamatan { get; set; }
    }
    public class KecamatanList
    {
        public long Id { get; set; }
        public int KotaId { get; set; }
        public string Nama { get; set; }
    }
}
