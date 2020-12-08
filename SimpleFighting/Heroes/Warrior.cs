using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFighting
{
    public class Warrior:BaseFighter
    {
        public Warrior(string heroName= "Имя должен выбрать игрок") :base (heroName, "Безжалостный воин", 
            "Ярость, после удара воин впадает в ярость и триждыы бьет противника щитом. "+
            "Урон каждого удара равен показателю силы", 5,0,5)
        {

        }
        public override int UltAbilittyUsing()
        {
            return Strength * 3;
        }
    }
}
