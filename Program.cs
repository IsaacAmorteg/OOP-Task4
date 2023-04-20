using System.Text;

public class Polynominal
{
    private double[] _coefficients;

    public Polynominal(params double[] coefficients)
    {
        _coefficients = coefficients;
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        for (int i = _coefficients.Length - 1; i >= 0; i--)
        {
            if (_coefficients[i] == 0)
                continue;
            if (stringBuilder.Length > 0 && _coefficients[i] > 0)
                stringBuilder.Append('+');
        }
    }
}