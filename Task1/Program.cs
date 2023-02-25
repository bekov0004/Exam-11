List<string> words = new List<string> { "apple", "banana", "orange",
    "grape", "mango" };

var query = (
    from w in words
    orderby w.Length descending 
    select w).Take(1).ToList();

Console.WriteLine(string.Join(",",query));
