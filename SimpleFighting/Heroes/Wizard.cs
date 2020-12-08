using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFighting
{
     public class Wizard:BaseFighter
    {
        public Wizard(string heroName= "Имя должен выбрать игрок") :base(heroName, "Могущественный маг",
         "Концентрация - Ничто не способно вывести мага из равновесия. Маг на секунду концентрируется и" +
         "пускает в противника огненный шар на 1-60 урона", 2,3,5)
        {

        }

        public override int UltAbilittyUsing()
        {
            return rnd.Next(0, 61);
        }

    }
}
;