namespace MonsterKampfSim.monster
{
    public class Ork : Monster
    {
        /// Special Attack:
        /// Name -> Wutanfall
        /// Effekt -> 20% chance auf 2x Angriffsschaden wenn eigene Gesungheit kleiner als die des Gegners.
        

        // Ork constructor, call constructor from base class
        public Ork(int health, int attack, int defense, int speed) : base(health, attack, defense, speed){ }

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

            // Special Attack -> Check if own health below target health
            if(this.HealthPoints < target.HealthPoints)
            {
                // Fire randomizer
                if(Randomizer(20))
                {
                    target.TakeDamage(this, (AttackPoints * 2));
                    return;
                }
            }

            // Normal Attack -> Apply damage to target
            target.TakeDamage(this, AttackPoints);
        }

    }
}