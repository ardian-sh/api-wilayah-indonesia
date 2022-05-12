using kecamatan.Model;
using kelurahan.Model;
using kota.Model;
using provinsi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWilayahIndonesia.Interface
{
    public interface IWilayahIndonesiaInterface
    {
        List<ProvinsiList> GetAllProvinsi(int? provinsiid);
        List<KotaList> GetKota(int provinsiId);
        List<KecamatanList> GetKecamatan(int kotaId);
        List<KelurahanList> GetKelurahan(long kecamatanId);
    }
}
