namespace Game.Health
{
    public interface IDamageable
    {
        public float MaxHealth { get;}
        public float CurrentHealth { get;}


        public void TakeDamage(int damage);
    }
}