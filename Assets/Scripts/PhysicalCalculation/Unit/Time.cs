using System;
using UnityEngine;

namespace ASP.Unit
{
    /// <summary>
    /// Class for handling time scales
    /// </summary>
    public static class Time
    {
        #region HundredthsOfSeconds
        /// <summary>
        /// Struct for handling hundredths of seconds
        /// </summary>
        [Serializable]
        public struct HundredthsOfSeconds
        {
            /// <summary>
            /// Pure hundredths of seconds value
            /// </summary>
            public float value;
            /// <summary>
            /// Construct to handling hundredths of seconds
            /// </summary>
            /// <param name="value">Pure seconds value</param>
            public HundredthsOfSeconds(float value)
            {
                PositiveTimeGuarantee(ref value);
                this.value = value;
            }
            /// <summary>
            /// Converts tenths of seconds into a string according to a chosen format
            /// </summary>
            /// <param name="format">Tenths of seconds display format in string</param>
            /// <returns>Returns a string of tenths of seconds according to the chosen format</returns>
            public readonly string ToString(Format format)
            {
                return string.Format(format.value, Mathf.Floor(value));
            }
            /// <summary>
            /// Pure value to integer conversion by floor
            /// </summary>
            public readonly int FloorValue => Mathf.FloorToInt(value);

            public static implicit operator string(HundredthsOfSeconds value) => value.value.ToString();
            public static implicit operator int(HundredthsOfSeconds value) => (int)value.value;
            public static implicit operator float(HundredthsOfSeconds value) => value.value;
        }
        #endregion
        #region TenthsOfSeconds
        /// <summary>
        /// Struct for handling tenths of seconds
        /// </summary>
        [Serializable]
        public struct TenthsOfSeconds
        {
            /// <summary>
            /// Pure tenths of seconds value
            /// </summary>
            public float value;
            /// <summary>
            /// Construct to handling tenths of seconds
            /// </summary>
            /// <param name="value">Pure seconds value</param>
            public TenthsOfSeconds(float value)
            {
                PositiveTimeGuarantee(ref value);
                this.value = value;
            }
            /// <summary>
            /// Converts tenths of seconds into a string according to a chosen format
            /// </summary>
            /// <param name="format">Tenths of seconds display format in string</param>
            /// <returns>Returns a string of tenths of seconds according to the chosen format</returns>
            public readonly string ToString(Format format)
            {
                return string.Format(format.value, Mathf.Floor(value));
            }
            /// <summary>
            /// Pure value to integer conversion by floor
            /// </summary>
            public readonly int FloorValue => Mathf.FloorToInt(value);

