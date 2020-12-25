using System;
using System.Collections.Generic;
using FlaxEngine;
using FlaxEngine.GUI;

namespace Game
{

    public class Menu : Script
    {

        [Tooltip("The button that initilizes the game ui")]
        public UIControl InitButton;

        public Actor MenuUI;
        
        public Actor GameUI;

        public override void OnStart()
        {
            InitButton.Get<Button>().ButtonClicked += button =>
            {
                MenuUI.IsActive = false;
                GameUI.IsActive = true;
            };
        }
    }
}
