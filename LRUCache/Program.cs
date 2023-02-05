namespace LRUCache
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LRUCache<string, string> cache = new LRUCache<string, string>(5); 

            cache.Put("a", "b");    
            cache.Put("d", "c");
            cache.Put("e", "f");
            cache.Put("g", "h");
            cache.Put("q", "p");

            var temp = cache.TryGetValue("a", out string temp2);
            ;
            cache.Put("a", "c"); 
            temp = cache.TryGetValue("x", out string temp3);
            temp = cache.TryGetValue("c", out string temp4);
            cache.Put("d", "c");
            cache.Put("v", "n");
            cache.Put("t", "t");
            cache.Put("t", "r");
            cache.Put("w", "a");
            cache.Put("q", "o");
            cache.TryGetValue("g", out string temp1);
            ;

        }
    }
}