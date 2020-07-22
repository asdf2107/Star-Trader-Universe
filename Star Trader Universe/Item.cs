
namespace Star_Trader_Universe
{
    public class Item : IPhysical, IDamageable
    {
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public bool IsFunctioning { get; set; } = false;
        public int Mass { get; set; }

        public Item(int mass, int maxHp)
        {
            Hp = maxHp;
            MaxHp = maxHp;
            Mass = mass;
        }

        public virtual string GetSpecs(bool extended = false)
        {
            if (!extended)
                return $"Mass: {Mass}, hp: {Hp}, functioning: {IsFunctioning}";
            else
                return $"Mass: {Mass}, hp: {Hp}, maxHp: {MaxHp}, functioning: {IsFunctioning}";
        }
    }
}
