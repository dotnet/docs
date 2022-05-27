using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attributes
{
#nullable disable
    public class NullableOblivious
    {
        private Dictionary<string, string> _messageMap = new();
        // <TryGetExample>
        bool TryGetMessage(string key, out string message)
        {
            if (_messageMap.ContainsKey(key))
                message = _messageMap[key];
            else
                message = null;
            return message != null;
        }
        // </TryGetExample>

        // <PropertyExample>
        public string ScreenName
        {
            get => _screenName;
            set => _screenName = value ?? GenerateRandomScreenName();
        }
        private string _screenName;
        // </PropertyExample>
        private static string GenerateRandomScreenName() => throw new NotImplementedException();

        // <MessagingExample>
        public string ReviewComment
        {
            get => _comment;
            set => _comment = value ?? throw new ArgumentNullException(nameof(value), "Cannot set to null");
        }
        string _comment;
        // </MessagingExample>

        // <FindMethod>
        public T Find<T>(IEnumerable<T> sequence, Func<T, bool> predicate)
        // </FindMethod>
        {
            foreach (T item in sequence)
            {
                if (predicate(item)) return item;
            }
            return default;
        }

        // <ThrowWhenNull>
        public static void ThrowWhenNull(object value, string valueExpression = "")
        {
            if (value is null) throw new ArgumentNullException(nameof(value), valueExpression);
        }
        // </ThrowWhenNull>

        // <ExtractComponent>
        string GetTopLevelDomainFromFullUrl(string url)
        // </ExtractComponent>
        {
            return default;
        }

    }

#nullable restore
    public class NullableAttributes
    {
        private Dictionary<string, string> _messageMap = new();

        // <NotNullWhenTryGet>
        bool TryGetMessage(string key, [NotNullWhen(true)] out string? message)
        {
            if (_messageMap.ContainsKey(key))
                message = _messageMap[key];
            else
                message = null;
            return message is not null;
        }
        // </NotNullWhenTryGet>

        // <AllowNullableProperty>
        [AllowNull]
        public string ScreenName
        {
            get => _screenName;
            set => _screenName = value ?? GenerateRandomScreenName();
        }
        private string _screenName = GenerateRandomScreenName();
        // </AllowNullableProperty>
        private static string GenerateRandomScreenName() => throw new NotImplementedException();

        // <DisallowNullProperty>
        [DisallowNull]
        public string? ReviewComment
        {
            get => _comment;
            set => _comment = value ?? throw new ArgumentNullException(nameof(value), "Cannot set to null");
        }
        string? _comment;
        // </DisallowNullProperty>

        // <FindMethodMaybeNull>
        [return: MaybeNull]
        public T Find<T>(IEnumerable<T> sequence, Func<T, bool> predicate)
        // </FindMethodMaybeNull>
        {
            foreach (T item in sequence)
            {
                if (predicate(item)) return item;
            }
            return default;
        }

        // <NotNullThrowHelper>
        public static void ThrowWhenNull([NotNull] object? value, string valueExpression = "")
        {
            _ = value ?? throw new ArgumentNullException(nameof(value), valueExpression);
            // other logic elided
        // </NotNullThrowHelper>
        }

        // <TestThrowHelper>
        public static void LogMessage(string? message)
        {
            ThrowWhenNull(message, $"{nameof(message)} must not be null");

            Console.WriteLine(message.Length);
        }
        // </TestThrowHelper>

        public static void ExampleNullCheck()
        {
            // <NullCheckExample>
            string? userInput = GetUserInput();
            if (!string.IsNullOrEmpty(userInput))
            {
                int messageLength = userInput.Length; // no null check needed.
            }
            // null check needed on userInput here.
            // </NullCheckExample>

        }

        private static string? GetUserInput() => throw new NotImplementedException();

        // <DoesNotReturn>
        [DoesNotReturn]
        private void FailFast()
        {
            throw new InvalidOperationException();
        }

        public void SetState(object containedField)
        {
            if (containedField is null)
            {
                FailFast();
            }

            // containedField can't be null:
            _field = containedField;
        }
        // </DoesNotReturn>

        object _field = new object();

        // <DoesNotReturnIf>
        private void FailFastIf([DoesNotReturnIf(true)] bool isNull)
        {
            if (isNull)
            {
                throw new InvalidOperationException();
            }
        }

        public void SetFieldState(object? containedField)
        {
            FailFastIf(containedField == null);
            // No warning: containedField can't be null here:
            _field = containedField;
        }
        // </DoesNotReturnIf>


        // <ExtractComponentIfNotNull>
        [return: NotNullIfNotNull("url")]
        string? GetTopLevelDomainFromFullUrl(string? url)
        // </ExtractComponentIfNotNull>
        {
            if (url is null)
            {
                return null;
            }
            else
            {
                return ".com";
            }
        }
    }
}
