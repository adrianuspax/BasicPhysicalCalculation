using System;
using UnityEngine;

namespace Unit
{
    public static class Time
    {
        [Serializable]
        public struct Seconds
        {
            public float value;

            public Seconds(float value)
            {
                if (value < 0f)
                {
                    Debug.LogWarning($"There is no such thing as negative time! Therefore, the value of {nameof(value)} will return positive!");
                    value = Mathf.Abs(value);
                }

                this.value = value;
            }

            public static Minutes ToMinutes(float value)
            {
                return new Minutes(value / 60f);
            }

            public readonly Minutes ToMinutes()
            {
                return ToMinutes(value);
            }

            public static Hours ToHours(float value)
            {
                return new Hours(value / 3_600f);
            }

            public readonly Hours ToHours()
            {
                return ToHours(value);
            }

            public static Days ToDays(float value)
            {
                return new Days(value / 86_400f);
            }

            public readonly Days ToDays()
            {
                return ToDays(value);
            }

            public readonly string ToString(Format seconds)
            {
                return string.Format(seconds.Get(), Mathf.Floor(value));
            }

            [Serializable]
            public struct Tenths
            {
                public float seconds;
                public float tenths;

                public Tenths(float seconds)
                {
                    if (seconds < 0f)
                    {
                        Debug.LogWarning($"There is no such thing as negative time! Therefore, the value of {nameof(seconds)} will return positive!");
                        seconds = Mathf.Abs(seconds);
                    }

                    this.seconds = seconds;
                    tenths = (seconds * 10) % 10;
                }

                public readonly string ToString(Format secondsAndTenths)
                {
                    return string.Format(secondsAndTenths.Get(), Mathf.Floor(seconds), Mathf.Floor(tenths));
                }

                public readonly struct Format
                {
                    private readonly string value;

                    private Format(string value)
                    {
                        this.value = value;
                    }

                    public string Get()
                    {
                        return value;
                    }

                    public static Format BothSingleDigits => new("{0:0}.{1:0}");
                    public static Format BothDoubleDigits => new("{0:00}.{1:00}");
                    public static Format SingleAndDoubleDigits => new("{0:0}.{1:00}");
                    public static Format DoubleAndSingleDigits => new("{0:00}.{1:0}");
                }
            }

            [Serializable]
            public struct Hundredths
            {
                public float seconds;
                public float hundredths;

                public Hundredths(float seconds)
                {
                    if (seconds < 0f)
                    {
                        Debug.LogWarning($"There is no such thing as negative time! Therefore, the value of {nameof(seconds)} will return positive!");
                        seconds = Mathf.Abs(seconds);
                    }

                    this.seconds = seconds;
                    hundredths = (seconds * 100) % 100;
                }

                public readonly string ToString(Format secondsAndHundredths)
                {
                    return string.Format(secondsAndHundredths.Get(), Mathf.Floor(seconds), Mathf.Floor(hundredths));
                }

                public readonly struct Format
                {
                    private readonly string value;

                    private Format(string value)
                    {
                        this.value = value;
                    }

                    public string Get()
                    {
                        return value;
                    }

                    public static Format SecondsSingleDigit => new("{0:0}.{1:00}");
                    public static Format SecondsDoubleDigits => new("{0:00}.{1:00}");
                }
            }

            public readonly struct Format
            {
                private readonly string value;

                private Format(string value)
                {
                    this.value = value;
                }

                public string Get()
                {
                    return value;
                }

                public static Format SingleDigit => new("{0:0}");
                public static Format DoubleDigits => new("{0:00}");
                public static Format TripleDigits => new("{0:000}");
            }
        }

        [Serializable]
        public struct Minutes
        {
            public float value;

            public Minutes(float value)
            {
                if (value < 0f)
                {
                    Debug.LogWarning($"There is no such thing as negative time! Therefore, the value of {nameof(value)} will return positive!");
                    value = Mathf.Abs(value);
                }

                this.value = value;
            }
        }

        [Serializable]
        public struct Hours
        {
            public float value;

            public Hours(float value)
            {
                if (value < 0f)
                {
                    Debug.LogWarning($"There is no such thing as negative time! Therefore, the value of {nameof(value)} will return positive!");
                    value = Mathf.Abs(value);
                }

                this.value = value;
            }
        }

        [Serializable]
        public struct Days
        {
            public float value;

            public Days(float value)
            {
                if (value < 0f)
                {
                    Debug.LogWarning($"There is no such thing as negative time! Therefore, the value of {nameof(value)} will return positive!");
                    value = Mathf.Abs(value);
                }

                this.value = value;
            }
        }

        [Serializable]
        public struct Weeks
        {
            public float value;

            public Weeks(float value)
            {
                if (value < 0f)
                {
                    Debug.LogWarning($"There is no such thing as negative time! Therefore, the value of {nameof(value)} will return positive!");
                    value = Mathf.Abs(value);
                }

                this.value = value;
            }
        }

        [Serializable]
        public struct Months
        {
            public float value;

            public Months(float value)
            {
                if (value < 0f)
                {
                    Debug.LogWarning($"There is no such thing as negative time! Therefore, the value of {nameof(value)} will return positive!");
                    value = Mathf.Abs(value);
                }

                this.value = value;
            }
        }

        [Serializable]
        public struct Years
        {
            public float value;

            public Years(float value)
            {
                if (value < 0f)
                {
                    Debug.LogWarning($"There is no such thing as negative time! Therefore, the value of {nameof(value)} will return positive!");
                    value = Mathf.Abs(value);
                }

                this.value = value;
            }
        }
    }
}