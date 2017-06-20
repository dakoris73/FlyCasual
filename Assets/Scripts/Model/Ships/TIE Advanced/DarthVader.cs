﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BUG: Cannot start new subphases from free action subphase
// TODO: Move from end of activation to after action is taken

namespace Ship
{
    namespace TIEAdvanced
    {
        public class DarthVader : TIEAdvanced
        {

            public DarthVader() : base()
            {
                IsHidden = true;

                PilotName = "Darth Vader";
                ImageUrl = "https://vignette1.wikia.nocookie.net/xwing-miniatures/images/f/f7/Darth_Vader.png";
                IsUnique = true;
                PilotSkill = 9;
                Cost = 29;
                AddUpgradeSlot(Upgrade.UpgradeSlot.Elite);
            }

            public override void InitializePilot()
            {
                base.InitializePilot();

                OnMovementFinish += DoSecondAction;
            }

            private void DoSecondAction(GenericShip ship)
            {
                if (!ship.IsSkipsActionSubPhase)
                {
                    ship.GenerateAvailableActionsList();
                    List<ActionsList.GenericAction> actions = ship.GetAvailableActionsList();
                    AskPerformFreeAction(actions);
                }
            }

        }
    }
}
