using System;

namespace TargAutoLibrary
{
    [Flags]
    public enum OptiuniDotari //enum cu flag(permite combinarea optiunilor)
    {
        Nimic = 0,
        AerConditionat = 1,
        Navigatie = 2,
        CutieAutomata = 4,
        ScauneIncalzite = 8,
        PilotAutomat = 16,
        CameraParcare = 32
    }
}