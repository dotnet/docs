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
        // <TryGetExample>
        bool TryGetMessage(string key, out string message)
        {
            message = "";
            return true;
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
            if (value is null) throw new ArgumentNullException(valueExpression);
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

        // <NotNullWhenTryGet>
        bool TryGetMessage(string key, [NotNullWhen(true)] out string? message)
        {
            message = "";
            return true;
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
        public static void ThrowWhenNull([NotNull] object? value, string valueExpression = "") =>
            _ = value ?? throw new ArgumentNullException(valueExpression);
        // </NotNullThrowHelper>

        // <TestThrowHelper>
        public static void LogMessage(string? message)
        {
            ThrowWhenNull(message, nameof(message));

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
            if (!isInitialized)
            {
                FailFast();
            }

            // unreachable code:
            _field = containedField;
        }
        // </DoesNotReturn>

        bool isInitialized;
        object _field;

        // <DoesNotReturnIf>
        private void FailFastIf([DoesNotReturnIf(false)] bool isValid)
        {
            if (!isValid)
            {
                throw new InvalidOperationException();
            }
        }

        public void SetFieldState(object containedField)
        {
            FailFastIf(isInitialized);

            // unreachable code when "isInitialized" is false:
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
