using System.Runtime.InteropServices;

namespace ManagedComServer
{
    [Guid("EAA4976A-45C3-4BC5-BC0B-E474F4C3C83F")]
    [ComVisible(true)]
    public interface ICalculator
    {
        [DispId(1)]
        double CurrentValue { get; }

        [DispId(2)]
        double Add(double a, double b);

        [DispId(3)]
        double Multiply(double a, double b);

        [DispId(4)]
        void Clear();
    }

    [Guid("7BD20046-DF8C-44A6-8F6B-687FAA26FA71")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [ComVisible(true)]
    public interface ICalculatorEvents
    {
        [DispId(1)]
        void CalculationCompleted(double result);

        [DispId(2)]
        void Cleared();
    }

    [Guid("0D53A3E8-E51A-49C7-944E-E72A2064F938")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(ICalculatorEvents))]
    [ComVisible(true)]
    public class Calculator : ICalculator
    {
        private double _currentValue;

        public delegate void CalculationCompletedDelegate(double result);
        public delegate void ClearedDelegate();

        public event CalculationCompletedDelegate? CalculationCompleted;
        public event ClearedDelegate? Cleared;

        public double CurrentValue => _currentValue;

        public double Add(double a, double b)
        {
            _currentValue = a + b;
            CalculationCompleted?.Invoke(_currentValue);
            return _currentValue;
        }

        public double Multiply(double a, double b)
        {
            _currentValue = a * b;
            CalculationCompleted?.Invoke(_currentValue);
            return _currentValue;
        }

        public void Clear()
        {
            _currentValue = 0;
            Cleared?.Invoke();
        }
    }
}
