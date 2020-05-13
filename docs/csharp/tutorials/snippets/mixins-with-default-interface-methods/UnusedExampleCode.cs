using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using mixins_with_interfaces;

// This file and namespace contains interim samples that are
// included in the text, but aren't part of the fial sample.
// We want these compiled by our CI build, but they won't be
// run in the sample.
namespace NotUsedInFinalSample
{
    // <SnippetILightInterfaceV1>
    public interface ILight
    {
        void SwitchOn();
        void SwitchOff();
        bool IsOn();
    }
    // </SnippetILightInterfaceV1>

    // <SnippetOverheadLightV1>
    public class OverheadLight : ILight
    {
        private bool isOn;
        public bool IsOn() => isOn;
        public void SwitchOff() => isOn = false;
        public void SwitchOn() => isOn = true;

        public override string ToString() => $"The light is {(isOn ? "on" : "off")}";
    }
    // </SnippetOverheadLightV1>

    // <SnippetPureTimerInterface>
    public interface ITimerLight : ILight
    {
        Task TurnOnFor(int duration);
    }
    // </SnippetPureTimerInterface>
}
