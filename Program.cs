
public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; set; }

    public bool IsEndOfWord { get; set; }

    public TrieNode()
    {
        Children = new Dictionary<char, TrieNode>();
        IsEndOfWord = false;
    }
}

public class Trie
{
    private readonly TrieNode root; 

    public Trie()
    {
        root = new TrieNode();
    }

    public void Insert(string word)
    {
        TrieNode current = root;
        foreach (char ch in word)
        {
            if (!current.Children.ContainsKey(ch))
            {
                current.Children[ch] = new TrieNode(); 
            }
            current = current.Children[ch]; 
        }
        current.IsEndOfWord = true; 
    }

    private TrieNode SearchPrefix(string prefix)
    {
        TrieNode current = root;
        foreach (char ch in prefix)
        {
            if (!current.Children.ContainsKey(ch))
                return null;

            current = current.Children[ch];
        }
        return current;
    }
}
