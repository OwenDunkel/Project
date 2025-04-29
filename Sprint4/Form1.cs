using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutomaticWordComplete
{
    public partial class Form1 : Form
    {
        // Create an instance of Trie to store the words
        private Trie trie = new Trie();

        public Form1()
        {
            InitializeComponent();
        }

        // Insert button clicked
        private void btnInsert_Click(object sender, EventArgs e)
        {
            string word = txtInput.Text.Trim();

            // Only insert if the input is not empty
            if (word != "")
            {
                trie.Insert(word);  // Add word to trie
                txtInput.Clear();   // Clear input box

                // Show confirmation in ListBox by listing all stored words
                lstSuggestions.Items.Clear();
                var allWords = trie.AutoComplete(""); // get all words in trie
                foreach (var w in allWords)
                    lstSuggestions.Items.Add(w);
            }
        }

        // Search button clicked
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string word = txtInput.Text.Trim();

            if (trie.FindWord(word))
            {
                MessageBox.Show($"'{word}' exists in the Trie!");

                // Highlight the word if it's in the list
                lstSuggestions.ClearSelected();
                int index = lstSuggestions.Items.IndexOf(word);
                if (index >= 0)
                {
                    lstSuggestions.SetSelected(index, true);
                }
            }
            else
            {
                MessageBox.Show($"'{word}' does not exist.");
            }
        }



        // AutO update every time the text changes in txtInput
        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            string prefix = txtInput.Text.Trim();

            lstSuggestions.Items.Clear();

            // Don't show suggestions for empty input
            if (prefix == "")
                return;

            List<string> suggestions = trie.AutoComplete(prefix);

            if (suggestions.Count == 0)
            {
                lstSuggestions.Items.Add("No matches found.");
            }
            else
            {
                foreach (var suggestion in suggestions)
                {
                    lstSuggestions.Items.Add(suggestion);
                }
            }
        }


    }
}
