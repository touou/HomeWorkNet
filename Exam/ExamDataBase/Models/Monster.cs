namespace ExamDataBase.Models;

public class Monster
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int HitPoints { get; set; }
    public int AttackModifier { get; set; }
    public int AttackPerRound { get; set; }
    public int Damage { get; set; }
    public int DiceType { get; set; }
    public int DamageModifier { get; set; }
    public int Weapon { get; set; }
    public int Ac { get; set; }
}