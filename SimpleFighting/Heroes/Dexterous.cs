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
            int ultDamage = 0;
            int chance = rnd.Next(1, 101);
            if (chance <= 25)
            {
                ultDamage = this.Damage * 3;
                Console.WriteLine("{0} ошеломляет противника своей ловкостью и наносит удар второй рукой на {1} очков здоровья\n", this.Name, ultDamage);
            }
            else
                Console.WriteLine("{0} Не смог провести незаметный удар и противник парировал его", this.Name);
            return ultDamage;
        }

    }
}
