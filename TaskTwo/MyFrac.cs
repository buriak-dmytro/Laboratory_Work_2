using System;

namespace TaskTwo
{
    class MyFrac
    {
        private long nom;
        private long denom;

        public MyFrac(long nom, long denom)
        {
            this.nom = nom;
            this.denom = denom;

            if (denom == 0)
            {
                throw new Exception("Denominator of the fraction cannot be zero");
            }
            else if (denom < 0)
            {
                nom *= (-1);
                denom *= (-1);
            }
            // denom > 0 --- all right

            if (nom != 0)
            {
                long GCD = EuclideanAlgorithmGCD(Math.Abs(nom), Math.Abs(denom));

                nom /= GCD;
                denom /= GCD;
            }
            // nom == 0 --- all right
        }

        private static long EuclideanAlgorithmGCD(long a, long b)
        {
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                if (b > a)
                {
                    b -= a;
                }
            }

            return a; // a == b == GCD
        }

        public override string ToString()
        {
            return string.Format($"{nom}/{denom}");
        }

        public string ToStringWithIntegerPart()
        {
            string fractionString = "";

            if (this.nom < 0)
            {
                fractionString += "-";
            }
            
            fractionString += "(";
            if (this.nom > this.denom)
            {
                fractionString += (Math.Abs(this.nom) / this.denom);
                fractionString += "+";
                fractionString += (Math.Abs(this.nom) % this.denom);
                fractionString += "/";
                fractionString += this.denom;
            }
            else if (this.nom == this.denom)
            {
                fractionString += 1;
            }
            else if (this.nom < this.denom)
            {
                fractionString += (Math.Abs(this.nom) % this.denom);
                fractionString += "/";
                fractionString += this.denom;
            }
            fractionString += ")";

            return fractionString;
        }

        public double DoubleValue()
        {
            double fractionDouble = 1.0 * this.nom / this.denom;
            return fractionDouble;
        }

        public static MyFrac operator +(MyFrac frac1, MyFrac frac2)
        {
            return new MyFrac
                (frac1.nom * frac2.denom +
                frac1.denom * frac2.nom,
                frac1.denom * frac2.denom);
        }

        public static MyFrac operator -(MyFrac frac1, MyFrac frac2)
        {
            return new MyFrac
                (frac1.nom * frac2.denom -
                frac1.denom * frac2.nom,
                frac1.denom * frac2.denom);
        }

        public static MyFrac operator *(MyFrac frac1, MyFrac frac2)
        {
            return new MyFrac
                (frac1.nom * frac2.nom,
                frac1.denom * frac2.denom);
        }

        public static MyFrac operator /(MyFrac frac1, MyFrac frac2)
        {
            return new MyFrac
                (frac1.nom * frac2.denom,
                frac1.denom * frac2.nom);
        }

        public static MyFrac CalcDefinedSum(int n)
        {
            MyFrac resFrac = new MyFrac(0, 1);

            for (int iteration = 1; iteration <= n; iteration++)
            {
                resFrac = resFrac + new MyFrac(1, iteration * (iteration + 1));
            }

            return resFrac;
        }

        public static MyFrac CalcDefinedProduct(int n)
        {
            MyFrac resFrac = new MyFrac(1, 1);

            for (int iteration = 2; iteration <= n; iteration++)
            {
                resFrac = resFrac * (new MyFrac(1, 1) - new MyFrac(1, (iteration * iteration)));
            }

            return resFrac;
        }
    }
}
