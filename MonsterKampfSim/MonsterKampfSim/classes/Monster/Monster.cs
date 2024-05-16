namespace MonsterKampfSim.monster
{
    /// <summary>
    /// Abstract class that defines the basic features of each monster.
    /// This class is abstract, preventing anyone from creating instances from it.
    /// Includes basic functionality for each monster such as attacking, taking damage, and resetting attributes.
    /// </summary>
    public abstract class Monster
    {
        /// <summary>
        /// Defines the health of this monster.
        /// Can only be set from within this class.
        /// </summary>
        public int HealthPoints { get; private set; }

        /// <summary>
        /// Defines the attack force of this monster.
        /// Can only be set from within this class.
        /// </summary>
        public int AttackPoints { get; private set; }

        /// <summary>
        /// Defines the defense strength of this monster.
        /// Can only be set from within this class.
        /// </summary>
        public int DefensePoints { get; private set; }

        /// <summary>
        /// Defines the speed of this monster.
        /// Can only be set from within this class.
        /// </summary>
        public int Speed { get; private set; }

        /// <summary>
        /// Defines if this monster is stunned.
        /// Stunned monsters cannot attack.
        /// </summary>
        public bool Stunned {get; set;}



        // Default Value -> Default Health of the monster
        private readonly int _defaultHealth;

        // Default Value -> Default Defense of the monster
        private readonly int _defaultDefense;

        // Private Member -> Random Class Instance
        private static readonly Random rnd = new Random();




        /// <summary>
        /// Initializes a new instance of the Monster class.
        /// </summary>
        /// <param name="health">The starting health of the monster.</param>
        /// <param name="attack">The attack force of this monster.</param>
        /// <param name="defense">The defense strength of this monster.</param>
        /// <param name="speed">The speed of this monster.</param>
        public Monster(int health, int attack, int defense, int speed)
        {
            HealthPoints = health;
            AttackPoints = attack;
            DefensePoints = defense;
            Speed = speed;

            _defaultHealth = health;
            _defaultDefense = defense;
        }




        /// <summary>
        /// Abstract method used to attack a target (other monster).
        /// Needs to be implemented by all children.
        /// </summary>
        /// <param name="target">The monster you want to attack. (Cannot be self).</param>
        public abstract void AttackTarget(Monster target);


        /// <summary>
        /// Virtual method, that is executed when a monster takes damage.
        /// Can be overridden by children.
        /// </summary>
        /// <param name="instigator">The monster that dealt the damage.</param>
        /// <param name="damage">The amount of damage dealt.</param>
        public virtual void TakeDamage(Monster instigator, int damage)
        {
            if (instigator is null || damage <= 0)
            {
                return;
            }

            // Damage to defense
            int defenseDamage = Math.Min(DefensePoints, damage);
            DefensePoints -= defenseDamage;

            // Remaining damage to health
            int remainingDamage = damage - defenseDamage;
            HealthPoints -= Math.Min(HealthPoints, remainingDamage);
        }


        /// <summary>
        /// Resets the monster's health to its default value.
        /// </summary>
        private void ResetHealth()
        {
            HealthPoints = _defaultHealth;
        }


        /// <summary>
        /// Resets the monster's defense to its default value.
        /// </summary>
        private void ResetDefense()
        {
            DefensePoints = _defaultDefense;
        }


        /// <summary>
        /// Determines if the monster's special attack should be performed.
        /// Given the chance of the attack, this function will randomly return
        /// a boolean indicating if the attack should be performed.
        /// </summary>
        /// <param name="chance">The probability (0-100) that the special attack should be performed.</param>
        /// <returns>A boolean indicating whether the special attack should be performed.</returns>
        protected bool Randomizer(int chance)
        {
            // Get a number between 0 and 99
            int result = rnd.Next(0, 100);

            // Return true if the chance threshold is met
            return chance > result;
        }


        /// <summary>
        /// Returns if the monster is still alive.
        /// </summary>
        /// <returns>Is alive? Boolean value</returns>
        public bool IsAlive()
        {
            return HealthPoints > 0;
        }
    }
}
