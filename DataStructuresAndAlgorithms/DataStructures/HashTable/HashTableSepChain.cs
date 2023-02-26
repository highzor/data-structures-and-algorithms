using System.Runtime.CompilerServices;

namespace DataStructuresAndAlgorithms.DataStructures.HashTable;

public class HashTableSepChain
{
    public IList<Entry>? Bucket;
    public IList<Entry>[] HashTable;
    public int Size, Threshold, Count = 0;
    public double LoadFactor = 0;
    const double DEFAULT_LOADFACTOR = 0.75;

    public class Entry
    {
        public string Key;
        public string Value;
        public int HashCode;

        public Entry(string key, string value)
        {
            Key = key;
            Value = value;
            HashCode = GetHashCode(key);
        }

        public static int GetHashCode(string key)
        {
            var hashKeyValue = 0;

            for (int i = 0; i < key.Length; i++)
            {
                var charCode = key[i] - 96;
                hashKeyValue = hashKeyValue * 27 + charCode;
            }

            Console.WriteLine($"{nameof(GetHashCode)}: Key = {key}, RAW HASH = {hashKeyValue}");
            return hashKeyValue;
        }

        public override string ToString()
        {
            return $" {{ Key : {Key} -> Value : {Value} }} ";
        }
    }

    public HashTableSepChain(int size, double[] loadFactor = null)
    {
        HashTable = new List<Entry>[size];
        Size = size;

        if (loadFactor?.Length > 0)
        {
            LoadFactor = loadFactor[0];
            Threshold = (int)LoadFactor * size;
        }
        else
            Threshold = (int)DEFAULT_LOADFACTOR * size;
    }

    public HashTableSepChain() {}

    public void Add(string key, string value)
    {
        var entry = new Entry(key, value);
        Console.WriteLine($"{nameof(Add)}: CURRENT COUNT = {Count}, CURRENT THRESHOLD = {Threshold}");

        if (Count > Threshold)
            resizeTable();

        var hashKey = compressionFunction(entry.HashCode);

        var bucket = HashTable[hashKey];

        if (bucket == null)
            bucket = new List<Entry>();

        bucket.Add(entry);
        HashTable[hashKey] = bucket;
        Count++;
    }

    public Entry? Find(string key)
    {
        var hashKey = compressionFunction(Entry.GetHashCode(key));

        var bucket = HashTable[hashKey];

        foreach (var entry in bucket)
        {
            if (entry.Key == key)
            {
                Console.WriteLine($"{nameof(Find)}: ENTRY FOUND {{ Key : {entry.Key} -> Value : {entry.Value} }} AT INDEX [{hashKey}]");
                return entry;
            }
        }

        return null;
    }

    public void Remove(string key)
    {
        var hashKey = compressionFunction(Entry.GetHashCode(key));

        var bucket = HashTable[hashKey];

        foreach (var entry in bucket.ToList())
        {
            if (entry.Key == key)
            {
                Console.WriteLine($"{nameof(Remove)}: ENTRY FOUND & REMOVED {{ Key : {entry.Key} -> Value : {entry.Value} }} AT INDEX [{hashKey}]");
                bucket.Remove(entry);
            }
        }

        if (bucket.Count == 0)
            HashTable[hashKey].Clear();
    }
    private void resizeTable()
    {
        Size *= 2;
        Threshold = (int)LoadFactor * Size;
        Console.WriteLine($"{nameof(resizeTable)}: DOUBLED SIZE = {Size}");
        IList<Entry>[] newTable = new List<Entry>[Size];

        for (var i = 0; i < HashTable.Length; i++)
        {
            if (HashTable[i] != null)
            {
                foreach (var entry in HashTable[i])
                {
                    var newIndex = compressionFunction(entry.HashCode);
                    var bucket = newTable[newIndex];

                    if (bucket == null)
                        bucket = new List<Entry>();

                    bucket.Add(entry);
                    newTable[newIndex] = bucket;
                }
            }
        }

        HashTable = newTable;
    }

    private void printTable()
    {
        for (int i = 0; i <= HashTable.Length - 1; i++)
        {
            Console.WriteLine($"Index [{i}] => {HashTable[i]?.Count()}");
        }
    }

    private int compressionFunction(int rawHash)
    {
        return Math.Abs(rawHash) % Size;
    }

    public void Start()
    {
        var hashTable = new HashTableSepChain(10);
        hashTable.Add("abc", "some text");
        hashTable.Add("def", "some text");
        hashTable.Add("ghi", "some text");
        hashTable.Add("jkl", "some text");
        hashTable.Add("mno", "some text");
        hashTable.Add("pqr", "some text");
        hashTable.Add("stu", "some text");
        hashTable.Add("vwx", "some text");
        hashTable.Add("xyz", "some text");

        hashTable.printTable();

        hashTable.Find("xyz");

        hashTable.Remove("mno");

        hashTable.printTable();
    }
}