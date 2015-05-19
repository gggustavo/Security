using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace MSACommon
{
    public class SecurityUtil
    {
        private const string EncryptionKey = "20gugarcia2014";

        public static Result GetListResult(string uri, string userName)
        {
            uri += userName;
            Result list = new Result();
            HttpWebRequest http = (HttpWebRequest)HttpWebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)http.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                string responseJson = sr.ReadToEnd();
                list = JsonConvert.DeserializeObjectAsync<Result>(responseJson).Result;
            }
            return list;
        }

        public static string GetPasswordByIdUser(string uri, string userName)
        {
            uri += userName;
            HttpWebRequest http = (HttpWebRequest)HttpWebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)http.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                string responseJson = sr.ReadToEnd();
                string value = JsonConvert.DeserializeObjectAsync<string>(responseJson).Result;
                if ( value!= null)
                    return value;
            }
            return null;
        }

        public static string Encrypt(string clearText)
        {            
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        private string Decrypt(string cipherText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public static void SetAuthentication(string UserName)
        {            
            System.Web.Security.FormsAuthentication.SetAuthCookie(UserName, false);
            HttpContext.Current.Session.Add("usuarioLogueado", UserName);
        }

    }
}
