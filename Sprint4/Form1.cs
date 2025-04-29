using System;
using System.Collections.Generic;
using System.Linq;
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
            LoadDictionary("CommonWords.txt"); // Load the dictionary from a file
            UpdateWordCount();
            var allWords = trie.AutoComplete("");
            foreach (var word in allWords)
                Suggestions.Items.Add(word);

        }

        // Insert button clicked
        private void btnInsert_Click(object sender, EventArgs e)
        {
            string word = txtInput.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(word))
                return;

            // Check if word is already in the Trie
            if (trie.FindWord(word))
            {
                MessageBox.Show($"'{word}' is already in the dictionary.");
                return;
            }

            // Insert into Trie and update ListBox
            trie.Insert(word);
            Suggestions.Items.Add(word);
            Suggestions.Sorted = true; // keep list sorted

            // Append to file
            try
            {
                System.IO.File.AppendAllText("CommonWords.txt", word + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to file: {ex.Message}");
            }

            txtInput.Clear();
            UpdateWordCount(); // Update the word count label  
        }


        // AutO update every time the text changes in txtInput
        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            string prefix = txtInput.Text.Trim().ToLower();

            Suggestions.Items.Clear();

            // Don't show suggestions for empty input
            if (prefix == "")
                return;

            List<string> suggestions = trie.AutoComplete(prefix);

            if (suggestions.Count == 0)
            {
                Suggestions.Items.Add("No matches found.");
            }
            else
            {
                foreach (var suggestion in suggestions)
                {
                    Suggestions.Items.Add(suggestion);
                }
            }
        }

        // Update the word count label
        private void UpdateWordCount()
        {
            int count = trie.AutoComplete("").Count;  // Get all stored words
            lblWordCount.Text = $"Words in Dictionary: {count}";
        }




        //Button to Remove the selected word, NOT implemented yet
        private void btnRemove_Click(object sender, EventArgs e)
        {
            string word = txtInput.Text.Trim().ToLower();
            // Only remove if the input is not empty
            if (word != "")
            {
                //trie.Remove(word);  // Remove word from trie
                txtInput.Clear();   // Clear input box
                // Show confirmation in ListBox by listing all stored words
                Suggestions.Items.Clear();
                var allWords = trie.AutoComplete(""); // get all words in trie
                foreach (var w in allWords)
                    Suggestions.Items.Add(w);
            }
            UpdateWordCount();
        }



        //Load the dictionary from a file
        private void LoadDictionary(string filePath)
        {
            try
            {
                foreach (string line in System.IO.File.ReadLines(filePath))
                {
                    string word = line.Trim().ToLower();
                    if (!string.IsNullOrEmpty(word))
                        trie.Insert(word);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dictionary: {ex.Message}");
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            string word = txtInput.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(word))
                return;

            // Check if word exists in Trie
            if (!trie.FindWord(word))
            {
                MessageBox.Show($"'{word}' does not exist in the dictionary.");
                return;
            }

            // Delete from Trie
            trie.Delete(word);

            // Remove from ListBox
            Suggestions.Items.Remove(word);

            // Remove from file
            try
            {
                var allLines = System.IO.File.ReadAllLines("CommonWords.txt").ToList();
                allLines.Remove(word); // Remove the word
                System.IO.File.WriteAllLines("CommonWords.txt", allLines); // Save the new list
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting from file: {ex.Message}");
            }

            MessageBox.Show($"'{word}' has been deleted.");
            txtInput.Clear();
            UpdateWordCount();
        }

        private void btnSearchGoogle_Click(object sender, EventArgs e)
        {
            string wordToSearch = txtInput.Text.Trim();

            if (string.IsNullOrEmpty(wordToSearch))
            {
                MessageBox.Show("Please enter a word to search.");
                return;
            }

            // Format the word to search for Google (URL encode the word)
            string searchUrl = "https://www.google.com/search?q=" + Uri.EscapeDataString(wordToSearch) + " definition";

            // Open the default web browser and search Google
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = searchUrl,
                UseShellExecute = true
            });

        }
    }
}
