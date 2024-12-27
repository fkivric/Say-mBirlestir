using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SayimBirlestir.Class
{
    public static class Volant
    {
        public class PASSBEHAVE
        {
            public long PABHID { get; set; }
            public string PABHCOMPANY { get; set; }
            public string PABHDIVISON { get; set; }
            public DateTime PABHDATE { get; set; }
            public long PABHCRCACURID { get; set; }
            public int PABHINSCOUNT { get; set; }
            public string PABHDC { get; set; }
            public double PABHEXCHAMOUNT { get; set; }
            public string PABHEXCH { get; set; }
            public double PABHEXCHRATE { get; set; }
            public double PABHAMOUNT { get; set; }
            public long PABHCURID { get; set; }
            public long PABHACCID { get; set; }
            public string PABHNOTES { get; set; }
            public long PABHPCDSCHID { get; set; }
            public string PABHSOCODE { get; set; }
            public DateTime PABHDATETIME { get; set; }
            public string PABHCANCELID { get; set; }
        }
        public class SAFEBHAVE
        {
            public string SABHID { get; set; }
            public long SABHDSAFEID { get; set; }
            public string SABHCOMPANY { get; set; }
            public string SABHDIVISON { get; set; }
            public string SABHSOURCE { get; set; }
            public DateTime SABHDATE { get; set; }
            public string SABHDC { get; set; }
            public bool SABHBT { get; set; }
            public string SABHDEEDNO { get; set; }
            public string SABHDEEDKIND { get; set; }
            public DateTime SABHDEEDDATE { get; set; }
            public string SABHDEEDNOTES { get; set; }
            public double SABHEXCHAMOUNT { get; set; }
            public string SABHEXCH { get; set; }
            public string SABHRATE { get; set; }
            public double SABHAMOUNT { get; set; }
            public string SABHTIESABHID { get; set; }
            public long SABHPCDSCHID { get; set; }
            public string SABHBABHID { get; set; }
            public string SABHEXPOLID { get; set; }
            public string SABHCHQID { get; set; }
            public string SABHACCKIND { get; set; }
            public string SABHACCSTS { get; set; }
            public string SABHVERSEVAL { get; set; }
            public string SABHVERSENAME { get; set; }
            public string SABHSOCODE { get; set; }
            public DateTime SABHDATETIME { get; set; }
            public string SABHDSBHID { get; set; }
            public string SABHDIVFORBH { get; set; }
        }
        public class SAFBHAVECHILD
        {
            public long SABHCHID { get; set; }
            public long SABHCHSABHID { get; set; }
            public double SABHCHEXCHAMOUNT { get; set; }
            public double SABHCHAMOUNT { get; set; }
            public string SABHCHDC { get; set; }
            public string SABHCHVERSESAFEID { get; set; }
            public long SABHCHCURID { get; set; }
            public long SABHCHACCID { get; set; }
            public string SABHCHACCEXCH { get; set; }
            public double SABHCHEXCHRATE { get; set; }
            public string SABHCHEXSOID { get; set; }
            public string SABHCHNOTES { get; set; }
        
    }
        public class Magazalar
        {
            public string DIVVAL { get; set; }
            public string DIVNAME { get; set; }

        }
        public class AllDataBase
        {
            public string DbNAme { get; set; }
        }
        public class Firma
        {
            public string COMPANYDB { get; set; }
            public string COMPANYNAME { get; set; }

        }
        private static string password = "310894";
        public class eDatabase
        {
            public string sqlServerName { get; set; }

            public string databaseName { get; set; }

            public string login { get; set; }

            public string password { get; set; }

            public string integratedSecurity { get; set; }

            public string company { get; set; }

            public string divison { get; set; }

            public string year { get; set; }

            public string pathOfPrints { get; set; }

            public string pathOfArchive { get; set; }

            public string serverPort { get; set; }

            public string serverDbName => sqlServerName + databaseName;

            public string language { get; set; }
        }
        public static string TextSifreCoz(this string text)
        {
            byte[] SifrelenmisByteDizisi = Convert.FromBase64String(text);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, new byte[13]
            {
            73, 118, 97, 110, 32, 77, 101, 100, 118, 101,
            100, 101, 118
            });
            byte[] SifresiCozulmusVeri = SifreCoz(SifrelenmisByteDizisi, pdb.GetBytes(32), pdb.GetBytes(16));
            return Encoding.Unicode.GetString(SifresiCozulmusVeri);
        }
        private static byte[] SifreCoz(byte[] SifreliVeri, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(SifreliVeri, 0, SifreliVeri.Length);
            cs.Close();
            return ms.ToArray();
        }

    }
}
