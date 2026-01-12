abstract class Character
{
    private string characterType;
    public bool vulnerable = false;
    
    protected Character(string characterType)
    {
        this.characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => this.vulnerable;

    public override string ToString() => $"Character is a {this.characterType}";
}

class Warrior : Character
{
    public Warrior() : base("Warrior") {}

    public override int DamagePoints(Character target) => target.Vulnerable() ? 10 : 6;
}

class Wizard : Character
{
    private bool spellPrepared = false;
    
    public Wizard() : base("Wizard") {}

    public override bool Vulnerable() => this.spellPrepared == false;

    public override int DamagePoints(Character target) => this.spellPrepared ? 12 : 3;

    public void PrepareSpell() => this.spellPrepared = true;
}