            public static implicit operator string(TenthsOfSeconds value) => value.value.ToString();
            public static implicit operator int(TenthsOfSeconds value) => (int)value.value;
            public static implicit operator float(TenthsOfSeconds value) => value.value;
        }
        #endregion
        #region Seconds
        /// <summary>
        /// Struct to handling seconds
        /// </summary>
        [Serializable]
        public struct Seconds
        {
            /// <summary>
            /// Pure seconds value
            /// </summary>
            public float value;
            /// <summary>
            /// Construct to handling seconds
            /// </summary>
            /// <param name="value">Pure seconds value</param>
            public Seconds(float value)
            {
                PositiveTimeGuarantee(ref value);
                this.value = value;
            }
            /// <summary>
            /// Conversion to the time scale in hundredths of seconds
            /// </summary>
            /// <param name="value">Pure seconds value</param>
            /// <returns>return new <see cref="HundredthsOfSeconds"/>(<paramref name="value"/> * 100f)</returns>
            public static HundredthsOfSeconds ToHundredthsOfSeconds(float value)
            {
                return new HundredthsOfSeconds(value * 100f);
            }
            /// <summary>
            /// Conversion to the time scale in hundredths of seconds
            /// </summary>
            /// <returns>return new <see cref="HundredthsOfSeconds"/>(<see cref="value"/> * 100f)</returns>
            public readonly HundredthsOfSeconds ToHundredthsOfSeconds()
            {
                return ToHundredthsOfSeconds(value);
            }
            /// <summary>
            /// Conversion to the time scale in tenths of seconds
            /// </summary>
            /// <param name="value">Pure seconds value</param>
            /// <returns>return new <see cref="TenthsOfSeconds"/>(<paramref name="value"/> * 10f)</returns>
            public static TenthsOfSeconds ToTenthsOfSeconds(float value)
            {
                return new TenthsOfSeconds(value * 10f);
            }
            /// <summary>
            /// Conversion to the time scale in hundredths of seconds
            /// </summary>
            /// <returns>return new <see cref="TenthsOfSeconds"/>(<see cref="value"/> * 10f)</returns>
            public readonly TenthsOfSeconds ToTenthsOfSeconds()
            {
                return ToTenthsOfSeconds(value);
            }
            /// <summary>
            /// Conversion to the time scale in minutes
            /// </summary>
            /// <param name="value">Pure seconds value</param>
            /// <returns>return new <see cref="Minutes"/>(<paramref name="value"/> / 60f)</returns>
            public static Minutes ToMinutes(float value)
            {
                return new(value / 60f);
            }
            /// <summary>
            /// Conversion to the time scale in minutes
            /// </summary>
            /// <returns>return new <see cref="Minutes"/>(<see cref="value"/> / 60f)</returns>
            public readonly Minutes ToMinutes()
            {
                return ToMinutes(value);
            }
            /// <summary>
            /// Conversion to the time scale in hours
            /// </summary>
            /// <param name="value">Pure seconds value</param>
            /// <returns>return new <see cref="Minutes"/>(<paramref name="value"/> / 3_600f)</returns>
            public static Hours ToHours(float value)
            {
                return new(value / 3_600f);
            }
            /// <summary>
            /// Conversion to the time scale in hours
            /// </summary>
            /// <returns>return new <see cref="Hours"/>(<see cref="value"/> / 3_600f)</returns>
            public readonly Hours ToHours()
            {
                return ToHours(value);
            }
            /// <summary>
            /// Converts seconds into a string according to a chosen format
            /// </summary>
            /// <param name="format">Seconds display format in string</param>
            /// <returns>Returns a string of seconds according to the chosen format</returns>
            public readonly string ToString(Format format)
            {
                return string.Format(format.value, Mathf.Floor(value));
            }
            /// <summary>
            /// Pure value to integer conversion by floor
            /// </summary>
            public readonly int FloorValue => Mathf.FloorToInt(value);

            public static implicit operator string(Seconds seconds) => seconds.value.ToString();
            public static implicit operator int(Seconds seconds) => (int)seconds.value;
            public static implicit operator float(Seconds seconds) => seconds.value;
            public static implicit operator HundredthsOfSeconds(Seconds seconds) => ToHundredthsOfSeconds(seconds.value);
            public static implicit operator TenthsOfSeconds(Seconds seconds) => ToTenthsOfSeconds(seconds.value);
            public static implicit operator Minutes(Seconds seconds) => ToMinutes(seconds.value);
            public static implicit operator Hours(Seconds seconds) => ToHours(seconds.value);
        }
        #endregion
        #region Minutes
        /// <summary>
        /// Struct to handling minutes
        /// </summary>
        [Serializable]
        public struct Minutes
        {
            /// <summary>
            /// Pure minutes value
            /// </summary>
            public float value;
            /// <summary>
            /// Construct to handling minutes
            /// </summary>
            /// <param name="value">Pure minutes value</param>
            public Minutes(float value)
            {
                PositiveTimeGuarantee(ref value);
                this.value = value;
            }
            /// <summary>
            /// Conversion to the time scale in seconds
            /// </summary>
            /// <param name="value">Pure minutes value</param>
            /// <returns>return new <see cref="Seconds"/>(<paramref name="value"/> * 60f)</returns>
            public static Seconds ToSeconds(float value)
            {
                return new(value * 60f);
            }
            /// <summary>
            /// Conversion to the time scale in seconds
            /// </summary>
            /// <returns>return new <see cref="Seconds"/>(<see cref="value"/> * 60f)</returns>
            public readonly Seconds ToSeconds()
            {
                return ToSeconds(value);
            }
            /// <summary>
            /// Conversion to the time scale in hours
            /// </summary>
            /// <param name="value">Pure minutes value</param>
            /// <returns>return new <see cref="Hours"/>(<paramref name="value"/> / 60f)</returns>
            public static Hours ToHours(float value)
            {
                return new(value / 60f);
            }
            /// <summary>
            /// Conversion to the time scale in hours
            /// </summary>
            /// <returns>return new <see cref="Hours"/>(<see cref="value"/> / 60f)</returns>
            public readonly Hours ToHours()
            {
                return ToHours(value);
            }
            /// <summary>
            /// Converts seconds into a string according to a chosen format
            /// </summary>
            /// <param name="format">Seconds display format in string</param>
            /// <returns>Returns a string of seconds according to the chosen format</returns>
            public readonly string ToString(Format format)
            {
                return string.Format(format.value, Mathf.Floor(value));
            }
            /// <summary>
            /// Pure value to integer conversion by floor
            /// </summary>
            public readonly int FloorValue => Mathf.FloorToInt(value);

