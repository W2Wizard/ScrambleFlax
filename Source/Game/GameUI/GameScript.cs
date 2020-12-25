// Copyright W2.Wizard & Sebb 2020 All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;
using FlaxEditor.Content.Settings;
using FlaxEngine;
using FlaxEngine.GUI;

namespace Game
{
    /// <summary>
    /// Script that contains the majority of the games functionality
    /// </summary>
    public class GameScript : Script
    {

        #region Fields
        
        [Header("UI Input")]
        
        [EditorOrder(0)]
        [Tooltip("Reference to Text Input")]
        public UIControl TextInput;

        [EditorOrder(1)]
        [Tooltip("Reference to the text which is supposed to be guessed")]
        public UIControl WordGuessInput;

        [EditorOrder(2)]
        [Tooltip("Reference to the text which tells the user if the input was right or wrong")]
        public UIControl StateInput;

        #endregion
        
        
        #region Properties

        private RichTextBox Input;

        private Label WordGuess;

        private Label State;
        
        private string CurrentWord;

        #endregion

        public override void OnStart()
        {
            Input = TextInput.Get<RichTextBox>();
            WordGuess = WordGuessInput.Get<Label>();
            State = StateInput.Get<Label>();

            // Create a new word for the start guess
            NewWord();
            
            // Subscribe to the EditEnd action
            Input.EditEnd += InputOnEditEnd;
        }

        private void InputOnEditEnd()
        {
            // Input is correct, create new shuffled word!
            if (Input.Text.ToLower() == CurrentWord)
            {
                State.Text = "Correct!";
                State.TextColor = Color.Green;
                
                Input.Text = "";
                
                // Insert a new word
                NewWord();
            }
            // Wrong Input
            else
            {
                State.Text = "Wrong!";
                State.TextColor = Color.Red;
            }
        }

        private void NewWord()
        {
            A:
            // Pick a random word
            CurrentWord = WordData.Words[new Random().Next(WordData.Words.Length)];
            
            var shuffleWord = Shuffle(CurrentWord);

            // By chance they can be the same, so we shuffle again incase it happens.
            if (shuffleWord == CurrentWord) goto A;

                // Print for debug
            Debug.Log("Current Word: " + CurrentWord);
            WordGuess.Text = shuffleWord;
        }
        
        // Shuffle the word
        public static string Shuffle(string str)
        {
            char[] array = str.ToCharArray();
            
            int len = array.Length;
            
            while (len > 1)
            {
                len--;
                
                int rnd = new Random().Next(len + 1);
                var value = array[rnd];
                
                array[rnd] = array[len];
                array[len] = value;
            }
            return new string(array);
        }
    }
}
