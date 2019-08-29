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
                System.Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage, {target.Name} has {target.Health} left");
                return target.Health;
            }
            public virtual void ShowInfo()
            {
                System.Console.WriteLine($"{Name} has {Strength} str, {Intelligence} intel, {Dexterity} dex, {health} hp");
            }
        }

        class Wizard : Human
        {
            public Wizard(string name) : base(name)
            {
                Name = name;
                Health = 50;
                Intelligence = 5;
            }

            public int FireBall(Human target)
            {
                int dmg = Intelligence * 3;
                target.Health -= dmg;
                System.Console.WriteLine($"{Name} used fireball on {target.Name} and inflicted {dmg} damage, {target.Name} has {target.Health} left");
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
            }

            public int SingleShot(Human target)
            {
                int dmg = Dexterity * 3;
                target.Health -= dmg;
                System.Console.WriteLine($"{Name} used SingleShot on {target.Name} and inflicted {dmg} damage, {target.Name} has {target.Health} left");
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
            }

            public int Slash(Human target)
            {
                int dmg = Strength * 3;
                target.Health -= dmg;
                System.Console.WriteLine($"{Name} used slash on {target.Name} for {dmg} damage, {target.Name} has {target.Health} left");
                return target.Health;
            }
        }

}
