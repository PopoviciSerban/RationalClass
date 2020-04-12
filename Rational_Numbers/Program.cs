using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumereRationale
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    internal class Rational
    {
        private int num;
        private int den;

        public Rational() : this(0)
        {
        }

        public Rational(int numerator)
        {
            num = numerator;
            den = 1;
        }

        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator can't be 0");

            num = numerator;
            den = denominator;
        }

        public static Rational operator +(Rational r) => r;
        public static Rational operator -(Rational r) => new Rational(-r.num, r.den);

        public static Rational operator +(Rational a, Rational b)
        {
            Rational c = new Rational(a.num * b.den + b.num * a.den, a.den * b.den);

            return Simplify(c);
        }

        public static Rational operator -(Rational a, Rational b)
            => a + (-b);

        public static Rational operator *(Rational a, Rational b)
        {
            Rational c = new Rational(a.num * b.num, a.den * b.den);

            return Simplify(c);
        }

        public static Rational operator /(Rational a, Rational b)
        {
            if (b.num == 0)
            {
                throw new DivideByZeroException();
            }

            Rational c = new Rational(a.num * b.den, a.den * b.num);

            return Simplify(c);
        }

        public static Rational operator ^(Rational a, int b)
        {
            int x = a.num, y = a.den;

            if (b == 0)
                return new Rational(1);

            for (int i = 2; i <= Math.Abs(b); i++)
            {
                x *= a.num;
                y *= a.den;
            }

            Rational c;

            if (b > 0)
                c = new Rational(x, y);
            else
                c = new Rational(y, x);

            return Simplify(c);
        }

        private static Rational Simplify(Rational a)
        {
            int aux1 = a.num, aux2 = a.den;
            int n = a.num, d = a.den;

            int r = aux1 % aux2;

            while (r > 0)
            {
                aux1 = aux2;
                aux2 = r;
                r = aux1 % aux2;
            }

            return new Rational(n / aux2, d / aux2);
        }

        public static bool operator <=(Rational a, Rational b)
        {
            int aux1 = a.den, aux2 = b.den;

            if (b.den != a.den)
            {
                a.num *= aux2;
                a.den *= aux2;
                b.num *= aux1;
                b.den *= aux1;
            }

            if (a.num <= b.num)
                return true;

            return false;
        }

        public static bool operator <(Rational a, Rational b)
        {
            int aux1 = a.den, aux2 = b.den;

            if (b.den != a.den)
            {
                a.num *= aux2;
                a.den *= aux2;
                b.num *= aux1;
                b.den *= aux1;
            }

            if (a.num < b.num)
                return true;

            return false;
        }

        public static bool operator >=(Rational a, Rational b)
        {
            int aux1 = a.den, aux2 = b.den;

            if (b.den != a.den)
            {
                a.num *= aux2;
                a.den *= aux2;
                b.num *= aux1;
                b.den *= aux1;
            }

            if (a.num >= b.num)
                return true;

            return false;
        }

        public static bool operator >(Rational a, Rational b)
        {
            int aux1 = a.den, aux2 = b.den;

            if (b.den != a.den)
            {
                a.num *= aux2;
                a.den *= aux2;
                b.num *= aux1;
                b.den *= aux1;
            }

            if (a.num > b.num)
                return true;

            return false;
        }

        public static bool operator ==(Rational a, Rational b)
        {
            int aux1 = a.den, aux2 = b.den;

            if (b.den != a.den)
            {
                a.num *= aux2;
                a.den *= aux2;
                b.num *= aux1;
                b.den *= aux1;
            }

            if (a.num == b.num)
                return true;

            return false;
        }

        public static bool operator !=(Rational a, Rational b)
        {
            int aux1 = a.den, aux2 = b.den;

            if (b.den != a.den)
            {
                a.num *= aux2;
                a.den *= aux2;
                b.num *= aux1;
                b.den *= aux1;
            }

            if (a.num != b.num)
                return true;

            return false;
        }
    }
}
