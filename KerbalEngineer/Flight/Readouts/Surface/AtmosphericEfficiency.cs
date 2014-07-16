﻿// Project:	KerbalEngineer
// Author:	CYBUTEK
// License:	Attribution-NonCommercial-ShareAlike 3.0 Unported

namespace KerbalEngineer.Flight.Readouts.Surface
{
    public class AtmosphericEfficiency : ReadoutModule
    {
        private bool showing;

        public AtmosphericEfficiency()
        {
            this.Name = "Atmos. Efficiency";
            this.Category = ReadoutCategory.Surface;
            this.HelpString = "Shows you vessel's efficiency as a ratio of the current velocity and terminal velocity.  Less than 1 means that you are losing efficiency due to gravity and greater than 1 is due to drag.";
            this.IsDefault = true;
        }

        public override void Update()
        {
            AtmosphericProcessor.RequestUpdate();
        }

        public override void Draw()
        {
            var tempShowing = this.showing;
            this.showing = false;

            if (FlightGlobals.ActiveVessel.atmDensity > 0)
            {
                this.showing = true;
                this.DrawLine(AtmosphericProcessor.Efficiency.ToString("F2"));
            }

            if (this.showing != tempShowing)
            {
                this.ResizeRequested = true;
            }
        }

        public override void Reset()
        {
            FlightEngineerCore.Instance.AddUpdatable(AtmosphericProcessor.Instance);
        }
    }
}