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
    class HelperMusteri
    {
   

        public static List<MusteriModel> MusteriAsList()  //Geri dönüş tipi MusteriModel , müşteri listesini döndür
        {
            List<MusteriModel> mList = new List<MusteriModel>();

            using (SuDBEntities s = new SuDBEntities())
            {
                var list = s.musteriler.ToList();

                foreach (var item in list)
                {
                    MusteriModel mm = new MusteriModel();

                   mm.musteriID = item.musteriID;
                   mm.musteriAdi = item.musteriAdi;
                    mm.musteriSoyadi = item.musteriSoyadi;
                   mm.Adres = item.Adres;
                    mm.Telefon=item.Telefon;
                    mList.Add(mm);
                }

                return mList;
            }


        }


        public static List<MusteriModel> ReturnMusteri(string ad, string soyad)
        {
            using (SuDBEntities s = new SuDBEntities())
            {
                List<MusteriModel> mList = new List<MusteriModel>();
                MusteriModel mm = new MusteriModel();
                var list = MusteriAsList();

                foreach (var item in list)
                {
                    if (item.musteriAdi.Equals(ad) && item.musteriSoyadi.Equals(soyad))
                    {
                        mm.musteriID = item.musteriID;
                        mm.musteriAdi = item.musteriAdi;
                        mm.musteriSoyadi = item.musteriSoyadi;
                        mm.Adres = item.Adres;
                        mm.Telefon = item.Telefon;
                        mList.Add(mm);

                    }

                }
                return mList;
            }


        }


        public static bool RemoveMusteri(int ID)
        {
            using (SuDBEntities s = new SuDBEntities())
            {
                var bul = s.musteriler.Find(ID);
                s.musteriler.Remove(bul);

                if (s.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return true;

            }

        }
       

        public static bool AddMusteri(MusteriModel mm)
        {
            using (SuDBEntities s=new SuDBEntities())
            {
                musteriler m = ConvertMusteri(mm);
                s.musteriler.Add(m);
                if (s.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public static bool UpdateMusteri(MusteriModel mm)
        {
            using (SuDBEntities s=new SuDBEntities()) 
            {
                musteriler m = ConvertMusteri(mm);
                s.Entry(m).State= EntityState.Modified;
                if (s.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }


        public static musteriler ConvertMusteri(MusteriModel mm)
        {
            musteriler m = new musteriler();

            m.musteriID = mm.musteriID;
            m.musteriAdi = mm.musteriAdi;
            m.musteriSoyadi = mm.musteriSoyadi;
            m.Adres = mm.Adres;
            m.Telefon = mm.Telefon;
            return m;

        }

    }
}
