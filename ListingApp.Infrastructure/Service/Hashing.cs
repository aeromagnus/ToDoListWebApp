using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.Infrastructure.Others
{
    public class Hashing
    {   //Define a stattic function for password parenthesis

        //public static string HashPassword(string password)
        //{
        //    // Create a SHA256   
        //    using (SHA256 sha256Hash = SHA256.Create())
        //    {
        //        // ComputeHash - returns byte array  
        //        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

        //        // Convert byte array to a string   
        //        StringBuilder builder = new StringBuilder();
        //        for (int i = 0; i < bytes.Length; i++)
        //        {
        //            builder.Append(bytes[i].ToString("x2"));
        //            //32 bytes string is changed  to 64 bytes
        //        }
        //        return builder.ToString();
        //    }
        //}

        public static string hashPassword(string password)
        {
            ////Create a SHA256
            // using (SHA256 sha256Hash = SHA256.Create())
            // {
            //     // ComputeHash - returns byte array  
            //     byte[] hashedPass = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            //     // Convert byte array to a string   
            //     StringBuilder builder = new StringBuilder();
            //     for (int i = 0; i < bytes.Length; i++)
            //     {
            //         var hashedpass = builder.Append(bytes[i].ToString("x2"));
            //         //32 bytes string is changed  to 64 bytes
            //         return builder.ToString();

            //     }
            // }


            // generating random number salt through RNGCryptoServiceProvider
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            //adding salt into the password
            var passWithSalt = new Rfc2898DeriveBytes(password, salt, 10000);

            //pass = 20 byte and salt = 16 byte totalbyte = 36
            //placing the byte string into array
            byte[] hash = passWithSalt.GetBytes(20);


            //changing the 20 byte to 36 bytes
            byte[] hashBytes = new byte[36];

            //Appending or Preppending
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            String hashedPasswordWithSalt = Convert.ToBase64String(hashBytes);
            return hashedPasswordWithSalt;
        }
    }
}
