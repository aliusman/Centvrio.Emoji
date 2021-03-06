﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Centvrio.Emoji
{
    public class UnicodeSequence : IEnumerable<UnicodeString>
    {
        private readonly List<UnicodeString> storage;

        /// <summary>
        /// Initializes a new instance of Centvrio.Emoji.UnicodeSequence
        /// </summary>
        /// <param name="capacity">Number of elements the internal sequence</param>
        /// <exception cref="ArgumentOutOfRangeException">Capacity is less than 0.</exception>
        public UnicodeSequence(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException("Capacity is less than 0.");
            }
            storage = new List<UnicodeString>(capacity);
        }

        /// <summary>
        /// Gets or sets the total number of elements the internal sequence.
        /// </summary>
        public int Capacity => storage?.Capacity ?? 0;

        /// <summary>
        /// Add item to Centvrio.Emoji.UnicodeSequence.
        /// </summary>
        /// <param name="unicodeString">Centvrio.Emoji.UnicodeString instance</param>
        /// <returns>Current Centvrio.Emoji.UnicodeSequence instance</returns>
        public UnicodeSequence Add(UnicodeString unicodeString)
        {
            storage.Add(unicodeString);
            return this;
        }

        public IEnumerator<UnicodeString> GetEnumerator()
        {
            foreach (UnicodeString unicodeString in storage)
            {
                yield return unicodeString;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString()
        {
            var sb = new StringBuilder(storage.Count * 2);
            foreach (UnicodeString unicodeString in storage)
            {
                sb.Append(unicodeString.ToCharArray());
            }
            return sb.ToString();
        }

        public static UnicodeSequence operator +(UnicodeSequence left, UnicodeString right)
        {
            if (left == null)
            {
                return null;
            }
            left.storage.Capacity++;
            return left.Add(right);
        }
    }
}
