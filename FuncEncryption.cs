using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Text;

namespace NikCryptographyMain
{
    public sealed class Encryption
    {
        public static string NikFuncEncryptionMain(string plainTxt)//, out string encrypted, out string extractedIVTxt, out string error
        {
            string encrypted = "";
            string extractedIVTxt = "";
            string error = "";
            int rngNum = 0;
            var myDictionary = FuncOther.Generator();
            var rng = new Random();

            rngNum = rng.Next(0, myDictionary.Count - 1);
            string strIV = myDictionary[rngNum].Key;
            string strSH = myDictionary[rngNum].Value;

            try
            {

                if (plainTxt == null || plainTxt.Length <= 0)
                    throw new ArgumentNullException("PLAINTEXT");

                byte[] bytSalt = new byte[16];
                byte[] bytIV = FuncOther.ConvertIVTextToIVByte(strIV);
                var plainTextBytes = Encoding.UTF8.GetBytes(plainTxt);
                byte[] bytSH = FuncOther.FinalHT(strSH.Split(' '));
                var ivStringBytes = strIV;

                for (int i = 0; i < bytSH.Length / 2; i++)
                    bytSalt[i] = bytSH[i];

                var password = new Rfc2898DeriveBytes(bytIV, bytSalt, 500);
                var keyBytes = password.GetBytes(128 / 8);

                Aes rijAlg = Aes.Create();

                if (!(strIV == null))
                {
                    if (strIV.Length > 0)
                    {
                        rijAlg.IV = bytIV;
                        rijAlg.Key = keyBytes;
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

                ICryptoTransform encryptor = rijAlg.CreateEncryptor();

                List<byte> listCipherTextBytes = new List<byte>();

                //List<byte> listbytSalt = new List<byte>(NewSH);
                //listCipherTextBytes.AddRange(listbytSalt);

                List<byte> listIvStringBytes = new List<byte>(bytIV);
                listCipherTextBytes.AddRange(listIvStringBytes);

                List<byte> listMemoryStream = new List<byte>(encryptor.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length));
                listCipherTextBytes.AddRange(listMemoryStream);

                byte[] cipherTextBytes = listCipherTextBytes.ToArray();

                extractedIVTxt = strIV;
                encrypted = Convert.ToBase64String(cipherTextBytes);
            }
            catch (Exception e)
            {

                error = e.Message;
            }
     
            string result = encrypted + "▲" + extractedIVTxt;

            return !(string.IsNullOrEmpty(error))? error : result;
        }
    }
}


