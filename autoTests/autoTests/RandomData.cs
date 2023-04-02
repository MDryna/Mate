using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Faker;

namespace autoTests
{
	public class RandomData
	{

        // Generate a random data (A-Z,-!{]5/:) with a given size
        public static string GenerateRandomData(int size)
		{
			int[] array = new int[size];
			Random random = new Random();
			string data = "";

			for (int i = 0; i < array.Length; i++)
			{
				array[i] = random.Next(33, 125);
                data += (char)array[i];
			}
			return data;
		}



		// Generate a random string-emall (A-Z) with a given size

		public static string RandomString(int size, bool lowerCase = true)

		{

			StringBuilder builder = new StringBuilder();

			Random random = new Random();

			char ch;

			for (int i = 0; i < size; i++)

			{

				ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));

				builder.Append(ch);

			}

			if (lowerCase)

				return builder.ToString().ToLower();

			return builder.ToString();


        }
		//метод перевикористовує RandomString + додає nameDomen

        public static string GenereteRandomEmail(string nameDomen, int size = 10)
        {
            string randomEmail = RandomString(size) + nameDomen;

            return randomEmail;

        }


        // Default size of random password is 10
        private static string CreateRandomPassword(int length = 10)
        {
            // Create a string of characters, numbers, special characters that allowed in the password
            string validChars = "ABCDEFGHJKLMNOPQRST123abcdefghijklrstuvwxyz0123456789!";
            Random random = new Random();

            // Select one random character at a time from the string
            // and create an array of chars
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }

        public static string GenereteRandomPassword(int size = 10)
        {
            string randomPassword = CreateRandomPassword(size) + "!";

            return randomPassword;

        }
    }
}

