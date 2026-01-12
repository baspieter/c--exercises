using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        StringBuilder newString = new StringBuilder();
        char[] greekAlphabet =
        {
            'α','β','γ','δ','ε','ζ','η','θ',
            'ι','κ','λ','μ','ν','ξ','ο','π',
            'ρ','σ','τ','υ','φ','χ','ψ','ω'
            };

        for (int i = 0; i < identifier.Length; i++)
        {
            char c = identifier[i];
            if (c == ' ') {
                newString.Append('_');
            } else if (Char.IsControl(c)) {
                newString.Append("CTRL");
            } else if (c == '-') {
                newString.Append(Char.ToUpper(identifier[i + 1]));
                i++;
            } else if (Char.IsLetter(c) && greekAlphabet.Contains(c) == false) {
                newString.Append(c);
            }
        }

        return newString.ToString();
    }
}
