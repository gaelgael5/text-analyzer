using System;
using System.Diagnostics;

namespace Bb.Helpers
{

    /// <summary>
    /// Helper for asserting rules
    /// </summary>
    public class Assert
    {

        /// <summary>
        /// Ensures the specified predicate is true or throw specified exception.
        /// </summary>
        /// <param name="predicate">if set to <c>true</c> [predicate].</param>
        /// <param name="exception">The exception.</param>
        [System.Diagnostics.DebuggerNonUserCode]
        public static void Ensure(bool predicate, Func<Exception> exception)
        {
            if (!predicate)
            {
                var e = exception();
                if (Debugger.IsAttached)
                    Debug.Fail(e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Ensures the specified object is not null or throw specified exception.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="variableName">Name of the variable.</param>
        public static void NotNull(object item, string variableName)
        {
            if (item == null)
            {
                var e = new NullReferenceException(variableName);
                if (Debugger.IsAttached)
                    Debug.Fail(e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Ensures the specified text is not null or empty or throw specified exception.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="variableName">Name of the variable.</param>
        public static void NotEmpty(string item, string variableName)
        {
            if (string.IsNullOrEmpty(item))
            {
                var e = new NullReferenceException(variableName);
                if (Debugger.IsAttached)
                    Debug.Fail(e.Message);
                throw e;
            }
        }
    }
}