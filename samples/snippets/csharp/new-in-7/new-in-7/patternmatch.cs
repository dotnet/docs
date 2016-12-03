using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_in_7
{
    #region 18_PercentileDie
    public struct PercentileDie
    {
        public int Value { get; }
        public int Multiplier { get; }

        public PercentileDie(int multiplier, int value)
        {
            this.Value = value;
            this.Multiplier = multiplier;
        }
    }
    #endregion

    public class Patterns
    {
        // Sum die roll:
        #region 14_SumDieRolls
        public static int DiceSum(IEnumerable<int> values)
        {
            return values.Sum();
        }
        #endregion

        // Sample 2
        #region 15_SumDieRollsWithGroups
        public static int DiceSum2(IEnumerable<object> values)
        {
            var sum = 0;
            foreach(var item in values)
            {
                if (item is int val)
                    sum += val;
                else if (item is IEnumerable<object> subList)
                    sum += DiceSum2(subList);
            }
            return sum;
        }
        #endregion

        // Sample 3
        #region 16_SumUsingSwitch
        public static int DiceSum3(IEnumerable<object> values)
        {
            var sum = 0;
            foreach (var item in values)
            {
                switch (item)
                {
                    case int val:
                        sum += val;
                        break;
                    case IEnumerable<object> subList:
                        sum += DiceSum3(subList);
                        break;
                }
            }
            return sum;
        }
        #endregion

        #region 17_SwitchWithConstants
        public static int DiceSum4(IEnumerable<object> values)
        {
            var sum = 0;
            foreach (var item in values)
            {
                switch (item)
                {
                    case 0:
                        break;
                    case int val:
                        sum += val;
                        break;
                    case IEnumerable<object> subList when subList.Any():
                        sum += DiceSum4(subList);
                        break;
                    case IEnumerable<object> subList:
                        break;
                    case null:
                        break;
                    default:
                        throw new InvalidOperationException("unknown item type");
                }
            }
            return sum;
        }
        #endregion


        #region 19_SwitchWithNewTypes
        public static int DiceSum5(IEnumerable<object> values)
        {
            var sum = 0;
            foreach (var item in values)
            {
                switch (item)
                {
                    case 0:
                        break;
                    case int val:
                        sum += val;
                        break;
                    case PercentileDie die:
                        sum += die.Multiplier * die.Value;
                        break;
                    case IEnumerable<object> subList when subList.Any():
                        sum += DiceSum5(subList);
                        break;
                    case IEnumerable<object> subList:
                        break;
                    case null:
                        break;
                    default:
                        throw new InvalidOperationException("unknown item type");
                }
            }
            return sum;
        }
        #endregion
    }
}
