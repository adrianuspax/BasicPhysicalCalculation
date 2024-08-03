using System;
using UnityEngine;

namespace Unit
{
    /// <summary>
    /// Class for handling time scales
    /// </summary>
    public static class Time
    {
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
            /// <param name="seconds">Seconds display format in string</param>
            /// <returns>Returns a string of seconds according to the chosen format</returns>
            public readonly string ToString(Format seconds)
            {
                return string.Format(seconds.value, Mathf.Floor(value));
            }
            /// <summary>
            /// Pure value to integer conversion by floor
            /// </summary>
            public readonly int FloorValue => Mathf.FloorToInt(value);
            /// <summary>
            /// Struct for handling tenths of seconds
            /// </summary>
            [Serializable]
            public struct Tenths
            {
                /// <summary>
                /// Pure tenths of seconds value
                /// </summary>
                public float value;
                [SerializeField] private float tenths;
                [SerializeField] private float seconds;
                /// <summary>
                /// Construct to handling tenths of seconds
                /// </summary>
                /// <param name="seconds">Pure seconds value</param>
                public Tenths(float seconds)
                {
                    PositiveTimeGuarantee(ref seconds);
                    this.seconds = seconds;
                    value = (seconds * 10f);
                    tenths = value % 10f;
                }
                /// <summary>
                /// Get puere seconds value
                /// </summary>
                /// <returns>Seconds in floater</returns>
                public readonly float GetSeconds()
                {
                    return seconds;
                }
                /// <summary>
                /// Converts tenths of seconds into a string according to a chosen format
                /// </summary>
                /// <param name="secondsAndTenths">Tenths of seconds display format in string</param>
                /// <returns>Returns a string of tenths of seconds according to the chosen format</returns>
                public readonly string ToString(Format secondsAndTenths)
                {
                    return string.Format(secondsAndTenths.value, Mathf.Floor(seconds), Mathf.Floor(tenths));
                }
                /// <summary>
                /// Pure value to integer conversion by floor
                /// </summary>
                public readonly int FloorValue => Mathf.FloorToInt(value);
                /// <summary>
                /// Tenths value to integer conversion by floor
                /// </summary>
                public readonly int FractionalRemainder => Mathf.FloorToInt(tenths);
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
                    /// Single digit or double digit for seconds and tenths of seconds separated by a dot.<br/>
                    /// Exemple singleDigits: 9.3<br/>
                    /// Exemple doubleDigits: 09.03<br/>
                    /// </summary>
                    public static (Format singleDigits, Format doubleDigits) SecondsAndTenthsFormat 
                        => (new("{0:0}.{1:0}"), new("{0:00}.{1:00}"));
                    /// <summary>
                    /// Single digit or double digit for seconds and tenths of seconds with single digit. Separated by a dot.<br/>
                    /// Exemple singleDigits: 9.3<br/>
                    /// Exemple doubleDigits: 09.3<br/>
                    /// </summary>
                    public static (Format singleDigit, Format doubleDigits) SecondsFormat
                        => (new("{0:0}.{1:0}"), new("{0:00}.{1:0}"));
                    /// <summary>
                    /// Single digit or double digit for tenths of seconds and seconds with single digit. Separated by a dot.<br/>
                    /// Exemple singleDigits: 9.3<br/>
                    /// Exemple doubleDigits: 9.03<br/>
                    /// </summary>
                    public static (Format singleDigit, Format doubleDigits) TenthsFormat 
                        => (new("{0:0}.{1:0}"), new("{0:0}.{1:00}"));
                }
            }
            /// <summary>
            /// Struct for handling hundredths of seconds
            /// </summary>
            [Serializable]
            public struct Hundredths
            {
                /// <summary>
                /// Pure hundredths of seconds value
                /// </summary>
                public float value;
                [SerializeField] private float seconds;
                [SerializeField] private float hundredths;
                /// <summary>
                /// Construct to handling hundredths of seconds
                /// </summary>
                /// <param name="seconds">Pure seconds value</param>
                public Hundredths(float seconds)
                {
                    PositiveTimeGuarantee(ref seconds);
                    this.seconds = seconds;
                    value = seconds * 100f;
                    hundredths = value % 100f;
                }
                /// <summary>
                /// Get puere seconds value
                /// </summary>
                /// <returns>Seconds in floater</returns>
                public readonly float GetSeconds()
                {
                    return seconds;
                }
                /// <summary>
                /// Converts tenths of seconds into a string according to a chosen format
                /// </summary>
                /// <param name="secondsAndHundredths">Tenths of seconds display format in string</param>
                /// <returns>Returns a string of tenths of seconds according to the chosen format</returns>
                public readonly string ToString(Format secondsAndHundredths)
                {
                    return string.Format(secondsAndHundredths.value, Mathf.Floor(seconds), Mathf.Floor(hundredths));
                }
                /// <summary>
                /// Pure value to integer conversion by floor
                /// </summary>
                public readonly int FloorValue => Mathf.FloorToInt(value);
                /// <summary>
                /// Hundredths value to integer conversion by floor
                /// </summary>
                public readonly int FractionalRemainder => Mathf.FloorToInt(hundredths);
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
                    /// Single digit or double digit for seconds and hundreths of seconds. Separated by a dot.<br/>
                    /// Exemple singleDigits: 9.33<br/>
                    /// Exemple doubleDigits: 09.33<br/>
                    /// </summary>
                    public static (Format singleDigit, Format doubleDigits) SecondsFormat
                        => (new("{0:0}.{1:00}"), new("{0:00}.{1:00}"));
                }
            }
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
                /// Single digit, double digit or triple digit for seconds. Separated by a dot.<br/>
                /// Exemple singleDigits: 9<br/>
                /// Exemple doubleDigits: 09<br/>
                /// Exemple tripleDigits: 009<br/>
                /// </summary>
                public static (Format singleDigit, Format doubleDigits, Format tripleDigits) SecondsFormat
                    => (new("{0:0}"), new("{0:00}"), new("{0:000}"));
            }
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
            /// Pure value to integer conversion by floor
            /// </summary>
            public readonly int FloorValue => Mathf.FloorToInt(value);
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
                /// Single digit, double digit or triple digit for seconds. Separated by a dot.<br/>
                /// Exemple singleDigits: 9<br/>
                /// Exemple doubleDigits: 09<br/>
                /// Exemple tripleDigits: 009<br/>
                /// </summary>
                public static (Format singleDigit, Format doubleDigits, Format tripleDigits) SecondsFormat
                    => (new("{0:0}"), new("{0:00}"), new("{0:000}"));
            }
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
            /// Pure value to integer conversion by floor
            /// </summary>
            public readonly int FloorValue => Mathf.FloorToInt(value);
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
                /// Single digit, double digit or triple digit for seconds. Separated by a dot.<br/>
                /// Exemple singleDigits: 9<br/>
                /// Exemple doubleDigits: 09<br/>
                /// Exemple tripleDigits: 009<br/>
                /// </summary>
                public static (Format singleDigit, Format doubleDigits, Format tripleDigits) SecondsFormat
                    => (new("{0:0}"), new("{0:00}"), new("{0:000}"));
            }
        }
        #endregion
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