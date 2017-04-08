
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

namespace Microsoft.ServiceModel.Samples
{
    using System;
    using System.Threading;
    using System.ServiceModel.Channels;

    public struct TimeoutHelper
    {
        public static TimeSpan DefaultTimeout { get { return TimeSpan.FromMinutes(2); } }
        public static TimeSpan DefaultShortTimeout { get { return TimeSpan.FromSeconds(4); } }
        public static TimeSpan Infinite { get { return TimeSpan.MaxValue; } }
        DateTime deadline;
        TimeSpan originalTimeout;

        public TimeoutHelper(TimeSpan timeout)
        {
            if (timeout < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException("timeout");
            }

            this.originalTimeout = timeout;
            if (timeout == TimeSpan.MaxValue)
            {
                this.deadline = DateTime.MaxValue;
            }
            else
            {
                this.deadline = DateTime.UtcNow + timeout;
            }
        }

        public TimeSpan OriginalTimeout
        {
            get { return this.originalTimeout; }
        }

        public TimeSpan RemainingTime()
        {
            if (this.deadline == DateTime.MaxValue)
            {
                return TimeSpan.MaxValue;
            }
            else
            {
                TimeSpan remaining = this.deadline - DateTime.UtcNow;
                if (remaining <= TimeSpan.Zero)
                {
                    return TimeSpan.Zero;
                }
                else
                {
                    return remaining;
                }
            }
        }
        public void SetTimer(TimerCallback callback, Object state)
        {
            Timer timer = new Timer(callback, state, TimeoutHelper.ToMilliseconds(this.RemainingTime()), Timeout.Infinite);
        }

        public static TimeSpan FromMilliseconds(int milliseconds)
        {
            if (milliseconds == Timeout.Infinite)
            {
                return TimeSpan.MaxValue;
            }
            else
            {
                return TimeSpan.FromMilliseconds(milliseconds);
            }
        }

        public static int ToMilliseconds(TimeSpan timeout)
        {
            if (timeout == TimeSpan.MaxValue)
            {
                return Timeout.Infinite;
            }
            else
            {
                long ticks = Ticks.FromTimeSpan(timeout);
                if (ticks / TimeSpan.TicksPerMillisecond > int.MaxValue)
                {
                    return int.MaxValue;
                }
                return Ticks.ToMilliseconds(ticks);
            }
        }

        public static TimeSpan Add(TimeSpan timeout1, TimeSpan timeout2)
        {
            return Ticks.ToTimeSpan(Ticks.Add(Ticks.FromTimeSpan(timeout1), Ticks.FromTimeSpan(timeout2)));
        }

        public static DateTime Add(DateTime time, TimeSpan timeout)
        {
            if (timeout >= TimeSpan.Zero && DateTime.MaxValue - time <= timeout)
            {
                return DateTime.MaxValue;
            }
            if (timeout <= TimeSpan.Zero && DateTime.MinValue - time >= timeout)
            {
                return DateTime.MinValue;
            }
            return time + timeout;
        }

        public static DateTime Subtract(DateTime time, TimeSpan timeout)
        {
            return Add(time, TimeSpan.Zero - timeout);
        }

        public static TimeSpan Divide(TimeSpan timeout, int factor)
        {
            if (timeout == TimeSpan.MaxValue)
            {
                return TimeSpan.MaxValue;
            }

            return Ticks.ToTimeSpan((Ticks.FromTimeSpan(timeout) / factor) + 1);
        }

        public static bool WaitOne(WaitHandle waitHandle, TimeSpan timeout, bool exitSync)
        {
            if (timeout == TimeSpan.MaxValue)
            {
                waitHandle.WaitOne();
                return true;
            }
            else
            {
                TimeSpan maxWait = TimeSpan.FromMilliseconds(Int32.MaxValue);

                while (timeout > maxWait)
                {
                    bool signaled = waitHandle.WaitOne(maxWait, exitSync);

                    if (signaled)
                    {
                        return true;
                    }

                    timeout -= maxWait;
                }

                return waitHandle.WaitOne(timeout, exitSync);
            }
        }

        static class Ticks
        {
            public static long FromMilliseconds(int milliseconds)
            {
                return (long)milliseconds * TimeSpan.TicksPerMillisecond;
            }

            public static int ToMilliseconds(long ticks)
            {
                return checked((int)(ticks / TimeSpan.TicksPerMillisecond));
            }

            public static long FromTimeSpan(TimeSpan duration)
            {
                return duration.Ticks;
            }

            public static TimeSpan ToTimeSpan(long ticks)
            {
                return new TimeSpan(ticks);
            }

            public static long Add(long firstTicks, long secondTicks)
            {
                if (firstTicks == long.MaxValue || firstTicks == long.MinValue)
                {
                    return firstTicks;
                }
                if (secondTicks == long.MaxValue || secondTicks == long.MinValue)
                {
                    return secondTicks;
                }
                if (firstTicks >= 0 && long.MaxValue - firstTicks <= secondTicks)
                {
                    return long.MaxValue - 1;
                }
                if (firstTicks <= 0 && long.MinValue - firstTicks >= secondTicks)
                {
                    return long.MinValue + 1;
                }
                return checked(firstTicks + secondTicks);
            }
        }
    }
}