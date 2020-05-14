using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NikCryptographyMain
{
    public sealed class FuncOther
    {
        #region other_methods

        public static byte[] ConvertIVCharsToIVByte(char[] iv)
        {
            byte[] ivBytes = new byte[16];
            byte i = 0;
            var items = iv;

            if (iv.Length == 16)
            {
                foreach (var item in items)
                {
                    if (item == '1')
                        ivBytes[i] = 1;
                    i++;
                }
            }
            return ivBytes;
        }

        public static byte[] ConvertIVTextToIVByte(string iv)
        {
            byte[] ivBytes = new byte[16];
            byte i = 0;
            var items = iv.ToCharArray();

            if (iv.Length == 16)
            {
                foreach (var item in items)
                {
                    if (item == '1')
                        ivBytes[i] = 1;
                    i++;
                }
            }
            return ivBytes;
        }

        public static string ConvertIVByteToIVText(byte[] iv)
        {
            string ivText = "";
            byte i = 0;

            if (iv.Length == 16)
            {
                foreach (var item in iv)
                {
                    if (item == 1)
                        ivText = ivText + '1';
                    else if (item == 0)
                        ivText = ivText + '0';
                    i++;
                }


            }

            return ivText;
        }


        public static List<KeyValuePair<string, string>> Generator()
        {
            var myDictionary = new List<KeyValuePair<string, string>>();

            myDictionary.Add(new KeyValuePair<string, string>("1001111111110011", "36734F7A 08107FD3 811E38B3 839CCAF7 55575E03 B9A5437E 744FECDC 6AD1696D"));
            myDictionary.Add(new KeyValuePair<string, string>("0001111111111110", "6AD1696D 08107FD3 B9A5437E 55575E03 839CCAF7 744FECDC 811E38B3 36734F7A"));
            myDictionary.Add(new KeyValuePair<string, string>("1001111111111100", "6AD1696D 36734F7A 55575E03 839CCAF7 811E38B3 744FECDC 08107FD3 B9A5437E"));
            myDictionary.Add(new KeyValuePair<string, string>("1111110000111111", "B9A5437E 811E38B3 6AD1696D 839CCAF7 36734F7A 08107FD3 55575E03 744FECDC"));
            myDictionary.Add(new KeyValuePair<string, string>("0111110100111111", "B9A5437E 08107FD3 6AD1696D 839CCAF7 36734F7A 55575E03 744FECDC 811E38B3"));
            myDictionary.Add(new KeyValuePair<string, string>("1011111111100110", "08107FD3 744FECDC 6AD1696D 839CCAF7 36734F7A B9A5437E 55575E03 811E38B3"));
            myDictionary.Add(new KeyValuePair<string, string>("1111111011111000", "55575E03 08107FD3 6AD1696D 839CCAF7 36734F7A B9A5437E 744FECDC 811E38B3"));
            myDictionary.Add(new KeyValuePair<string, string>("1111111001111010", "811E38B3 55575E03 08107FD3 6AD1696D 839CCAF7 36734F7A B9A5437E 744FECDC"));
            myDictionary.Add(new KeyValuePair<string, string>("1110111011111010", "839CCAF7 811E38B3 55575E03 744FECDC 08107FD3 6AD1696D 36734F7A B9A5437E"));
            myDictionary.Add(new KeyValuePair<string, string>("1010101111111110", "08107FD3 B9A5437E 839CCAF7 811E38B3 744FECDC 55575E03 6AD1696D 36734F7A"));

            return myDictionary;
        }


        public static byte[] FinalHT(string[] list)
        {
            string finalString = "";
            SHA256 mysh = SHA256.Create();
            foreach (var item in list)
            {

                finalString = finalString + item + " ";
            }

            return mysh.ComputeHash(Encoding.UTF8.GetBytes(finalString));
        }


        #endregion
    }
}
