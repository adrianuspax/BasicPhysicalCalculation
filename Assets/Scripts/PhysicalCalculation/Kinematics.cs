using UnityEngine;

namespace PhysicalCalculation
{
    public struct Space
    {
        public enum Unit 
        {
            unknown = -1,
            meter = 0,
            centimeter = 1,
            kilometer = 2,
            yard = 3
        }

        public float s0;
        public float s1;

        public Space(float s0, float s1)
        {
            this.s0 = s0;
            this.s1 = s1;
        }

        public Space(float s)
        {
            s0 = 0f;
            s1 = s;
        }

        public readonly float Delta => s1 - s0;
        /// <summary>
        /// S = S0 + v0 * t + ½ * a * t²
        /// </summary>
        /// <param name="s0">initial space</param>
        /// <param name="v0">initial speed</param>
        /// <param name="a">acceleration</param>
        /// <param name="t">time (total)</param>
        /// <returns>S (space)</returns>
        public static Space Get(float s0, float v0, Acceleration a, Time t)
        {
            Space s = new(s0 + v0 * t.Delta + a.Average * Mathf.Pow(t.Delta, 2) * 0.5f);
            return s;
        }
        /// <summary>
        /// v² = v0² + 2 * a * (S - S0) => (S - S0) = (v² - v0²) / (2 * a)
        /// </summary>
        /// <param name="v0">initial speed</param>
        /// <param name="v">final speed</param>
        /// <param name="a">acceleration</param>
        /// <returns>space (s)</returns>
        public static Space Get(float v0, float v, Acceleration a)
        {
            Space s = new((Mathf.Pow(v, 2) - Mathf.Pow(v0, 2)) / (2f * a.Average));
            return s;
        }

        public static float Convert(Unit from, Unit to, float value)
        {
            const float YD_FACTOR = 0.9144f;

            return from switch
            {
                Unit.meter => value * conversion(),
                Unit.centimeter => value * conversion(),
                Unit.kilometer => value * conversion(),
                Unit.yard => value * conversion(),
                _ => value * 0f,
            };

            float conversion()
            {
                return to switch
                {
                    Unit.meter => 1f * factor(),
                    Unit.centimeter => 100f * factor(),
                    Unit.kilometer => 1f / 1000f * factor(),
                    Unit.yard => (1f / YD_FACTOR) * factor(),
                    _ => 0f
                };
            }

            float factor()
            {
                return from switch
                {
                    Unit.meter => 1f,
                    Unit.centimeter => 1f / 100f,
                    Unit.kilometer => 1000f,
                    Unit.yard => 1f / YD_FACTOR,
                    _ => 0f
                };
            }

            /*float m()
            {
                return to switch
                {
                    Unit.meter => 1f, // 1
                    Unit.centimeter => 100f, // 100
                    Unit.kilometer => 1f / 1000f, // 1 / 100 / 10
                    Unit.yard => (1f / YD_FACTOR), // 1 / yd
                    _ =>  0f
                };
            }

            float cm()
            {
                return to switch
                {
                    Unit.meter => (1f / 100f), // 1 (/ 100)
                    Unit.centimeter => 1f, // 100 (/ 100)
                    Unit.kilometer => ((1f / 100f) / 1000f), // 1 / 100 / 10 (/ 100)
                    Unit.yard => ((1f / YD_FACTOR) / 100f), // 1 / yd (/ 100)
                    _ => 0f
                };
            }

            float km()
            {
                return to switch
                {
                    Unit.meter => 1000f, // 1 (* 1000)
                    Unit.centimeter => 1000f * 100f, // 100 (* 1000)
                    Unit.kilometer => 1f, // 1 / 100 / 10 (*1000)
                    Unit.yard => (1f / YD_FACTOR) * 1000f, // 1 / yd (* 1000)
                    _ => 0f
                };
            }

            float yd()
            {
                return to switch
                {
                    Unit.meter => 1f / YD_FACTOR, // 1 / yd
                    Unit.centimeter => ((1f / YD_FACTOR) / 100f), // 100 / yd
                    Unit.kilometer => (1f / YD_FACTOR) * 1000f, // 1 / 100 / 10 / yd
                    Unit.yard => 1f, // 1 / yd (* yd)
                    _ => 0f
                };
            }*/
        }

        public static (float km, float cm, float yd) ConvertMetersTo(float m)
        {
            return (_kilometers(), _centimeters(), _yards());
            float _kilometers() => m / 1000f;
            float _centimeters() => m * 100f;
            float _yards() => m * (1f / 0.9144f);
        }

