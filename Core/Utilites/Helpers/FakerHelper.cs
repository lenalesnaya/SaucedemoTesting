using Bogus;

namespace Core.Utilites.Helpers
{
    public static class FakerHelper
    {
        private static readonly Faker faker = new();

        public static string GetAlphabeticStringRandomValue(int length) =>
            faker.Random.String2(length, "abcdefghijklmnopqrstuvwxyz" + "abcdefghijklmnopqrstuvwxyz".ToUpper());

        public static string GetNumericStringRandomValue(int length) =>
            faker.Random.String(length, '0', '9');

        public static string GetAlphaNumericStringRandomValue(int minLength, int maxLength) =>
            faker.Random.AlphaNumeric(new Random().Next(minLength, maxLength));

        public static string GetAlphaNumericStringRandomValue(int length) =>
            faker.Random.AlphaNumeric(length);

        public static string GetAlphaSpecialSymbolsStringRandomValue(int length) =>
            faker.Random.String2(length, "abcdefghijklmnopqrstuvwxyz" + "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~");

        public static string GetAlphaNumericSpecialSymbolsStringRandomValue(int length) =>
            faker.Random.String(length, '!', '~');

        public static string GetCyrillicLettersStringRandomValue(int length) =>
            faker.Random.String(length, 'À', 'ÿ');

        public static string GetSymbolsSpecifiedRangeStringRandomValue(int length, char minValue, char maxValue) =>
            faker.Random.String(length, minValue, maxValue);
    }
}