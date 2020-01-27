using SuOtomasyonu.ENTITY;
using SuOtomasyonu.MODEL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuOtomasyonu.HELPER
{
    class HelperSiparis
    {

        public static List<MusteriModel> SiparisAsList()
        {
            
            using (SuDBEntities s = new SuDBEntities())
            {
                var list = s.siparisler.ToList();
                List<MusteriModel> mList = new List<MusteriModel>();

                foreach (var item in list)
                {
                    MusteriModel mm = new MusteriModel();

                    mm.siparis.siparisID = item.siparisID;
                    mm.siparis.musAdi = item.musAdi;
                    mm.siparis.musSoyadi = item.musSoyadi;
                    mm.siparis.musAdres = item.musAdres;
                    mm.siparis.Tutar = item.Tutar;
                    mm.siparis.Durum = item.Durum;
                    mList.Add(mm);
                }
                return mList;
            }
           
        }

        public static bool SiparisSil(int ID)
        {
            using (SuDBEntities s=new SuDBEntities())
            {
               var bulunan= s.siparisler.Find(ID);
                s.siparisler.Remove(bulunan);
                if (s.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public static bool TumSiparisTablosunuSil(List<int> l)
        {
            using (SuDBEntities s=new SuDBEntities()) 
            {
                foreach (var item in l)
                {
                   var bulunan=s.siparisler.Find(item);
                    s.siparisler.Remove(bulunan);
                    if (s.SaveChanges() < 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }


        public static List<int> SiparisIDListele()
        {
            using (SuDBEntities s=new SuDBEntities())
            {
                List<int> sm = new List<int>();
              var sList=  s.siparisler.ToList();
                foreach (var item in sList)
                {
                    sm.Add(item.siparisID);
                }
                return sm;
            }
        }


        public static List<MusteriModel> SiparisDepends()
        {
            List<MusteriModel> mList = new List<MusteriModel>();
            using (SuDBEntities s = new SuDBEntities())
            {
              var sList=  s.siparisler.ToList();
                foreach (var item in sList)
                {
                    if (item.Durum=="Hazirlaniyor"||item.Durum=="Yolda")
                    {
                        MusteriModel mm = new MusteriModel();
                        mm.siparis.siparisID = item.siparisID;
                        mm.siparis.musAdi = item.musAdi;
                        mm.siparis.musSoyadi = item.musSoyadi;
                        mm.siparis.musAdres = item.musAdres;
                        mm.siparis.Tutar = item.Tutar;
                        mm.siparis.Durum = item.Durum;

                        mList.Add(mm);
                    }
                }
                return mList;

            }

        }

        public static bool SiparisEkle(MusteriModel mm)
        {
            using (SuDBEntities s = new SuDBEntities())
            {
                siparisler sip = ConvertToSiparis(mm);
                s.siparisler.Add(sip);
                if (s.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        public static siparisler ConvertToSiparis(MusteriModel mm)
        {
            siparisler s = new siparisler();
            s.siparisID = mm.siparis.siparisID;
            s.musAdi = mm.siparis.musAdi;
            s.musSoyadi = mm.siparis.musSoyadi;
            s.musAdres = mm.siparis.musAdres;
            s.Tutar = mm.siparis.Tutar;
            s.Durum = mm.siparis.Durum;
            return s;
        }



        public static bool DurumDegistir(MusteriModel mm)
        {
            using (SuDBEntities s = new SuDBEntities())
            {
                siparisler sip = ConvertToSiparis(mm);
                s.Entry(sip).State= EntityState.Modified;
                if (s.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public static siparisler SiparisBul(int ID)
        {
            using (SuDBEntities s=new SuDBEntities())
            {
                return s.siparisler.Find(ID);
            }
        }

    }
}
