using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutomaticWordComplete
{
    public partial class Form1 : Form
    {
        // Trie instance to store words
        private Trie trie = new Trie();

        // Constructor to initialize the form design
        public Form1()
        {
            InitializeComponent();
        }

        // Event handlers for button clicks
        private void btnInsert_Click(object sender, EventArgs e)
        {
            string word = txtInput.Text.Trim();
            if (word != "")
            {
                trie.Insert(word);
                MessageBox.Show($"'{word}' inserted.");
                txtInput.Clear();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string word = txtInput.Text.Trim();
            if (trie.FindWord(word))
                MessageBox.Show($"'{word}' exists in the Trie!");
            else
                MessageBox.Show($"'{word}' does not exist.");
        }

        private void btnAutoComplete_Click(object sender, EventArgs e)
        {
            string prefix = txtInput.Text.Trim();
            lstSuggestions.Items.Clear();
            List<string> suggestions = trie.AutoComplete(prefix);
            foreach (var suggestion in suggestions)
                lstSuggestions.Items.Add(suggestion);
        }
    }
}
