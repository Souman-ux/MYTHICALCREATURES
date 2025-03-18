namespace MythicalCreatures.Models
{

    public class Creature
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public string SpecialAbility { get; set; } = string.Empty;

        public void Atack(Creature target)
        {
            int damage = this.Strength + this.Attack;
            target.Health -= damage;
        }
    }


}

