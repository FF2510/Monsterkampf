namespace MonsterKampfSim.monster
{
    public class Goblin : Monster
    {
        /// Special Attack:
        /// Name -> Hinterhältiger Angriff
        /// Effekt -> 10% chance auf 2x Angriffsschaden wenn gegnerische Gesungheit kleiner als die eigene. <summary>

        // Goblin constructor, call constructor from base class
        public Goblin (int health, int attack, int defense, int speed) : base(health, attack, defense, speed)
        {
            Name = "Goblin";
        }


        // Atack Logic -> Override function to attack target
        public override (bool, bool, int) AttackTarget(Monster target)
        {
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

            // Special Attack -> Check if enemy health below own health
            if(target.HealthPoints < this.HealthPoints)
            {
                // Fire randomizer
                if(Randomizer(10))
                {
                    target.TakeDamage(this, (this.AttackPoints * 2));
                    return (false, true, AttackPoints * 2);
                }
            }

            // Normal Attack -> Apply damage to target
            target.TakeDamage(this, AttackPoints);

            return (true, false, AttackPoints);
        }
    }
}