namespace PAA_Lab3
{
    public static class ArrayHelper
    {
        private static readonly string[] s_rowsSeparators = { "[[", "], [", "]]" };
        private static readonly char[] s_itemsSeparators = { ',', ' ' };

        public static T[][] ReadFromFile<T>(string path)
        {
            return File.ReadAllText(path)
                .Split(s_rowsSeparators, StringSplitOptions.RemoveEmptyEntries)
                .Select(r => r
                    .Split(s_itemsSeparators, StringSplitOptions.RemoveEmptyEntries)
                    .Select(i => (T)Convert.ChangeType(i, typeof(T)))
                    .ToArray())
                .ToArray();
        }

        public static void WriteArray<T>(T[][] array)
        {
            Console.WriteLine(
                string.Join(
                    Environment.NewLine,
                    array.Select(row => string.Join(' ', row))
                )
            );
        }

        public static bool AreArraysEqual<T>(T[][] array1, T[][] array2)
        {
            return array1
                .Zip(array2)
                .All(t => t.First.SequenceEqual(t.Second));
        }

        public static bool AreArraysEqual<T>(IList<T[][]> arrays)
        {
            return arrays.All(array => AreArraysEqual(arrays[0], array));
        }
    }
}
