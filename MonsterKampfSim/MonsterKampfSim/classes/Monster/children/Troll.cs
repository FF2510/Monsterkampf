using System.Runtime.InteropServices;

namespace MonsterKampfSim.Monster
{
    public class Troll : Monster
    {
        /// Special Attack:
        /// Name -> Betäubendes Brüllen
        /// Effekt -> 10% Chance das der Gegner betäubt ist und einen Angriff aussetzt. Nur wenn eigene defense durchbrochen. <summary>



        // Troll constructor, call constructor from base class
        public Troll(int health, int attack, int defense, int speed) : base(health, attack, defense, speed){ }


        // Attack Logic -> Override function to attack target
        public override void AttackTarget(Monster target)
        {
            // End function -> Make sure target is valid
            if(target is null)
            {
                return;
            }

            // End function -> Stop attack if monster is stunned but reset stunned state
            if(Stunned)
            {
                Stunned = true;
                return;
            }

            // Special Attack -> Check if special attack should be performed
            if(DefensePoints <= 0)
            {
                // Fire randomizer
                if(Randomizer(10))
                {
                    // Set target to be stunned
                    target.Stunned = true;
                }
            }

            // Normal Attack -> Apply damage to target
            target.TakeDamage(this, AttackPoints);
        }
    }
}