            public static implicit operator string(Minutes minutes) => minutes.value.ToString();
            public static implicit operator int(Minutes minutes) => (int)minutes.value;
            public static implicit operator float(Minutes minutes) => minutes.value;
            public static implicit operator Seconds(Minutes minutes) => ToSeconds(minutes.value);
            public static implicit operator Hours(Minutes minutes) => ToHours(minutes.value);
        }
        #endregion
        #region Hours
        /// <summary>
        /// Struct to handling hours
        /// </summary>
        [Serializable]
        public struct Hours
        {
            /// <summary>
            /// Pure hours value
            /// </summary>
            public float value;
            /// <summary>
            /// Construct to handling hours
            /// </summary>
            /// <param name="value">Pure hours value</param>
            public Hours(float value)
            {
                PositiveTimeGuarantee(ref value);
                this.value = value;
            }
            /// <summary>
            /// Conversion to the time scale in hours
            /// </summary>
            /// <param name="value">Pure hours value</param>
            /// <returns>return new <see cref="Minutes"/>(<paramref name="value"/> * 60f)</returns>
            public static Minutes ToMinutes(float value)
            {
                return new(value * 60f);
            }
            /// <summary>
            /// Conversion to the time scale in seconds
            /// </summary>
            /// <returns>return new <see cref="Minutes"/>(<see cref="value"/> * 60f)</returns>
            public readonly Minutes ToMinutes()
            {
                return ToMinutes(value);
            }
            /// <summary>
            /// Conversion to the time scale in hours
            /// </summary>
            /// <param name="value">Pure hours value</param>
            /// <returns>return new <see cref="Seconds"/>(<paramref name="value"/> * 3_600f)</returns>
            public static Seconds ToSeconds(float value)
            {
                return new(value * 3_600f);
            }
            /// <summary>
            /// Conversion to the time scale in seconds
            /// </summary>
            /// <returns>return new <see cref="Seconds"/>(<see cref="value"/> * 3_600f)</returns>
            public readonly Seconds ToSeconds()
            {
                return ToSeconds(value);
            }
            /// <summary>
            /// Converts seconds into a string according to a chosen format
            /// </summary>
            /// <param name="format">Seconds display format in string</param>
            /// <returns>Returns a string of seconds according to the chosen format</returns>
            public readonly string ToString(Format format)
            {
                return string.Format(format.value, Mathf.Floor(value));
            }
            /// <summary>
            /// Pure value to integer conversion by floor
            /// </summary>
            public readonly int FloorValue => Mathf.FloorToInt(value);

            public static implicit operator string(Hours hours) => hours.value.ToString();
            public static implicit operator int(Hours hours) => (int)hours.value;
            public static implicit operator float(Hours hours) => hours.value;
            public static implicit operator Minutes(Hours hours) => ToMinutes(hours.value);
            public static implicit operator Seconds(Hours hours) => ToSeconds(hours.value);
        }
        #endregion
        /// <summary>
        /// Struct that stores the formats for tenths of seconds strings
        /// </summary>
        [Serializable]
        public struct Format
        {
            /// <summary>
            /// Pure format string
            /// </summary>
            public string value;
            /// <summary>
            /// Construct to store the format in string
            /// </summary>
            /// <param name="value">Enter the string with the format</param>
            public Format(string value)
            {
                this.value = value;
            }
            /// <summary>
            /// Single digit, double digit or triple digit<br/>
            /// Exemple singleDigits: 9<br/>
            /// Exemple doubleDigits: 09<br/>
            /// Exemple tripleDigits: 009<br/>
            /// </summary>
            public static (Format single, Format @double, Format triple) Digit
                => (new("{0:0}"), new("{0:00}"), new("{0:000}"));
        }
        
        private static void PositiveTimeGuarantee(ref float value)
        {
            if (value < 0f)
            {
#if UNITY_EDITOR
                Debug.LogWarning($"There is no such thing as negative time! Therefore, the value of {nameof(value)} will return 0!");
#endif
                value = 0f;
            }
        }
    }
}