using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acmenu
{
    public class Offsets
    {
        public static int
            iViewMatrix = 0x17DFFC,
            iLocalPlayer = 0x0018AC00,
            iEntityList = 0x00191fCC,
            iEntityCount = 0x18AC0C,

            // offsets from entity class
            vHead = 0x4,
            vFeet = 0x28,
            vAngles = 0x34,
            iHealth = 0xEC,
            iDead = 0xB4,
            sName = 0x205,
            iTeam = 0x30C,
            iCurrentAmmo = 0x140,
            iCurrentPistol = 0x12c,
            iCooldown = 0x164
            ;
    }
}
