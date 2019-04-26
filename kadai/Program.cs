using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Security.Cryptography;
using System.Text;
//using System.Threading.Tasks;


namespace AESProgram {

    class Program {

        //初期ベクトル
        const string AesIV = @"kanagawayokohama";
        //暗号化鍵
        const string AesKey = @"kanagawayokohamaturuyatyouhumani";

        private byte[] Encrypt(string text) {

           

            //暗号化方式はAES
            AesManaged aes = new AesManaged();
            //鍵の長さ
            aes.BlockSize = 128;
            //暗号利用モード
            aes.Mode = CipherMode.CBC;
        
            aes.IV = Encoding.UTF8.GetBytes(AesIV);
            aes.Key = Encoding.UTF8.GetBytes(AesKey);
            //パティング
            aes.Padding = PaddingMode.PKCS7;

            //暗号化するためにバイトの配列に変換する必要がある
            byte[] byteText = Encoding.UTF8.GetBytes(text);

            //暗号化
            byte[] encryptText = aes.CreateEncryptor().TransformFinalBlock(byteText, 0, byteText.Length);

            //Base64形式(64種類の英数字で表現)で返す
            return encryptText;
        }
        private string Decript(byte[] byteText) {



            //暗号化方式はAES
            AesManaged aes = new AesManaged();
            //鍵の長さ
            aes.BlockSize = 128;
            //暗号利用モード
            aes.Mode = CipherMode.CBC;

            aes.IV = Encoding.UTF8.GetBytes(AesIV);
            aes.Key = Encoding.UTF8.GetBytes(AesKey);
            //パティング
            aes.Padding = PaddingMode.PKCS7;


            //複合化
            byte[] DecriptText = aes.CreateDecryptor().TransformFinalBlock(byteText, 0, byteText.Length);

            //Base64形式(64種類の英数字で表現)で返す
            return Encoding.UTF8.GetString(byteText);
        }

        static void Main(string[] args) {

            Program p = new Program();
            //暗号化
            byte[] encrypted = p.Encrypt("Hello World");

            Console.WriteLine("暗号化の後の文字列:{0}", Convert.ToBase64String(encrypted));


            Console.WriteLine("複合化の後の文字列:{0}", p.Decript(encrypted));

            Console.ReadLine();
        }
         

    }
}
