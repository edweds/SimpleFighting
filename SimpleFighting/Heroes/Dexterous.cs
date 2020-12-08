using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFighting
{
    public class Dexterous:BaseFighter
    {
        public Dexterous(string heroName= "Имя должен выбрать игрок") :base(heroName, "Изворотливый ловкач",
        "Ловкость рук - Есть 25% шанс запутать противника и незаметно ударить второй рукой." +
        "Такой удар считается критическим попаданием (x3)", 3, 4, 3)
        {

        }

        public override int UltAbilittyUsing()
        {
            int chance = rnd.Next(1, 101);
            if (chance <= 25)
                return Damage * 3;
            return 0;
        }

    }
}
