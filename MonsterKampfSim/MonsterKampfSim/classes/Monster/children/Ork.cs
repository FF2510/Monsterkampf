namespace MonsterKampfSim.monster
{
    public class Ork : Monster
    {
        /// Special Attack:
        /// Name -> Wutanfall
        /// Effekt -> 20% chance auf 2x Angriffsschaden wenn eigene Gesungheit kleiner als die des Gegners.
        

        // Ork constructor, call constructor from base class
        public Ork(int health, int attack, int defense, int speed) : base(health, attack, defense, speed)
        {
            Name = "Ork";
        }

        // Attack Logic -> Override function to attack target
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

            // Special Attack -> Check if own health below target health
            if(this.HealthPoints < target.HealthPoints)
            {
                // Fire randomizer
                if(Randomizer(20))
                {
                    target.TakeDamage(this, (AttackPoints * 2));
                    return (true, true, AttackPoints * 2);
                }
            }

            // Normal Attack -> Apply damage to target
            target.TakeDamage(this, AttackPoints);
            return (true, false, AttackPoints);
        }

    }
}