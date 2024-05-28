using System.Runtime.InteropServices;

namespace MonsterKampfSim.monster
{
    public class Troll : Monster
    {
        /// Special Attack:
        /// Name -> Betäubendes Brüllen
        /// Effekt -> 10% Chance das der Gegner betäubt ist und einen Angriff aussetzt. Nur wenn eigene defense durchbrochen. <summary>



        // Troll constructor, call constructor from base class
        public Troll(int health, int attack, int defense, int speed) : base(health, attack, defense, speed)
        {
            Name = "Troll";
        }


        // Attack Logic -> Override function to attack target
        public override (bool, bool, int) AttackTarget(Monster target)
        {
            bool specAttack = false;

            // End function -> Make sure target is valid
            if(target is null)
            {
                return (false, false, 0);
            }

            // End function -> Stop attack if monster is stunned but reset stunned state
            if(Stunned)
            {
                Stunned = false;
                return (false, false, 0);
            }

            // Special Attack -> Check if special attack should be performed
            if(DefensePoints <= 0)
            {
                // Fire randomizer
                if(Randomizer(10))
                {
                    // Set target to be stunned
                    target.Stunned = true;
                    specAttack = true;

                }
            }

            // Normal Attack -> Apply damage to target
            target.TakeDamage(this, AttackPoints);

            return (true, specAttack, AttackPoints);
        }
    }
}