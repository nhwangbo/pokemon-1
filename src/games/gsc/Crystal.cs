using System.Collections.Generic;
using System;

public class Crystal : Gsc {

    public Crystal(bool speedup = false, string rom = "roms/pokecrystal.gbc") : base(rom, speedup ? SpeedupFlags.NoVideo | SpeedupFlags.NoSound : SpeedupFlags.None) { }

    public override void Press(params Joypad[] joypads) {
        foreach(Joypad joypad in joypads) {
            RunUntil("GetJoypad");
            InjectMenu(joypad);
            AdvanceFrame();
        }
    }

    public override void RandomizeRNG(Random random) {
        byte[] randomValues = new byte[3];
        random.NextBytes(randomValues);

        byte[] savestate = SaveState();
        savestate[642 + 0x104] = randomValues[0]; // rdiv
        savestate[642 + 0x1E1] = randomValues[1]; // hRandomAdd
        savestate[642 + 0x1E2] = randomValues[2]; // hRandomSub
        LoadState(savestate);
    }

    public GscPokemon GetBattleMon(bool enemy) {
        return new GscPokemon(this, enemy);
    }
}