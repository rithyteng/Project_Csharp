using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using game.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace game.Controllers
{
    public class Human
        {
            public string Name;
            public int Strength;
            public int Dexterity;
            public int Intelligence;
            public string Class;

            private int health;
            public int Health
            {
                get{return health;}
                set{ health = value;}
            }

            private int level;
            public int Level
            {
                get{return level;}
                set{level = value;}
            }

            private int exp;
            public int Exp
            {
                get{return exp;}
                set{exp = value;}
            }

            private int current_hp;
            public int Current_hp 
            {
                get{return current_hp;}
                set{current_hp = value;}
            }
            public Human(string name)
            {
                Name = name;
                Strength = 3;
                Dexterity = 3;
                Intelligence = 3;
                health = 100;
                level = 1;
                exp = 0;
            }

            public int Attack(Human target)
            {
                int dmg = Strength * 3;
                target.Health -= dmg;
                target.Current_hp = target.Health;
                System.Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage, {target.Name} has {target.Health} hp left");
                return target.Health;
            }
            public virtual void ShowInfo()
            {
                System.Console.WriteLine($"{Name} has {Strength} str, {Intelligence} intelligence, {Dexterity} dex, {Current_hp} current hp, {exp} exp, {health} total hp, class is {Class}");
            }
        }

        class Wizard : Human
        {
            public Wizard(string name) : base(name)
            {
                Name = name;
                Health = 50;
                Intelligence = 5;
                Class = "Wizard";
                Current_hp = Health;
            }

            public int FireBall(Human target)
            {
                if(target.Class == "Archer")
                {
                    int ex_dmg = Intelligence * 4;
                    // int s_temp = target.Health;
                    target.Current_hp -= ex_dmg;
                    // target.Health = s_temp;
                    System.Console.WriteLine($"{Name} used fireball on {target.Name} and and it was extra effective on Archer type causing {ex_dmg} damage, {target.Name} has {target.Current_hp} hp left");
                    return target.Health;
                }
                int dmg = Intelligence * 3;
                target.Health -= dmg;
                int temp = target.Health;
                target.Current_hp -= dmg;
                target.Health = temp;
                target.Current_hp = target.Health;
                System.Console.WriteLine($"{Name} used fireball on {target.Name} and inflicted {dmg} damage, {target.Name} has {target.Current_hp} left");
                return target.Health;
            }
        }
        class Archer : Human
        {
            public Archer(string name) : base(name)
            {
                Name = name;
                Health = 70;
                Dexterity = 5;
                Class = "Archer";
                Current_hp = Health;
            }

            public int SingleShot(Human target)
            {
                if(target.Class == "Samurai")
                {
                    int ex_dmg = Dexterity * 4;
                    // int temp = target.Health;
                    target.Current_hp -= ex_dmg;
                    System.Console.WriteLine($"{Name} used singleshot on {target.Name} and and it was extra effective on Samurai type causing {ex_dmg} damage, {target.Name} has {target.Current_hp} hp left");
                }
                int dmg = Dexterity * 3;
                target.Health -= dmg;
                target.Current_hp = target.Health;
                System.Console.WriteLine($"{Name} used SingleShot on {target.Name} and inflicted {dmg} damage, {target.Name} has {target.Current_hp} left");
                return target.Health;
            }
        }

        class Samurai : Human
        {
            public Samurai(string name) : base(name)
            {
                Name = name;
                Health = 100;
                Strength = 5;
                Class = "Samurai";
                Current_hp = Health;
            }

            public int Slash(Human target)
            {
                if(target.Class == "Wizard")
                {
                    int ex_dmg = Strength * 4;
                    target.Current_hp -= ex_dmg;
                    System.Console.WriteLine($"{Name} used Slash on {target.Name} and and it was extra effective on Wizard type causing {ex_dmg} damage, {target.Name} has {target.Current_hp} hp left");
                }
                int dmg = Strength * 3;
                target.Health -= dmg;
                target.Current_hp = target.Health;
                System.Console.WriteLine($"{Name} used slash on {target.Name} for {dmg} damage, {target.Name} has {target.Current_hp} left");
                return target.Health;
            }
        }

}
