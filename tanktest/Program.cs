using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
       public int Dodge;
       public static Animation animation = new Animation();
        static void Main(string[] args)
        {
          
            Tank myTank = new Tank();
            Tank myTank2 = new Tank();

            myTank.armor = 100;
            myTank.shellsRemaining = 25;
            myTank.Dmg = 15;
            myTank.HeavyDmg = 100;
            myTank.HeavyCharge = 0;
            myTank.Dodge = 0;


            myTank2.armor = 100;
            myTank2.shellsRemaining = 25;
            myTank2.Dmg = 15;
            myTank2.HeavyDmg = 100;
            myTank2.HeavyCharge = 0;
            myTank2.Dodge = 0;



            

            Console.WriteLine("How much health do you want the Tanks to have?");
                int Health = Convert.ToInt32(Console.ReadLine());

                myTank.armor = Health;
                myTank2.armor = Health; 

                Console.Clear();

                Console.WriteLine("How many bullets do you want?");
                int bullets = Convert.ToInt32(Console.ReadLine());

                myTank.shellsRemaining = bullets;
                myTank2.shellsRemaining = bullets;

                Console.Clear();

            Console.WriteLine("Second Tank do you wanna dodge the first shot? press (D) | (Any Key) to skip");
            ConsoleKeyInfo initialDodge = Console.ReadKey();
            if (initialDodge.Key == ConsoleKey.D)
            {
                myTank2.Dodge++;
            }

            while (myTank2.armor > 0 && myTank.armor > 0 && myTank.shellsRemaining > 0 && myTank2.shellsRemaining > 0)
            {
                   
                Console.Clear();

                //____________________________________________________________________________________________________________________________________________________________//
                // Tank 1
                menu();
              
                if (myTank.armor > 0)
                {
                    
                    Console.WriteLine("First Tank you're up");
                    Console.WriteLine("");
                    if (myTank.HeavyCharge >= 5)
                    {
                        
                        Console.WriteLine("You're HeavyShot is ready || (H) for heavy | (S) for normal shot | (D) to dodge ");
                    }
                    else
                    {
                        
                        Console.WriteLine("Shoot the second Tank? (S) to shoot | (D) to dodge");
                    }

                    ConsoleKeyInfo Shot = Console.ReadKey();

                    

                    if (myTank.HeavyCharge >= 5 && Shot.Key == ConsoleKey.H)
                    {
                        if (Shot.Key == ConsoleKey.H)
                        {
                            myTank.shootHeavy(myTank2);
                            myTank.HeavyCharge -= 5;
                            menu();
                        }

                        if (myTank2.Dodge == 1)
                        {

                            Console.Clear();
                            menu();
                            Console.WriteLine("The second Tank has dodged you're attack");
                            myTank2.Dodge--;
                            Thread.Sleep(3000);
                        }
                    }

                    else if (myTank2.armor > 0 && Shot.Key == ConsoleKey.S)
                    {
                        if (myTank2.Dodge == 0 && Shot.Key == ConsoleKey.S)
                        {
                            myTank.shootEnemy(myTank2);
                            myTank.LoseAmmo(myTank.shellsRemaining);
                            myTank.HeavyCharge++;
                            Console.SetCursorPosition(1, Console.CursorTop - 3);
                            animation.ClearCurrentConsoleLine();
                            animation.ShotVisual1();
                            
                        }
                        else if (myTank2.Dodge == 1)
                        {
                            Console.Clear();
                            menu();
                            animation.Dodge1();
                            myTank2.Dodge--;
                            myTank.LoseAmmo(myTank.shellsRemaining);
                            Thread.Sleep(3000);
                        }
                    }

                    else if (myTank2.armor > 0 && Shot.Key == ConsoleKey.D)
                    {
                        myTank.Dodge++;

                    }
                }

                Console.Clear();

                //____________________________________________________________________________________________________________________________________________________________//
                // Tank 2
                menu();
                if (myTank2.armor > 0)
                {
                    Console.WriteLine("Second Tank you're up");
                    Console.WriteLine("");
                    if (myTank2.HeavyCharge >= 5)
                    {
                        
                        Console.WriteLine("You're HeavyShot is ready || (H) for heavy | (S) for normal shot | (D) to dodge");
                    }

                    else
                    {
                        
                        Console.WriteLine("Shoot the first Tank? (S) to shoot | (D) to dodge");
                    }

                    ConsoleKeyInfo Shot2 = Console.ReadKey();

                  

                    if (myTank2.HeavyCharge >= 5 && Shot2.Key == ConsoleKey.H)
                    {
                        if (Shot2.Key == ConsoleKey.H)
                        {
                            myTank2.shootHeavy(myTank);
                            myTank2.HeavyCharge -= 5;
                            menu();
                        }

                        else if (myTank.Dodge == 1)
                        {
                            Console.Clear();
                            menu();
                            Console.WriteLine("The first Tank has dodged you're attack");
                            myTank.Dodge--;
                            Thread.Sleep(3000);
                        }
                    }

                    else if (myTank.armor > 0 && Shot2.Key == ConsoleKey.S)
                    {
                        if (Shot2.Key == ConsoleKey.S && myTank.Dodge == 0)
                        {
                            myTank2.shootEnemy(myTank);
                            myTank2.LoseAmmo(myTank2.shellsRemaining);
                            myTank2.HeavyCharge++;
                            Console.SetCursorPosition(1, Console.CursorTop - 3);
                            animation.ClearCurrentConsoleLine();
                            animation.ShotVisual2();
                            
                        }

                        else if (myTank.Dodge == 1)
                        {
                            Console.Clear();
                            menu();
                            animation.Dodge2();
                            myTank.Dodge--;
                            myTank2.LoseAmmo(myTank.shellsRemaining);
                            Thread.Sleep(3000);
                        }

                    }

                    else if (myTank.armor > 0 && Shot2.Key == ConsoleKey.D)
                    {
                        myTank2.Dodge++;

                    }

                }

                    Console.Clear();
                }

            
            if (myTank.armor <= 0)
            {
                Console.WriteLine(":/");
                Console.WriteLine("");
                Console.WriteLine("The first Tank has been defeated");
                myTank2.shellsRemaining = 0;

            }
            else if (myTank2.armor <= 0)
            {
                Console.WriteLine("U_U");
                Console.WriteLine("");
                Console.WriteLine("The second Tank has been defeated");
                myTank2.shellsRemaining = 0;

            }
            else if (myTank2.shellsRemaining == 0)
            {
                
                Console.WriteLine("0__0");
                Console.WriteLine("");
                Console.WriteLine("The first Tank wins. The second Tank used all its shells");
            }
            else if (myTank.shellsRemaining == 0)
            {
                
                Console.WriteLine("O__O");
                Console.WriteLine("");
                Console.WriteLine("the second Tank wins. The first Tank used all its shells");
            }
            Console.Read();

            void menu()
            {
                Console.WriteLine("|Tank 1 has " + myTank.armor + " Health Left || " + "tank 1 has " + myTank.shellsRemaining + " Shells left || Tank 1 has " + myTank.HeavyCharge + "/5 before it gets a heavy attack|");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                Console.WriteLine("|Tank 2 has " + myTank2.armor + " Health Left || " + "tank 2 has " + myTank2.shellsRemaining + " Shells left || Tank 2 has " + myTank2.HeavyCharge + "/5 before it gets a heavy attack|");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                Console.WriteLine("");
                                 
            }          

        }

       
        void shootEnemy(Tank target)
        {
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
       

    }
}