        public static (float m, float yd) ConvertKilometersTo(float km)
        {
            return (_meters(), _yards());
            float _meters() => km * 1000f;
            float _yards() => km * (1f / 0.9144f) * 1000;
        }

        public static (float m, float yd) ConvertCentimetersTo(float cm)
        {
            return (_meters(), _yards());
            float _meters() => cm / 100f;
            float _yards() => cm * (1f / (0.9144f * 100f));
        }

        public static (float m, float cm) ConvertYardsTo(float yd)
        {
            return (_meters(), _centimeters());
            float _meters() => yd * 0.9144f;
            float _centimeters() => yd * 0.9144f * 100f;
        }
    }

    public struct Time
    {
        public float t0;
        public float t1;

        public Time(float t0, float t1)
        {
            this.t0 = t0;
            this.t1 = t1;
        }

        public Time(float t)
        {
            t0 = 0f;
            t1 = t;
        }

        public readonly float Delta => t1 - t0;

        public static float SecondsToMinutes(float s)
        {
            return s / 60f;
        }

        public static float MinutesToSeconds(float min)
        {
            return min * 60f;
        }
    }

    public struct Speed
    {
        public Space s;
        public Time t;

        public Speed(Space s, Time t)
        {
            this.s = s;
            this.t = t;
        }

        public Speed(float s, float t)
        {
            this.s = new Space(s);
            this.t = new Time(t);
        }

        public Speed(float v)
        {
            s = new Space(v);
            t = new Time(1f);
        }

        public readonly float Average => s.Delta / t.Delta;
        /// <summary>
        /// v = v0 + a * t
        /// </summary>
        /// <param name="v0">Initial Speed</param>
        /// <param name="a">Acceleration</param>
        /// <param name="t">Time (Total)</param>
        /// <returns>speed (v)</returns>
        public static Speed Get(float v0, Acceleration a, Time t)
        {
            Speed v = new(v0 + (a.Average * t.Delta));
            return v;
        }
        /// <summary>
        /// S = S0 + v0 * t + ½ * a * t² => v0 = ((S - S0) / t) - ½ * a * t
        /// </summary>
        /// <param name="s">space</param>
        /// <param name="a">acceleration</param>
        /// <param name="t">time</param>
        /// <returns>Initial Speed (v0)</returns>
        public static float Get(Space s, Acceleration a, Time t)
        {
            return (s.Delta / t.Delta) - 0.5f * a.Average * t.Delta;
        }
        /// <summary>
        /// v² = v0² + 2 * a * (S - S0) => v = sqrt( v0² + 2 * a * (S - S0))
        /// </summary>
        /// <param name="s">space</param>
        /// <param name="a">acceleration</param>
        /// <param name="v0">initial speed</param>
        /// <returns>speed (v)</returns>
        public static Speed Get(Space s, Acceleration a, float v0)
        {
            float v0p2 = Mathf.Pow(v0, 2);
            Speed v = new(Mathf.Sqrt(v0p2 + 2f * a.Average * s.Delta));
            return v;
        }
    }

    public struct Acceleration
    {
        public Speed v;
        public Time t;

        public Acceleration(Speed v, Time t)
        {
            this.v = v;
            this.t = t;
        }

        public Acceleration((float v0, float v1) speeds, Time t)
        {
            v = new(speeds.v1 - speeds.v0);
            this.t = t;
        }

        public Acceleration(float v, float t)
        {
            this.v = new Speed(v);
            this.t = new Time(t);
        }

        public Acceleration(float a)
        {
            v = new Speed(a);
            t = new Time(1f);
        }
        /// <summary>
        /// S = S0 + v0 * t + ½ * a * t² => a = (2 * ((S - S0) - v0 * t)) / t²
        /// </summary>
        /// <param name="s">space</param>
        /// <param name="v0">initial speed</param>
        /// <param name="t">time</param>
        /// <returns>acceleration (a)</returns>
        public static Acceleration Get(Space s, float v0, float t)
        {
            Acceleration a = new(2f * (s.Delta - v0 * t) / Mathf.Pow(t, 2));
            return a;
        }
        /// <summary>
        /// v² = v0² + 2 * a * (S - S0) => a = (v² - v0²) / 2 * (S - S0)
        /// </summary>
        /// <param name="v0">initial speed</param>
        /// <param name="v">final speed</param>
        /// <param name="s">space</param>
        /// <returns>acceleration (a)</returns>
        public static Acceleration Get(float v0, float v, Space s)
        {
            Acceleration a = new((Mathf.Pow(v, 2) - Mathf.Pow(v0, 2)) / (2f * s.Delta));
            return a;
        }

        public readonly float Average => v.Average / t.Delta;
    }
}
