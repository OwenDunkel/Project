using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomaticWordComplete
{
    //represents a single Node(Character) in the Trie
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

    //stores words and finds prefixes
    public class Trie
    {
        private readonly TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }

        //adds word to Trie
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

        //finds prefix in the Trie
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

        //checks if a word exists in the Trie
        public bool FindWord(string word)
        {
            TrieNode node = SearchPrefix(word);
            return node != null && node.IsEndOfWord;
        }

        //finds words in the Trie
        private void FindWords(TrieNode node, string currentWord, List<string> results)
        {
            //checks to see if node makes a full word
            if (node.IsEndOfWord)
            {
                results.Add(currentWord);
            }

            //recursively traverses through child nodes and adds the next character to currentWord
            foreach (var child in node.Children)
            {
                FindWords(child.Value, currentWord + child.Key, results);
            }
        }

        //returns all words that start with the given prefix
        public List<string> AutoComplete(string prefix)
        {
            TrieNode prefixNode = SearchPrefix(prefix);
            List<string> results = new List<string>();

            //checks to see if none of the words have the prefix
            if (prefixNode == null)
                return results;

            //finds all words starting with this prefix
            FindWords(prefixNode, prefix, results);
            return results;
        }

    }


}

    
