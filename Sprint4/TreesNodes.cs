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




        // Deletes word from the Trie
        public void Delete(string word)
        {
            DeleteRecursive(root, word, 0);
        }

        // Helper method for recursive deletion from Trie
        private bool DeleteRecursive(TrieNode node, string word, int index)
        {
            if (index == word.Length)
            {
                // If we reached the end of the word, mark it as not a valid word
                if (!node.IsEndOfWord) return false; // Word doesn't exist

                node.IsEndOfWord = false;
                return node.Children.Count == 0; // If node has no children, it's safe to delete
            }

            char ch = word[index];
            if (!node.Children.ContainsKey(ch)) return false; // Word doesn't exist

            bool shouldDeleteCurrentNode = DeleteRecursive(node.Children[ch], word, index + 1);

            // If child node can be deleted, remove it
            if (shouldDeleteCurrentNode)
            {
                node.Children.Remove(ch);
                return node.Children.Count == 0 && !node.IsEndOfWord;
            }

            return false;
        }


    }


}

    
