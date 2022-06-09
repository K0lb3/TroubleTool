using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace TroubleTool
{
    static class Crypt
    {
        private static readonly string keyInit = "d4152d461ab5308429e49774a042a318";
        private static readonly string ivInit = "86afc43868fea6abd40fbf6d5ed50905";
        private static byte[] GenerateIV(byte[] word)
        {
            byte[] crypto = new byte[16];
            int v4 = 0;
            int v5 = 0;
            int v6, v7, v8, v9;
            while (v4 < 0x20)
            {
                v6 = word[v5];
                v7 = word[v4 + 1];

                if ((v6 & 0x40) != 0)
                {
                    if ((v6 & 0x20) != 0)
                        v8 = v6 - 87;
                    else
                        v8 = v6 - 55;
                }
                else
                    v8 = v6 - 48;

                if ((v7 & 0x40) != 0)
                {
                    if ((v7 & 0x20) != 0)
                        v9 = v7 - 87;
                    else
                        v9 = v7 - 55;
                }
                else
                    v9 = v7 - 48;


                crypto[v5 >> 1] = (byte)(v9 | (16 * v8));
                v4 += 2;
                v5 = v4;
            }
            return crypto;
        }

        private static byte[] GenerateKey(byte[] a1)
        {
            long r9_1; // r9
            long r10_1; // r10
            long rax1; // rax
            int ebx5; // ebx
            long r11_6; // r11
            byte dl7; // dl
            byte r8_7; // r8
            byte al9; // al
            byte cl14; // cl
            byte[] key = new byte[16];

            r9_1 = a1.Length;
            rax1 = a1.Length;

            if (rax1 == 16)
            {
                ebx5 = 0;
                if (r9_1 > 0)
                {
                    r11_6 = 0;
                    do
                    {
                        dl7 = a1[r11_6];
                        r8_7 = a1[ebx5 + 1];
                        if ((dl7 & 0x40) != 0)
                        {
                            if ((dl7 & 0x20) != 0)
                                al9 = ((byte)(dl7 - 87));
                            else
                                al9 = (byte)(dl7 - 55);
                        }
                        else
                        {
                            al9 = (byte)(dl7 - 48);
                        }
                        if ((r8_7 & 0x40) != 0)
                        {
                            if ((r8_7 & 0x20) != 0)
                                cl14 = (byte)(r8_7 - 87);
                            else
                                cl14 = (byte)(r8_7 - 55);
                        }
                        else
                        {
                            cl14 = (byte)(r8_7 - 48);
                        }
                        ebx5 += 2;
                        rax1 = cl14 | (16 * al9);
                        key[r11_6 >> 1] = (byte)rax1;
                        r11_6 = ebx5;
                    } while (ebx5 < r9_1);
                }
            }
            return key;
        }

        public static byte[] Encrypt(byte[] cipherText)
        {
            byte[] encrypted;

            using (var aes = new AesManaged
            {
                KeySize = 16 * 8,
                BlockSize = 16 * 8,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            })
            {
                using (var encrypter = aes.CreateEncryptor(GenerateKey(Encoding.ASCII.GetBytes(keyInit)), GenerateIV(Encoding.ASCII.GetBytes(ivInit))))
                {
                    using (var cipherStream = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(cipherStream, encrypter, CryptoStreamMode.Write))
                        using (var binaryWriter = new BinaryWriter(cryptoStream))
                        {
                            //Encrypt Data
                            binaryWriter.Write(cipherText);
                        }

                        encrypted = cipherStream.ToArray();
                    }

                }
            }
            return encrypted;
        }

        public static byte[] Decrypt(byte[] cipherText)
        {
            byte[] decrypted;
            using (var aes = new AesManaged
            {
                KeySize = 16 * 8,
                BlockSize = 16 * 8,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.Zeros
            })
            {
                using (var encrypter = aes.CreateDecryptor(GenerateKey(Encoding.ASCII.GetBytes(keyInit)), GenerateIV(Encoding.ASCII.GetBytes(ivInit))))
                {
                    using (var cipherStream = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(cipherStream, encrypter, CryptoStreamMode.Write))
                        using (var binaryWriter = new BinaryWriter(cryptoStream))
                        {
                            binaryWriter.Write(cipherText);
                        }

                        decrypted = cipherStream.ToArray();
                    }

                }
            }
            return decrypted;
        }
    }
}
