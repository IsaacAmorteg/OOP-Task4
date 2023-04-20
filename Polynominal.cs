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
        for (int i = 0; i < _coefficients.Length; i++)
        {
            if (_coefficients[i] != 0)
            {
                if (_coefficients[i] > 0 && stringBuilder.Length > 0)
                {
                    stringBuilder.Append("+");
                }

                if (_coefficients[i] == -1 && i != 0)
                {
                    stringBuilder.Append("-");
                }
                else if (_coefficients[i] != 1 || i == 0)
                {
                    stringBuilder.Append(_coefficients[i]);
                }

                if (i == 0)
                {
                    stringBuilder.Append(" ");
                }
                else
                {
                    stringBuilder.Append("x^" + i + " ");
                }
            }
        }
        return stringBuilder.ToString();
    }
    public static Polynominal operator +(Polynominal a, Polynominal b)
    {
        int maxLength = Math.Max(a._coefficients.Length, b._coefficients.Length);
        double[] result = new double[maxLength];
        for (int i = 0; i < maxLength; i++)
        {
            double x = (i < a._coefficients.Length ? a._coefficients[i] : 0);
            double y = (i < b._coefficients.Length ? b._coefficients[i] : 0);
            result[i] = x + y;
        }
        return new Polynominal(result);
    }

    public static Polynominal operator -(Polynominal a, Polynominal b)
    {
        int maxLength = Math.Max(a._coefficients.Length, b._coefficients.Length);
        double[] result = new double[maxLength];
        for (int i = 0; i < maxLength; i++)
        {
            double x = (i < a._coefficients.Length ? a._coefficients[i] : 0);
            double y = (i < b._coefficients.Length ? b._coefficients[i] : 0);
            result[i] = x - y;
        }
        return new Polynominal(result);
    }

    public static Polynominal operator *(Polynominal a, Polynominal b)
    {
        double[] result = new double[a._coefficients.Length + b._coefficients.Length - 1];
        for (int i = 0; i < a._coefficients.Length; i++)
        {
            for (int j = 0; j < b._coefficients.Length; j++)
            {
                result[i + j] += a._coefficients[i] * b._coefficients[j];
            }
        }
        return new Polynominal(result);
    }
}