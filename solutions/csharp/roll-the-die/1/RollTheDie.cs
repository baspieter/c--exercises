public class Player
{
    public int RollDie()
    {
        Random rand = new Random();
        return rand.Next(18) + 1;
    }

    public double GenerateSpellStrength()
    {
        Random random = new Random();
        return random.NextDouble() * (99 - 1) + 1;
    }
}
