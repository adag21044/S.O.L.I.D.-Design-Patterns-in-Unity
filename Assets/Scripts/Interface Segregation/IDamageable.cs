public interface IDamageable 
{
    int Health{ get; }
    int MaxHealth{ get; }
    
    
    void DealDamage(int damageToDeal);
}