using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tanktest
{
    class Tank
    {
       public int armor;
       public int shellsRemaining;
       public int Dmg;
       public int HeavyDmg;
       public int HeavyCharge;
    
        void shootEnemy(Tank target)
        {
            //bang
            target.TakeDamage(this.Dmg);
           
        }
        void TakeDamage(int amount)
        {
            this.armor -= amount;

        }
        void shootHeavy(Tank target)
        {
           target.TakeHeavyDmg(this.HeavyDmg);
        }
        private void TakeHeavyDmg(int amount)
        {
            this.armor -= amount;
        }    
        void LoseAmmo(int amount)
        {
            this.shellsRemaining -= 1;
        }


        static void Main(string[] args)
        {
            Tank myTank = new Tank();
            Tank myTank2 = new Tank();

            myTank.armor = 100;
            myTank.shellsRemaining = 25;
            myTank.Dmg = 15;
            myTank.HeavyDmg = 100;
            myTank.HeavyCharge = 0;
      


            
            myTank2.armor = 500;
            myTank2.shellsRemaining = 10;

            while (myTank2.armor > 0 && myTank.shellsRemaining > 0)
            {
               
                if (myTank.HeavyCharge >= 5)
                {
                    Console.WriteLine("Wanna shoot heavy charge now? y/n");

                    if (Console.ReadLine() == "y")
                    {
                        myTank.shootHeavy(myTank2);
                        myTank.HeavyCharge -= 5;
                    }
                }
                Console.Clear();
                Console.WriteLine("Tank 2 has " + myTank2.armor + " Health Left || " + "You have " + myTank.shellsRemaining + " Shells left || You have shot " + myTank.HeavyCharge + "/5 before you get a heavy attack");
                Console.WriteLine("Shoot Tank 2? y/n");
                
                if (myTank2.armor > 0 && Console.ReadLine() == "y")
                {
                    myTank.shootEnemy(myTank2);
                    myTank.LoseAmmo(myTank.shellsRemaining);
                    myTank.HeavyCharge++;
                }
                Console.Clear();
                Console.WriteLine("Tank 2 has " + myTank2.armor + " Health Left || " + "You have " + myTank.shellsRemaining + " Shells left ");
                
                if (myTank.armor > 0)
                {
                    myTank2.shootEnemy(myTank);
                }
                
               
                
               
            }

            if (myTank2.armor <= 0)
            {
                Console.WriteLine("Tank 2 defeated");
                myTank2.shellsRemaining = 0;

            }
            else if (myTank.shellsRemaining == 0 || myTank.armor == 0)
            {
                Console.Clear();
                Console.WriteLine("Game Over");
            }
                Console.Read();
            

            
        }

       
    }
}
