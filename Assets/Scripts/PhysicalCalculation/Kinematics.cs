using UnityEngine;

namespace PhysicalCalculation
{
    public struct Space
    {
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
        /// S = S0 + v0 * t + ½ * at²
        /// </summary>
        /// <param name="s0">initial space</param>
        /// <param name="v0">initial speed</param>
        /// <param name="a">acceleration</param>
        /// <param name="t">time (total)</param>
        /// <returns>S (space)</returns>
        public static float Get(float s0, float v0, float a, float t)
        {
            return s0 + v0 * t + a * Mathf.Pow(t, 2) * 0.5f;
        }

        public static float MetersToKilometers(float m)
        {
            return m / 1000f;
        }

        public static float KilometersToMeters(float km)
        {
            return km * 1000f;
        }

        public static float MetersToCentimeters(float m)
        {
            return m * 100f;
        }

        public static float CentimetersToMeters(float cm)
        {
            return cm / 100f;
        }

        public static float YardToMeter(float yd)
        {
            return yd * 0.9144f;
        }

        public static float YardToCentimeter(float yd)
        {
            return yd * 0.9144f * 100f;
        }

        public static float MeterToYard(float m)
        {
            return m * (1f / 0.9144f);
        }

        public static float CentimeterToYard(float cm)
        {
            return cm * (1f / (0.9144f * 100f));
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
        /// <returns>v (speed)</returns>
        public static float Get(float v0, float a, float t)
        {
            return v0 + (a * t);
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

        public readonly float Average => v.Average / t.Delta;
    }
}
