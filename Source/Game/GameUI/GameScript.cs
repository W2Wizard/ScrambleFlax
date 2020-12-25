// Copyright W2.Wizard & Sebb 2020 All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using FlaxEngine;
using FlaxEngine.GUI;

namespace Game
{
    public class GameScript : Script
    {
        public JsonAsset WordList;
        
        public UIControl InputControl;

        public override void OnStart()
        {
            InputControl.Get<TextBoxBase>().TextBoxEditEnd += OnTextBoxEditEnd;
        }

        private void OnTextBoxEditEnd(TextBoxBase TextBox)
        {
            var wordData = WordList.CreateInstance() as WordData;
            
            TextBox.Text = "";
        }
    }
}
