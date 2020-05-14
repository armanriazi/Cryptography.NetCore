using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.SqlServer.Server;

namespace CryptographyMain
{
    public sealed class Decryption
    {
        public static string FuncDecryptionMain(string cipherTxt, string keyTxt)
        {
            string decrypted = "";
            string error = "";
            string keyExtractText = "";
            string strIV = "";
            byte[] cipherBytesWithIv = null;            
            byte[] keyExtractByte = null;
            byte[] bytIV = new byte[16];
            
            try
            {
                if (cipherTxt == null || cipherTxt.Length <= 0)
                    throw new ArgumentNullException("CipherText");

                cipherBytesWithIv = Convert.FromBase64String(cipherTxt);
            }
            catch
            {

                error = "No suitable inputs for doing encrypt";
                return error;
            }



            try
            {
                byte len = 0;
                byte[] cipherBytes = new byte[cipherBytesWithIv.Length - 16];

                System.Buffer.BlockCopy(cipherBytesWithIv, 0, bytIV, 0, 16);
                System.Buffer.BlockCopy(cipherBytesWithIv, 16, cipherBytes, 0, cipherBytesWithIv.Length - 16);

                if (bytIV.Length < 1 || cipherBytes.Length < 1)
                    return "Exception occured in BlockCopy -FuncDecryption";

                strIV = FuncOther.ConvertIVByteToIVText(bytIV);
                foreach (var item in bytIV)
                    if (item == 0) len++;

                if (len != 4)
                    return "No suitable length iv for doing encrypt - FuncDecryption";

                var myDictionary = FuncOther.Generator();

                if (!(string.IsNullOrEmpty(strIV)))
                    keyExtractText = myDictionary.Find(f => f.Key == strIV).Value.ToString();
                else
                    return "Not found any IV -FuncDecryption";

                if (!(string.IsNullOrEmpty(keyExtractText)))
                {
                    if (!(keyExtractText.Equals(keyTxt)))
                        return "Not equal your key with assembly key -FuncDecryption";
                }
                else
                    return "Not found any key -FuncDecryption";

                keyExtractByte = FuncOther.FinalHT(keyExtractText.Split(' '));

                byte[] bytSalt = new byte[16];

                for (int i = 0; i < keyExtractByte.Length / 2; i++)
                    bytSalt[i] = keyExtractByte[i];

                var password = new Rfc2898DeriveBytes(bytIV, bytSalt, 500);
                var keyBytes = password.GetBytes(128 / 8);

                Aes rijAlg = Aes.Create();
                rijAlg.Key = keyBytes;
                rijAlg.Mode = CipherMode.CBC;
                if (!(bytIV == null))
                {
                    if (bytIV.Length > 0)
                    {
                        rijAlg.IV = bytIV;
                    }
                    else
                    {
                        rijAlg.Mode = CipherMode.ECB;
                    }
                }
                else
                {
                    rijAlg.Mode = CipherMode.ECB;
                }


                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                MemoryStream msDecrypt = new MemoryStream(cipherBytes);
                CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                StreamReader srDecrypt = new StreamReader(csDecrypt);

                decrypted = srDecrypt.ReadToEnd();

            }
            catch (Exception e)
            {
                error = e.Message;

                if (error.Contains("Padding is invalid and cannot be removed."))
                    error = "In decryption function occured : Padding is invalid and cannot be removed.";
            }
            return error != "" ? error : decrypted;
        }

    }

}
