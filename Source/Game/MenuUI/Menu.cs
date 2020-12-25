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

        public Prefab GameUI;

        public SceneAnimation Animation;
        
        public override void OnStart()
        {
            InitButton.Get<Button>().ButtonClicked += button =>
            {
                PrefabManager.SpawnPrefab(GameUI);
            };
        }
    }
}
