namespace MonsterKampfSim.Monster
{
    public class Goblin : Monster
    {
        /// Special Attack:
        /// Name -> Hinterhältiger Angriff
        /// Effekt -> 10% chance auf 2x Angriffsschaden wenn gegnerische Gesungheit kleiner als die eigene. <summary>

        // Goblin constructor, call constructor from base class
        public Goblin (int health, int attack, int defense, int speed) : base(health, attack, defense, speed) { }


        // Atack Logic -> Override function to attack target
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
            }

            // Special Attack -> Check if enemy health below own health
            if(target.HealthPoints < this.HealthPoints)
            {
                // Fire randomizer
                if(Randomizer(10))
                {
                    target.TakeDamage(this, (this.AttackPoints * 2));
                    return;
                }
            }

            // Normal Attack -> Apply damage to target
            target.TakeDamage(this, AttackPoints);
        }
    }
}